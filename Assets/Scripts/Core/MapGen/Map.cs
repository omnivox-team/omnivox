using System;

public class Map {
    int width {get;}
    int height {get;}

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
    }
}