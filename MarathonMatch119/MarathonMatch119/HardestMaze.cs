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
        const int timeLimit = 9900;
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        _walls = InitializeWalls();
        _items = InitializeItems();

        DigMain(_starts[0]);
        DigSub();

        var calculator = new ScoreCalculator(_mazeSize, _starts, _targets, _items);
        var score = calculator.CalculateScore(_walls);
        double t0 = score * 0.0001;
        double t1 = score * 0.000005;

        while (stopWatch.ElapsedMilliseconds < timeLimit)
        {
            var time = (double)stopWatch.ElapsedMilliseconds / timeLimit;
            var temperature = Math.Pow(t0, 1.0 - time) * Math.Pow(t1, time);

            if (_xorShift.Next(100) < 70)
            {
                score = TrySwap(calculator, score, temperature);
            }
            else
            {
                score = TryFlip(calculator, score, temperature);
            }
        }

        return WallToGrid(_walls);
    }

    int TrySwap(ScoreCalculator calculator, int lastScore, double temperature)
    {
        var swapA = new Square(_xorShift.Next(_mazeSize), _xorShift.Next(_mazeSize));
        var swapB = new Square(_xorShift.Next(_mazeSize), _xorShift.Next(_mazeSize));
        if (_walls[swapA.Row, swapA.Column] ^ _walls[swapA.Row, swapB.Column])
        {
            _walls[swapA.Row, swapA.Column] ^= true;
            _walls[swapB.Row, swapB.Column] ^= true;
            var newScore = calculator.CalculateScore(_walls);
            if (newScore < Inf && (newScore > lastScore))// || Math.Exp((lastScore - newScore) / temperature) > _xorShift.NextDouble()))
            {
                ShowMap();
                return newScore;
            }
            else
            {
                _walls[swapA.Row, swapA.Column] ^= true;
                _walls[swapB.Row, swapB.Column] ^= true;
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
        if (newScore < Inf && newScore > lastScore)
        {
            ShowMap();
            return newScore;
        }
        else
        {
            _walls[flip.Row, flip.Column] ^= true;
            return lastScore;
        }
    }

    private void DigMain(Square current)
    {
        if (!current.IsInsiteOf(_mazeSize) || !_walls[current.Row, current.Column])
        {
            return;
        }

        ShowMap();

        if (_items[current.Row, current.Column].Type != Type.None || IsNotBridge(current))
        {
            _walls[current.Row, current.Column] = false;    // 掘る

            Shuffle(_diffs);
            foreach (var diff in _diffs)
            {
                var next = current + diff;
                if (next.IsInsiteOf(_mazeSize) && _items[next.Row, next.Column].Type != Type.None)
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
        if (next.IsInsiteOf(_mazeSize))
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

    [Conditional("DEBUG")]
    private void ShowMap()
    {
        for (int row = 0; row < _mazeSize; row++)
        {
            for (int column = 0; column < _mazeSize; column++)
            {
                Console.Write(_walls[row, column] ? '#' : '.');
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    private bool IsNotBridge(Square current)
    {
        var count = 0;
        foreach (var diff in _diffs)
        {
            var next = current + diff;
            if (next.IsInsiteOf(_mazeSize) && !_walls[next.Row, next.Column])
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

    private void Shuffle<T>(T[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            var j = _xorShift.Next(i + 1);
            Swap(ref array[i], ref array[j]);
        }
    }

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
    Item[,] _items;
    Diff[] _diffs;
    const int Inf = 1 << 20;

    public ScoreCalculator(int mazeSize, Square[] starts, Square[][] targets, Item[,] items)
    {
        _mazeSize = mazeSize;
        _starts = starts;
        _targets = targets;
        _items = items;
        _diffs = new Diff[] { new Diff(-1, 0), new Diff(1, 0), new Diff(0, -1), new Diff(0, 1) };
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
            Bfs(_starts[robot], -1, targets.Length, walls, distances, robot);
            for (int target = 0; target + 1 < targets.Length; target++)
            {
                Bfs(targets[target], target, targets.Length, walls, distances, robot);
            }
            score += GetMinDistancePermutation(0, 0, targets.Length, distances);
        }
        return score;
    }

    private void Bfs(Square start, int me, int targetCount, bool[,] walls, int[,] targetDistances, int currentRobot)
    {
        var todo = new Queue<Square>();
        todo.Enqueue(start);
        var found = 0;
        var toFound = targetCount - me - 1;
        var distances = new int[_mazeSize, _mazeSize];

        for (int i = 0; i < _mazeSize; i++)
        {
            for (int j = 0; j < _mazeSize; j++)
            {
                distances[i, j] = Inf;
            }
        }

        distances[start.Row, start.Column] = 0;
        while (todo.Count > 0 && found < toFound)
        {
            var current = todo.Dequeue();
            var currentDistance = distances[current.Row, current.Column];
            foreach (var diff in _diffs)
            {
                var next = current + diff;
                if (next.IsInsiteOf(_mazeSize) && !walls[next.Row, next.Column] && distances[next.Row, next.Column] == Inf)
                {
                    var nextDistance = currentDistance + 1;
                    distances[next.Row, next.Column] = nextDistance;

                    // 目的地かどうか確認
                    var item = _items[next.Row, next.Column];
                    if (item.Type == Type.Taret && item.Robot == currentRobot && item.Target > me)
                    {
                        found++;
                        targetDistances[me + 1, item.Target + 1] = nextDistance;
                        targetDistances[item.Target + 1, me + 1] = nextDistance;
                    }

                    todo.Enqueue(next);
                }
            }
        }
    }

    int GetMinDistancePermutation(int current, int selected, int targetCount, int[,] distances)
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
}

[StructLayout(LayoutKind.Auto)]
internal struct Square
{
    readonly int _row;
    readonly int _column;
    public int Row { get { return _row; } }
    public int Column { get { return _column; } }

    public Square(int row, int column)
    {
        _row = row;
        _column = column;
    }

    public bool IsInsiteOf(int mazeSize)
    {
        return unchecked((uint)Row < mazeSize && (uint)Column < mazeSize);
    }

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

    public Diff(int dr, int dc)
    {
        _dr = dr;
        _dc = dc;
    }

    public static Square operator+(Square sq, Diff diff)
    {
        return new Square(sq.Row + diff._dr, sq.Column + diff._dc);
    }
}

internal struct Item
{
    readonly int _flag;

    public Item(Type type, int robot) : this (type, robot, 0) { }

    public Item(Type type, int robot, int target)
    {
        _flag = (int)type;
        _flag |= robot << 2;
        _flag |= target << 6;
    }

    public Type Type { get { return (Type)(_flag & 0x03); } }
    public int Robot { get { return (_flag >> 2) & 0x0f; } }
    public int Target { get { return (_flag >> 6) & 0x0f; } }
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