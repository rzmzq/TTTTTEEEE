using UnityEngine;

public class GridManager
{
    public static int width = 10;
    public static int height = 20;

    public static Transform[,] grid = new Transform[width, height];

    public static bool IsCellEmpty(Vector2 pos)
    {
        int x = Mathf.RoundToInt(pos.x);
        int y = Mathf.RoundToInt(pos.y);

        if (x < 0 || x >= width) return false;
        if (y < 0) return false;
        if (y >= height) return true;

        return grid[x, y] == null;
    }
}
