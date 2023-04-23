using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MazeSpawner : MonoBehaviour
{
    public GameObject CellPrefab;
    public GameObject leftTrigger;
    public GameObject BottomTrigger;
    private void Start()
    {
        MazeGenerator genarator = new MazeGenerator();
        MazeGeneratorCell [,] maze = genarator.GenerateMaze();
        MazeGeneratorCell furthest = maze[0, 0];
        int Wigth = 23;
        int Heigth = 15;

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            if (maze[x, Heigth - 2].DistanceFromStart > furthest.DistanceFromStart) furthest = maze[x, Heigth - 2];
            if (maze[x, 0].DistanceFromStart > furthest.DistanceFromStart) furthest = maze[x, 0];
        }

        for (int y = 0; y < maze.GetLength(1); y++)
        {
            if (maze[Wigth - 2, y].DistanceFromStart > furthest.DistanceFromStart) furthest = maze[Wigth - 2, y];
            if (maze[0, y].DistanceFromStart > furthest.DistanceFromStart) furthest = maze[0, y];
        }



        if (furthest.X == 0)
        {
            furthest.WallLeft = false;
        }
        else if (furthest.Y == 0)
        {
            furthest.WallBottom = false;

        }
        else if (furthest.X == Wigth - 2)
        {
            maze[furthest.X + 1, furthest.Y].WallLeft = false;
            furthest = maze[furthest.X + 1, furthest.Y]; 

        }
        else if (furthest.Y == Heigth - 2)
        {
            maze[furthest.X, furthest.Y + 1].WallBottom = false;
            furthest = maze[furthest.X, furthest.Y + 1];

        }


        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                Cell c = Instantiate(CellPrefab,new Vector2(x,y),Quaternion.identity).GetComponent<Cell>();
                c.WallLeft.SetActive(maze[x, y].WallLeft);
                c.WallBottom.SetActive(maze[x, y].WallBottom);
                
                
            }
        }
        if (furthest.Y == 0 || furthest.Y == 14)
        {
            Instantiate(BottomTrigger, new Vector2(furthest.X, furthest.Y), Quaternion.identity);
        }
        else
        {
            Instantiate(leftTrigger, new Vector2(furthest.X, furthest.Y), Quaternion.identity);
        }
        
    }
}
