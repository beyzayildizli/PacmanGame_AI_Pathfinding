/**
 * @file: CalculateBestWay.cs
 * @description: This script calculates the shortest path for the character to collect 
 * all point items on the map using a BFS-based approach. It generates a tree structure 
 * to explore possible paths and selects the optimal route with minimal steps.
 * @assignment: Pacman AI Pathfinding
 * @date: 11.12.2024
 * @author: Beyza Yıldızlı beyzayildizli10@gmail.com
 */
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;
using System.Linq; 
public class CalculateBestWay : MonoBehaviour
{
    [Header("References")]
    public MinPathBetweenTwoLoc minPathBetweenTwoLoc;
    public CharacterMovement characterMovement;
    public MapLists mapList; 
    public Map mapScript; 
    public GameSounds gameSounds;
    
    private class Node2
    {
        public int[] Position { get; set; } 
        public Node2 Parent { get; set; } 
        public List<int[]> MinPath { get; set; }
        public int TotalStep { get; set; } 
        public List<int[]> RemainingPointList { get; set; } 

        public Node2(int[] position, Node2 parent, List<int[]> minPath, int totalStep, List<int[]> remainingPointList)
        {
            Position = position;
            Parent = parent;
            MinPath = minPath;
            TotalStep = totalStep;
            RemainingPointList = remainingPointList;
        }
    }

    public List<int[]> TotalBestWay(string[,] map, int[] characterLoc, List<int[]> pointList)
    {
        Node2 root = new Node2(characterLoc, null, new List<int[]>(), 0, new List<int[]>(pointList));
        Queue<Node2> queue = new Queue<Node2>();
        queue.Enqueue(root);

        List<Node2> leafNodes = new List<Node2>();

        while (queue.Count > 0)
        {
            Node2 currentNode = queue.Dequeue();

            // Eğer remainingPointList boşsa bu bir yaprak düğümdür
            if (currentNode.RemainingPointList.Count == 0)
            {
                leafNodes.Add(currentNode);
                continue;
            }

            // Her bir point konumu için child düğüm oluştur
            foreach (var point in currentNode.RemainingPointList)
            {
                List<int[]> minPath = minPathBetweenTwoLoc.FindShortestPath(map, currentNode.Position, point);
                if (minPath == null)
                    continue;

                int totalStep = currentNode.TotalStep + minPath.Count;
                List<int[]> remainingPointList = new List<int[]>(currentNode.RemainingPointList);
                remainingPointList.Remove(point);

                
                foreach (var step in minPath)
                {
                    remainingPointList.Remove(step);
                }

                Node2 childNode = new Node2(point, currentNode, minPath, totalStep, remainingPointList);
                queue.Enqueue(childNode);
            }
        }

        // En kısa yolu bul
        Node2 bestNode = null;
        int minSteps = int.MaxValue;

        foreach (var leaf in leafNodes)
        {
            if (leaf.TotalStep < minSteps)
            {
                minSteps = leaf.TotalStep;
                bestNode = leaf;
            }
        }

        // totalMinPath oluştur
        List<int[]> totalMinPath = new List<int[]>();
        while (bestNode != null && bestNode.MinPath != null)
        {
            totalMinPath.InsertRange(0, bestNode.MinPath);
            bestNode = bestNode.Parent;
        }

         // Arka arkaya tekrar eden lokasyonları sil
        List<int[]> filteredPath = new List<int[]>();
        for (int i = 0; i < totalMinPath.Count; i++)
        {
            if (i == 0 || !totalMinPath[i].SequenceEqual(totalMinPath[i - 1]))
            {
                filteredPath.Add(totalMinPath[i]);
            }
        }

        return filteredPath;
    }
}