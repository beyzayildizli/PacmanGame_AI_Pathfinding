/**
 * @file: MinPathBetweenTwoLoc.cs
 * @description: This script implements a BFS algorithm to find the shortest path 
 * between two locations on a 2D grid. It ensures paths avoid obstacles and 
 * returns the optimal route if available.
 * @assignment: Pacman AI Pathfinding
 * @date: 11.12.2024
 * @author: Beyza Yıldızlı beyzayildizli10@gmail.com
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinPathBetweenTwoLoc : MonoBehaviour
{
    private const string WALL = "1";
    private class Node
    {
        public int[] Position { get; }
        public Node Parent { get; }

        public Node(int[] position, Node parent)
        {
            Position = position;
            Parent = parent;
        }
    }
    public List<int[]> FindShortestPath(string[,] map, int[] start, int[] goal)
    {
        int[,] directions = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };
        HashSet<string> visited = new HashSet<string>();
        Queue<Node> queue = new Queue<Node>();

        queue.Enqueue(new Node(start, null));
        visited.Add($"{start[0]},{start[1]}");

        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            int[] currentPosition = current.Position;

            if (currentPosition[0] == goal[0] && currentPosition[1] == goal[1])
            {
                return BuildPath(current);
            }

            for (int i = 0; i < directions.GetLength(0); i++) 
            {
                int newRow = currentPosition[0] + directions[i, 0];
                int newCol = currentPosition[1] + directions[i, 1];

                if (newRow >= 0 && newRow < map.GetLength(0) && newCol >= 0 && newCol < map.GetLength(1))
                {
                    if (map[newRow, newCol] != WALL && !visited.Contains($"{newRow},{newCol}"))
                    {
                        visited.Add($"{newRow},{newCol}");
                        queue.Enqueue(new Node(new int[] { newRow, newCol }, current));
                    }
                }
            }
        }
        
        Debug.LogWarning("Hedefe ulaşan bir yol bulunamadı!");
        return null;
    }

    private List<int[]> BuildPath(Node node)
    {
        List<int[]> path = new List<int[]>();
        while (node != null)
        {
            path.Add(node.Position);
            node = node.Parent;
        }
        path.Reverse();
        return path;
    } 
}