using System;
using System.Text; // include at the top

public enum Cell
{
    Empty,
    Wall
}

public class Map {
    int width {get;}
    int height {get;}
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