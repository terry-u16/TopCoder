using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public static class Program
{
    static void Main(string[] args)
    {
        int mazeSize = int.Parse(Console.ReadLine());
        int robotCount = int.Parse(Console.ReadLine());
        int targetCount = int.Parse(Console.ReadLine());

        var starts = new Square[robotCount];
        var targets = new Square[robotCount][];

        for (int i = 0; i < robotCount; i++)
        {
            string[] temp = Console.ReadLine().Split(' ');
            starts[i] = new Square(int.Parse(temp[0]), int.Parse(temp[1]));
            targets[i] = new Square[targetCount];

            for (int k = 0; k < targetCount; k++)
            {
                string[] temp2 = Console.ReadLine().Split(' ');
                targets[i][k] = new Square(int.Parse(temp2[0]), int.Parse(temp2[1]));
            }
        }

        HardestMaze prog = new HardestMaze(mazeSize, robotCount, targetCount, starts, targets);
        char[] ret = prog.FindSolution();

        Console.WriteLine(ret.Length);
        for (int i = 0; i < ret.Length; i++)
            Console.WriteLine(ret[i]);
    }
}

internal class HardestMaze
{
    readonly int _mazeSize, _robotCount, _targetCountEach;
    readonly Square[] _starts;
    readonly Square[][] _targets;
    bool[,] _walls;
    Item[,] _items;
    Diff[] _diffs;
    XorShift _xorShift;
    const int Inf = 1 << 20;

    public HardestMaze(int mazeSize, int robotCount, int targetCountEach, Square[] starts, Square[][] targets)
    {
        _mazeSize = mazeSize;
        _robotCount = robotCount;
        _targetCountEach = targetCountEach;
        _starts = starts;
        _targets = targets;
        _diffs = new Diff[] { new Diff(-1, 0), new Diff(1, 0), new Diff(0, -1), new Diff(0, 1) };
        _xorShift = new XorShift();
    }

    public char[] FindSolution()
    {
        const int generateLimit = 2000;
        const int timeLimit = 9900;
        const double densityLimit = 0.02;
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        _items = InitializeItems();
        var calculator = new ScoreCalculator(_mazeSize, _starts, _targets, _items);

        int bestScore;

        if (CalculateDencity() > densityLimit)  // 密ならランダムウォーク、疎ならナルトを作る
        {
            _walls = CreateRandom(generateLimit, stopWatch, calculator, out bestScore);
        }
        else
        {
            _walls = CreateNaruto();
            bestScore = calculator.CalculateScore(_walls);
        }

        double t0 = bestScore * 0.001;
        double t1 = bestScore * 0.00001;
        var startTime = stopWatch.ElapsedMilliseconds;

        var iteration = 0;

        while (stopWatch.ElapsedMilliseconds < timeLimit)
        {
            iteration++;
            var time = (double)(stopWatch.ElapsedMilliseconds - startTime) / (timeLimit - startTime);
            var temperature = Math.Pow(t0, 1.0 - time) * Math.Pow(t1, time);

            var random = _xorShift.Next(100);

            if (random < 30)
            {
                bestScore = TryRotate(calculator, bestScore, temperature);
            }
            else if (random < 95)
            {
                bestScore = TrySwap(calculator, bestScore, temperature, time);
            }
            else
            {
                bestScore = TryFlip(calculator, bestScore, temperature);
            }
        }
        Debug.WriteLine("iteration: " + iteration);
        return WallToGrid(_walls);
    }

    private double CalculateDencity()
    {
        double area = _mazeSize * _mazeSize;
        double items = Math.Pow(_robotCount, 1.5) * (_targetCountEach + 1);     // 色はなんとなく1.5乗する（色が少ないと渦巻きで良さそうだけど多い場合はそうでもなさそう）
        return items / area;
    }

