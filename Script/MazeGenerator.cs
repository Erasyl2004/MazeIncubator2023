using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;

public class MazeGeneratorCell {
    public int X;
    public int Y;
    public bool WallLeft = true;
    public bool WallBottom = true;
    public bool Visited = false;
    public int DistanceFromStart;

}

public class MazeGenerator
{
    public int Wigth = 23;
    public int Heigth = 15;
    public MazeGeneratorCell[,] GenerateMaze() {

        MazeGeneratorCell[,] maze = new MazeGeneratorCell[Wigth, Heigth];
        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x, y] = new MazeGeneratorCell { X= x, Y = y };            
            }
        }
        for (int i = 0; i < maze.GetLength(0); i++)
        {
            maze[i, Heigth - 1].WallLeft = false;
        }
        for (int i = 0; i < maze.GetLength(1); i++)
        {
            maze[Wigth - 1, i].WallBottom = false;
        }


        RemoveWallsWithBacktracker(maze);
        return maze;
    }
    private void RemoveWallsWithBacktracker(MazeGeneratorCell[,] maze)
    { 
        MazeGeneratorCell current = maze[0,0];
        current.Visited= true;
        current.DistanceFromStart = 0;
        Stack<MazeGeneratorCell> stack = new Stack<MazeGeneratorCell>();
        do
        {
            List<MazeGeneratorCell> unvisitedNeighbours = new List<MazeGeneratorCell>();


            int x = current.X;
            int y = current.Y;

            if (x > 0 && !maze[x - 1, y].Visited) unvisitedNeighbours.Add(maze[x - 1, y]);
            if (y > 0 && !maze[x, y - 1].Visited) unvisitedNeighbours.Add(maze[x, y - 1]);
            if (x < Wigth - 2 && !maze[x + 1, y].Visited) unvisitedNeighbours.Add(maze[x + 1, y]);
            if (y < Heigth - 2 && !maze[x, y + 1].Visited) unvisitedNeighbours.Add(maze[x,y + 1]);

            if (unvisitedNeighbours.Count > 0)
            { 
                MazeGeneratorCell chosen = unvisitedNeighbours[UnityEngine.Random.Range(0,unvisitedNeighbours.Count)];
                RemoveWall (current,chosen);
                chosen.Visited = true;
                stack.Push (chosen);
                current.DistanceFromStart = current.DistanceFromStart + 1;
                current = chosen;
            }
            else
               current = stack.Pop ();
        }
        while (stack.Count > 0);


    }

    private void RemoveWall(MazeGeneratorCell a, MazeGeneratorCell b)
    {
        if (a.X == b.X)
        {
            if (a.Y > b.Y) a.WallBottom = false;
            else b.WallBottom = false;

        }
        else
        { 
            if (a.X > b.X) a.WallLeft = false;
            else b.WallLeft = false;       
        }
    }
}
