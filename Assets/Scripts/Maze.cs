using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Maze
{
    public enum Cell
    {
        Empty,
        Wall
    }

    private Cell[,] cells, buf;
    private int width = 64, heigth = 64;
    public int steps_to_generate = 2;
    public int birth_treshold = 4;
    public int death_treshold = 5;
    public Maze(int w, int h)
    {
        width = w;
        heigth = h;
        buf = new Cell[w, h];
        cells = new Cell[w, h];
        Generate(w / 2, h / 2);
    }

    public void Generate(int skip_x, int skip_y)
    {
        FillRandBuf(ref cells);
        for (int i = 0; i < steps_to_generate; i++)
        {
            GenerateStep();
        }
        cells[skip_x, skip_y] = Cell.Empty;
    }

    private void GenerateStep()
    {
        foreach (var (x, y, cell) in Cells())
        {
            var n = Neighbours(x, y)
                    .Count(n => n == Cell.Wall);

            if (cell == Cell.Wall && n < 3)
            {
                buf[x, y] = Cell.Empty;
            }
            else if (cell == Cell.Empty && n > 4)
            {
                buf[x, y] = Cell.Wall;
            }
            else
            {
                buf[x, y] = cell;
            }
        }
        var keeper = cells;
        cells = buf;
        buf = keeper;
    }

    private void FillRandBuf(ref Cell[,] buf)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < heigth; y++)
            {
                var p = Random.Range(0, 100);
                var cell = Cell.Empty;
                if (p < 40)
                {
                    cell = Cell.Wall;
                }
                buf[x, y] = cell;
            }
        }
    }

    private IEnumerable<Cell> Neighbours(int x, int y)
    {
        for (int dx = -1; dx <= 1; dx++)
        {
            for (int dy = -1; dy <= 1; dy++)
            {
                var neighbour_x = x + dx;
                var neighbour_y = y + dy;
                if (neighbour_x >= 0 && neighbour_y >= 0 &&
                    neighbour_x < width && neighbour_y < heigth)
                {
                    yield return cells[neighbour_x, neighbour_y];
                } else
                {
                    yield return Cell.Wall;
                }
            }
        }
        yield break;
    }

    public IEnumerable<(int x, int y, Cell cell)> Cells()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < heigth; y++)
            {
                yield return (x, y, cells[x, y]);
            }
        }
        yield break;
    }
}