    int TryRotate(ScoreCalculator calculator, int lastScore, double temperature)
    {
        var pivot = new Square(_xorShift.Next(_mazeSize - 1), _xorShift.Next(_mazeSize - 1));   // pivotか？というと違うが……ともかくRotationの左上
        var swaps = new Square[] { new Square(pivot.Row, pivot.Column), new Square(pivot.Row, pivot.Column + 1),
                                   new Square(pivot.Row + 1, pivot.Column + 1), new Square(pivot.Row + 1, pivot.Column) };
        var swappedWalls = swaps.Select(sq => _walls[sq.Row, sq.Column]).ToArray();
        var offset = _xorShift.Next(3) + 1;   // 時計回りか180°回転か反時計回りか

        var willChange = false;
        for (int i = 0; i < swaps.Length; i++)
        {
            willChange |= _walls[swaps[i].Row, swaps[i].Column] ^ swappedWalls[(i + offset) % swappedWalls.Length];
        }

        if (!willChange)
        {
            return lastScore; // Swapしても意味なければやめる
        }

        for (int i = 0; i < swaps.Length; i++)
        {
            _walls[swaps[i].Row, swaps[i].Column] = swappedWalls[(i + offset) % swappedWalls.Length];
        }

        var newScore = calculator.CalculateScore(_walls);
        if (IsAcceptableScore(lastScore, newScore, temperature))
        {
            //ShowMap();
            Debug.WriteLine((newScore > lastScore ? "[Updated!]" : "") + "Rotate(" + offset + "): " + newScore);
            return newScore;
        }
        else
        {
            for (int i = 0; i < swaps.Length; i++)
            {
                _walls[swaps[i].Row, swaps[i].Column] = swappedWalls[i];
            }
            return lastScore;
        }
    }

    int TrySwap(ScoreCalculator calculator, int lastScore, double temperature, double time)
    {
        const int MaxSwapSquare = 15;
        const int MinSwapSquare = 3;
        const double expRatio = 10;
        int swapSquare = Math.Min(_mazeSize, (int)((MaxSwapSquare - MinSwapSquare) * Math.Exp(-time * expRatio)) + MinSwapSquare);
        var offset = new Diff(_xorShift.Next(_mazeSize - swapSquare + 1), _xorShift.Next(_mazeSize - swapSquare + 1));
        var swapCount = _xorShift.Next(5); 
        swapCount = swapCount < 2 ? 2 : swapCount; // 2の回数を気持ち多めに(2,2,2,3,4点スワップ)
        var swaps = new Square[swapCount];
        var swappedWalls = new bool[swapCount];

        for (int i = 0; i < swapCount; i++)
        {
            swaps[i] = new Square(_xorShift.Next(swapSquare), _xorShift.Next(swapSquare)) + offset;
            swappedWalls[i] = _walls[swaps[i].Row, swaps[i].Column];
        }

        if (swappedWalls.Any(w => w) && swappedWalls.Any(w => !w))  // 全部壁or全部通路はSwapの意味がない
        {
            for (int i = 0; i < swaps.Length; i++)
            {
                _walls[swaps[i].Row, swaps[i].Column] = swappedWalls[(i + 1) % swappedWalls.Length];
            }

            var newScore = calculator.CalculateScore(_walls);
            if (IsAcceptableScore(lastScore, newScore, temperature))
            {
                //ShowMap();
                Debug.WriteLine((newScore > lastScore ? "[Updated!]" : "") + "Swap(" + swapCount + ", sq:" + swapSquare + "): " + newScore);
                return newScore;
            }
            else
            {
                for (int i = 0; i < swaps.Length; i++)
                {
                    _walls[swaps[i].Row, swaps[i].Column] = swappedWalls[i];
                }
                return lastScore;
            }
        }

        return lastScore;
    }

