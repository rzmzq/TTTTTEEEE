using UnityEngine;

public class GridManager
{
    public static int width = 10;
    public static int height = 20;

    public static Transform[,] grid = new Transform[width, height];

    public static bool IsInsideGrid(Vector2 pos)
    {
        return (pos.x >= 0 && pos.x < width && pos.y >= 0);
    }

    public static bool IsCellEmpty(Vector2 pos)
    {
        if (pos.y >= height)
            return true;

        return grid[(int)pos.x, (int)pos.y] == null;
    }
}
