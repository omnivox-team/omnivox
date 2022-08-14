using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    [SerializeField] private int width = 64;
    [SerializeField] private int height = 64;
    [SerializeField] private float scale = 1;
    [SerializeField] private int ttl = 10;
    [SerializeField] private GameObject cell_prefab;
    [SerializeField] private GameObject maze_structure;

    private DateTime last_generated = DateTime.MinValue;
    private Maze maze;
    private List<GameObject> walls = new List<GameObject>();

    private void RenderMaze()
    {
        walls.ForEach(wall => Destroy(wall));
        walls.Clear();

        foreach (var (maze_x, maze_y, cell) in maze.Cells())
        {
            float x = scale * maze_x;
            float y = scale * maze_y;
            if (cell == Maze.Cell.Wall)
            {
                var wall = Instantiate(cell_prefab, new Vector2(x, y), Quaternion.identity, maze_structure.transform);
                walls.Add(wall);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        maze = new Maze(width, height);
    }

    // Update is called once per frame
    void Update()
    {
        if (DateTime.Now.Subtract(last_generated) >= TimeSpan.FromSeconds(ttl))
        {
            maze.Generate(width / 2, height / 2);
            last_generated = DateTime.Now;
            RenderMaze();
        }
    }
}