    int TryFlip(ScoreCalculator calculator, int lastScore, double temperature)
    {
        var flip = new Square(_xorShift.Next(_mazeSize), _xorShift.Next(_mazeSize));
        _walls[flip.Row, flip.Column] ^= true;
        var newScore = calculator.CalculateScore(_walls);
        if (IsAcceptableScore(lastScore, newScore, temperature))
        {
            //ShowMap();
            Debug.WriteLine((newScore > lastScore ? "[Updated!]" : "") + "Flip: " + newScore);
            return newScore;
        }
        else
        {
            _walls[flip.Row, flip.Column] ^= true;
            return lastScore;
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool IsAcceptableScore(int lastScore, int newScore, double temperature)
    {
        return newScore < Inf && (newScore >= lastScore || _xorShift.NextDouble() < Math.Exp((newScore - lastScore) / temperature));
    }

    private void DigMain(Square current)
    {
        if (!current.IsInsideOf(_mazeSize) || !_walls[current.Row, current.Column])
        {
            return;
        }

        if (_items[current.Row, current.Column].Type != Type.None || IsNotBridge(current))
        {
            _walls[current.Row, current.Column] = false;    // 掘る

            Shuffle(_diffs);
            foreach (var diff in _diffs)
            {
                var next = current + diff;
                if (next.IsInsideOf(_mazeSize) && _items[next.Row, next.Column].Type != Type.None)
                {
                    DigMain(next);
                }
            }

            foreach (var diff in _diffs)
            {
                DigMain(current + diff);
            }
        }
    }

    private bool[,] CreateRandom(int generateLimit, Stopwatch stopWatch, ScoreCalculator calculator, out int bestScore)
    {
        bool[,] bestWalls = null;
        bestScore = 0;

        while (stopWatch.ElapsedMilliseconds < generateLimit)
        {
            _walls = InitializeWalls();
            DigMain(_starts[0]);
            DigSub();
            var score = calculator.CalculateScore(_walls);

            if (score < Inf && score > bestScore)
            {
                // 既に_wallsに入ってる
                bestWalls = _walls;
                bestScore = score;
            }
            else
            {
                //元に戻す
                _walls = bestWalls;
            }
        }

        return bestWalls;
    }


    private void DigSub()
    {
        // 初期化時に壁に埋まってた場合、通路に出るまで掘り続ける
        foreach (var start in _starts)
        {
            if (_walls[start.Row, start.Column])
            {
                foreach (var diff in _diffs)
                {
                    if (DigSub(start, diff))
                    {
                        break;
                    }
                }
            }
        }

        foreach (var targets in _targets)
        {
            foreach (var target in targets)
            {
                if (_walls[target.Row, target.Column])
                {
                    foreach (var diff in _diffs)
                    {
                        if (DigSub(target, diff))
                        {
                            break;
                        }
                    }
                }
            }
        }
    }


    private bool DigSub(Square current, Diff diff)
    {
        var next = current + diff;
        _walls[current.Row, current.Column] = false;
        if (next.IsInsideOf(_mazeSize))
        {
            if (!_walls[next.Row, next.Column])
            {
                return true;
            }
            else
            {
                return DigSub(next, diff);
            }
        }
        else
        {
            return false;
        }
    }

    private bool[,] CreateStripe()
    {
        var walls = new bool[_mazeSize, _mazeSize];
        for (int row = 1; row < _mazeSize; row += 2)
        {
            for (int column = 1; column < _mazeSize - 1; column++)
            {
                walls[row, column] = true;
            }
        }

        foreach (var start in _starts)
        {
            walls[start.Row, start.Column] = false;
        }

        foreach (var targetSet in _targets)
        {
            foreach (var target in targetSet)
            {
                walls[target.Row, target.Column] = false;
            }
        }

        return walls;
    }

    private bool[,] CreateNaruto()
    {
        var diffs = new Diff[] { new Diff(1, 0), new Diff(0, 1), new Diff(-1, 0), new Diff(0, -1) };
        var direction = 0;

        var walls = InitializeWalls();
        var current = new Square(0, 0);

        while (true)
        {
            walls[current.Row, current.Column] = false;
            var next = current + diffs[direction % 4];
            var doubleNext = next + diffs[direction % 4];
            if (next.IsInsideOf(_mazeSize) && (!doubleNext.IsInsideOf(_mazeSize) || walls[doubleNext.Row, doubleNext.Column]))
            {
                current = next;
            }
            else
            {
                direction++;
                next = current + diffs[direction % 4];
                doubleNext = next + diffs[direction % 4];

                if (walls[next.Row, next.Column] && walls[doubleNext.Row, doubleNext.Column])
                {
                    current = next;
                }
                else
                {
                    break;
                }
            }
        }

        foreach (var start in _starts)
        {
            walls[start.Row, start.Column] = false;
        }

        foreach (var targetSet in _targets)
        {
            foreach (var target in targetSet)
            {
                walls[target.Row, target.Column] = false;
            }
        }

        return walls;
    }

    [Conditional("DEBUG")]
    private void ShowMap()
    {
        for (int row = 0; row < _mazeSize; row++)
        {
            for (int column = 0; column < _mazeSize; column++)
            {
                Debug.Write(_walls[row, column] ? '#' : '.');
            }
            Debug.WriteLine("");
        }
        Debug.WriteLine("");
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]

    private bool IsNotBridge(Square current)
    {
        var count = 0;
        foreach (var diff in _diffs)
        {
            var next = current + diff;
            if (next.IsInsideOf(_mazeSize) && !_walls[next.Row, next.Column])
            {
                count++;
            }
        }
        return count < 2;
    }

    private bool[,] InitializeWalls()
    {
        var wall = new bool[_mazeSize, _mazeSize];
        for (int i = 0; i < _mazeSize; i++)
        {
            for (int j = 0; j < _mazeSize; j++)
            {
                wall[i, j] = true;
            }
        }
        return wall;
    }

    private Item[,] InitializeItems()
    {
        var items = new Item[_mazeSize, _mazeSize];
        for (int robot = 0; robot < _starts.Length; robot++)
        {
            items[_starts[robot].Row, _starts[robot].Column] = new Item(Type.Robot, robot);
            var targets = _targets[robot];
            for (int target = 0; target < targets.Length; target++)
            {
                items[targets[target].Row, targets[target].Column] = new Item(Type.Taret, robot, target);
            }
        }
        return items;
    }

    private char[] WallToGrid(bool[,] wall)
    {
        var grid = new char[_mazeSize * _mazeSize];
        for (int row = 0; row < _mazeSize; row++)
        {
            for (int column = 0; column < _mazeSize; column++)
            {
                grid[row * _mazeSize + column] = wall[row, column] ? '#' : '.';
            }
        }
        return grid;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Shuffle<T>(T[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            var j = _xorShift.Next(i + 1);
            Swap(ref array[i], ref array[j]);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void Swap<T>(ref T a, ref T b)
    {
        var temp = a;
        a = b;
        b = temp;
    }
}

internal class ScoreCalculator
{
    readonly int _mazeSize;
    readonly Square[] _starts;
    readonly Square[][] _targets;
    readonly Item[] _items;
    readonly Diff[] _diffs;
    readonly List<int>[] _graph;
    const int Inf = 1 << 20;

    public ScoreCalculator(int mazeSize, Square[] starts, Square[][] targets, Item[,] items)
    {
        _mazeSize = mazeSize;
        _starts = starts;
        _targets = targets;
        _items = InitializeItems(mazeSize, starts, targets);
        _diffs = new Diff[] { new Diff(-1, 0), new Diff(1, 0), new Diff(0, -1), new Diff(0, 1) };
        _graph = new List<int>[mazeSize * mazeSize];
        for (int i = 0; i < _graph.Length; i++)
        {
            _graph[i] = new List<int>();
        }
    }

    public int CalculateScore(bool[,] walls)
    {
        var score = 0;

        for (int robot = 0; robot < _starts.Length; robot++)
        {
            if (walls[_starts[robot].Row, _starts[robot].Column] || _targets[robot].Any(t => walls[t.Row, t.Column]))
            {
                return Inf;
            }
        }

        ConstructGraph(walls);

        for (int robot = 0; robot < _starts.Length; robot++)
        {
            var targets = _targets[robot];
            var distances = new int[targets.Length + 1, targets.Length + 1];

            for (int i = 0; i <= targets.Length; i++)
            {
                for (int j = 0; j <= targets.Length; j++)
                {
                    distances[i, j] = Inf;
                }
                distances[i, i] = 0;
            }
            if (!Bfs(_starts[robot], -1, targets.Length, _graph, distances, robot))   // ダメそうならさっさとreturn
            {
                return Inf;
            }
            
            for (int target = 0; target + 1 < targets.Length; target++)
            {
                if (!Bfs(targets[target], target, targets.Length, _graph, distances, robot))
                {
                    return Inf;
                }
            }
            score += GetMinDistancePermutation(0, 0, targets.Length, distances);
        }
        return score;
    }

    private bool Bfs(Square start, int me, int targetCount, List<int>[] graph, int[,] targetDistances, int currentRobot)
    {
        var todo = new Queue<int>();
        todo.Enqueue(start.Row * _mazeSize + start.Column);
        var found = 0;
        var toFound = targetCount - me - 1;
        var distances = new int[_mazeSize * _mazeSize];
        distances[start.Row * _mazeSize + start.Column] = 1;     // Inf埋めする代わりに距離を1-indexed(?)にする

        while (todo.Count > 0)
        {
            var current = todo.Dequeue();
            var currentDistance = distances[current];
            foreach (var next in graph[current])
            {
                if (distances[next] == 0)
                {
                    var nextDistance = currentDistance + 1;
                    distances[next] = nextDistance;

                    // 目的地かどうか確認
                    var item = _items[next];
                    if (item.Type == Type.Taret && item.Robot == currentRobot && item.Target > me)
                    {
                        found++;
                        targetDistances[me + 1, item.Target + 1] = nextDistance - 1;    // 距離が1始まりなので最後に1引く
                        targetDistances[item.Target + 1, me + 1] = nextDistance - 1;
                        if (found == toFound)
                        {
                            return true;
                        }
                    }

                    todo.Enqueue(next);
                }
            }
        }

        return false;
    }

    private void ConstructGraph(bool[,] walls)
    {
        // グリッドのまま探索するとエッジ数が4*N*Nになって遅いのでグラフに変換。一本道が多いので半分強になる？
        for (int i = 0; i < _graph.Length; i++)
        {
            _graph[i].Clear();  // インスタンスは使い回し。GCの動作を減らしたい。
        }

        for (int row = 0; row < _mazeSize; row++)
        {
            for (int column = 0; column < _mazeSize; column++)
            {
                if (!walls[row, column])
                {
                    var current = row * _mazeSize + column;
                    if (row + 1 < _mazeSize && !walls[row + 1, column])
                    {
                        var down = current + _mazeSize;
                        _graph[current].Add(down);
                        _graph[down].Add(current);
                    }

                    if (column + 1 < _mazeSize && !walls[row, column + 1])
                    {
                        var right = current + 1;
                        _graph[current].Add(right);
                        _graph[right].Add(current);
                    }
                }
            }
        }
    }

    private int GetMinDistancePermutation(int current, int selected, int targetCount, int[,] distances)
    {
        if ((1 << targetCount) - 1 == selected)
        {
            return 0;
        }
        else
        {
            var min = int.MaxValue;
            for (int target = 0; target < targetCount; target++)
            {
                if (((1 << target) & selected) == 0)
                {
                    var next = target + 1; // distancesは1-indexed
                    min = Math.Min(min, GetMinDistancePermutation(next, selected | (1 << target), targetCount, distances) + distances[current, next]);
                }
            }
            return min;
        }
    }

    private static Item[] InitializeItems(int mazeSize, Square[] starts, Square[][] targets)
    {
        var items = new Item[mazeSize * mazeSize];
        for (int robot = 0; robot < starts.Length; robot++)
        {
            items[starts[robot].Row * mazeSize + starts[robot].Column] = new Item(Type.Robot, robot);
            var eachTargets = targets[robot];
            for (int target = 0; target < eachTargets.Length; target++)
            {
                items[eachTargets[target].Row * mazeSize + eachTargets[target].Column] = new Item(Type.Taret, robot, target);
            }
        }
        return items;
    }
}

[StructLayout(LayoutKind.Auto)]
internal struct Square
{
    readonly int _row;
    readonly int _column;

    public int Row 
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return _row; } 
    }
    public int Column 
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return _column; } 
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Square(int row, int column)
    {
        _row = row;
        _column = column;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool IsInsideOf(int mazeSize)
    {
        return unchecked((uint)Row < mazeSize && (uint)Column < mazeSize);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int ToGridIndex(int mazeSize)
    {
        return _row * mazeSize + Column;
    }

    public override string ToString()
    {
        return string.Format("({0}, {1})", Row, Column);
    }
}

[StructLayout(LayoutKind.Auto)]
internal struct Diff
{
    readonly int _dr;
    readonly int _dc;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Diff(int dr, int dc)
    {
        _dr = dr;
        _dc = dc;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Square operator+(Square sq, Diff diff)
    {
        return new Square(sq.Row + diff._dr, sq.Column + diff._dc);
    }
}

internal struct Item
{
    readonly int _flag;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Item(Type type, int robot) : this (type, robot, 0) { }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public Item(Type type, int robot, int target)
    {
        _flag = (int)type;
        _flag |= robot << 2;
        _flag |= target << 6;
    }

    public Type Type 
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return (Type)(_flag & 0x03); } 
    }

    public int Robot 
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return (_flag >> 2) & 0x0f; } 
    }

    public int Target 
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get { return (_flag >> 6) & 0x0f; } 
    }

    public override string ToString()
    {
        switch (Type)
        {
            case Type.None:
                return "None";
            case Type.Robot:
                return string.Format("Robot:{0}", Robot);
            case Type.Taret:
                return string.Format("Target:{0} of robot {1}", Target, Robot);
            default:
                return "";
        }
    }
}

internal enum Type
{
    None = 0,
    Robot = 1,
    Taret = 2
}

internal class XorShift
{
    ulong _x = 88172645463325252UL;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public ulong Next()
    {
        _x = _x ^ (_x << 13);
        _x = _x ^ (_x >> 7);
        _x = _x ^ (_x << 17);
        return _x;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int Next(int exclusiveMax)
    {
        return (int)(Next() % (uint)exclusiveMax);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public double NextDouble()
    {
        var mask = (1UL << 50) - 1;
        return (double)(Next() & mask) / mask;
    }
}