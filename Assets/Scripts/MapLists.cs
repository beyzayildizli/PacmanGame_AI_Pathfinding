/**
 * @file: MapLists.cs
 * @description: This script holds predefined level maps for the game. Each level is represented
 * as a 2D string array where "1" indicates walls, " " indicates walkable paths, "0" marks the Pacman 
 * characters to be eaten, and "X" represents the ghost character (main player).
 * @assignment: Pacman AI Pathfinding
 * @date: 11.12.2024
 * @autor: Beyza Yıldızlı beyzayildizli10@gmail.com
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLists : MonoBehaviour
{
    public List<string[,]> levelMaps;
    public MapLists()
    {
        levelMaps = new List<string[,]>
        {
            level1Map,
            level2Map,
            level3Map,
            level4Map
        };
    }

    private string[,] level1Map = new string[,]
        {
            { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" },
            { "1", " ", " ", " ", " ", "1", " ", " ", " ", " ", " ", " ", " ", " ", "1", " ", " ", " ", " ", "1" },
            { "1", " ", "1", "1", " ", "1", " ", "1", "1", "1", "1", "1", "1", " ", "1", " ", "1", "1", " ", "1" },
            { "1", "0", "1", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "1", " ", "1" },
            { "1", " ", "1", " ", "1", "1", " ", "1", "1", " ", " ", "1", "1", " ", "1", "1", " ", "1", " ", "1" },
            { "1", " ", " ", " ", " ", " ", " ", "1", "X", " ", " ", " ", "1", " ", " ", " ", " ", " ", " ", "1" },
            { "1", " ", "1", " ", "1", "1", " ", "1", "1", "1", "1", "1", "1", " ", "1", "1", " ", "1", " ", "1" },
            { "1", " ", "1", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "0", " ", " ", " ", "1", " ", "1" },
            { "1", " ", "1", "1", "0", "1", " ", "1", "1", "1", "1", "1", "1", " ", "1", " ", "1", "1", " ", "1" },
            { "1", " ", " ", " ", " ", "1", " ", " ", " ", " ", " ", " ", " ", " ", "1", " ", " ", " ", " ", "1" },
            { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" }
        };

        private string[,] level2Map = new string[,]
        {
            { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" },
            { "1", " ", "1", " ", " ", " ", " ", " ", "1", " ", " ", " ", " ", " ", "1", " ", "0", "1" },
            { "1", "0", "1", " ", "1", " ", "1", " ", "1", " ", "1", "1", "1", " ", " ", " ", "1", "1" },
            { "1", " ", "1", "1", "1", " ", "1", " ", "1", "X", " ", " ", " ", " ", "1", " ", "1", "1" },
            { "1", " ", " ", " ", " ", " ", "1", " ", "1", " ", "1", "1", " ", " ", "1", " ", " ", "1" },
            { "1", " ", "1", "1", "1", " ", "1", " ", "1", " ", "1", " ", " ", " ", "1", " ", "1", "1" },
            { "1", " ", " ", " ", " ", " ", "1", " ", "1", " ", "1", " ", "1", " ", "1", " ", "1", "1" },
            { "1", " ", "1", "1", "1", " ", "1", " ", "1", " ", " ", " ", "1", " ", " ", " ", " ", "1" },
            { "1", " ", "1", "0", " ", " ", "1", " ", " ", " ", "1", "0", "1", " ", "1", " ", "1", "1" },
            { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" }
        };

        private string[,] level3Map = new string[,]
        {    
            {"1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1"},
            {"1", "X", " ", " ", " ", "1", " ", " ", " ", " ", " ", "1", " ", " ", " ", " ", " ", " ", "0", "1"},
            {"1", " ", "1", "1", " ", "1", " ", "1", "1", "1", " ", "1", " ", "1", "1", "1", " ", "1", " ", "1"},
            {"1", " ", "1", " ", "0", " ", " ", " ", " ", "1", " ", " ", " ", " ", " ", "1", " ", "1", " ", "1"},
            {"1", " ", "1", "1", "1", "1", "1", "1", " ", "1", "1", "1", "1", "1", " ", "1", " ", "1", " ", "1"},
            {"1", " ", " ", " ", "0", "1", " ", " ", " ", " ", " ", " ", " ", "1", " ", "1", " ", " ", " ", "1"},
            {"1", " ", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", " ", "1", " ", "1", "1", "1", " ", "1"},
            {"1", " ", "1", " ", "0", "1", " ", " ", " ", "1", " ", "1", " ", "1", " ", " ", " ", "1", " ", "1"},
            {"1", " ", "1", "1", " ", "1", "1", "1", " ", "1", " ", "1", "1", "1", "0", "1", "1", "1", " ", "1"},
            {"1", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "1"},
            {"1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1"}
    };

        private string[,] level4Map = new string[,]
        {
            { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" },
            { "1", "X", "0", " ", " ", "1", "0", " ", " ", " ", " ", "1", " ", " ", " ", " ", "0", " ", " ", "1" },
            { "1", " ", "1", "1", " ", "1", " ", "1", "1", "1", " ", "1", " ", "1", "1", "1", " ", "1", " ", "1" },
            { "1", " ", "1", " ", "0", " ", " ", " ", " ", "1", " ", " ", " ", " ", " ", "1", " ", "1", " ", "1" },
            { "1", " ", "1", "1", "1", "1", "1", "1", " ", "1", "1", "1", "1", "1", "0", "1", " ", "1", " ", "1" },
            { "1", " ", " ", " ", " ", "1", " ", " ", " ", " ", " ", " ", " ", "1", " ", "1", " ", " ", " ", "1" },
            { "1", " ", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", " ", "1", " ", "1", "1", "1", " ", "1" },
            { "1", " ", "1", " ", " ", "1", " ", "0", " ", "1", " ", "1", " ", "1", " ", " ", " ", "1", " ", "1" },
            { "1", " ", "1", "1", " ", "1", "1", "1", " ", "1", " ", "1", "1", "1", "0", "1", "1", "1", " ", "1" },
            { "1", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "1" },
            { "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" }
        };

}