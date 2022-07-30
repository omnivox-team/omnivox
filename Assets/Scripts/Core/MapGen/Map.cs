using System;
using System.Text;
using System.Collections.Generic;

// A single map tile.
public enum Cell
{
    Empty,
    // Solid object, can't be traversed.
    Wall
}

// Map allows to build and rebuild a labirinth of cells.
public class Map {
    public int width {get;}
    public int height {get;}
    Cell[,] cells {get;}

    public Map(int w, int h)
    {
        if (w <= 0)
        {
            throw new ArgumentException("width must be >0");
        }
        if (h <= 0)
        {
            throw new ArgumentException("height must be >0");
        }
        width = w;
        height = h;
        cells = new Cell[w, h];
    }

    // Sets cell values at (x, y).
    public void Set(int x, int y, Cell cell)
    {
        cells[x, y] = cell;
    }

    // Returns all cells and their coordinates.
    public IEnumerable<(int x, int y, Cell cell)> Cells()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                yield return (x, y, cells[x, y]);
            }
        }
        yield break;
    }

    public override string ToString()
    {
        // using StringBuilder to avoid many small allocations
        var sb = new StringBuilder();
        sb.AppendFormat("{0}x{1}\n", width, height);
        for (int j = 0; j < height; j++)
        {
            sb.Append("|");
            for (int i = 0; i < width; i++)
            {
                var cell = CellString.Debug(cells[i, j]);
                sb.AppendFormat("{0} ", cell);
            }
            sb.AppendLine("|");
        }
        return sb.ToString();
    }
}

// Helpers for cell string representations
class CellString {
    static public string Debug(Cell cell)
    {
        switch(cell) {
        case Cell.Empty:
            return " ";
        case Cell.Wall:
            return "#";
        default:
            return "?";
        }
    }
}