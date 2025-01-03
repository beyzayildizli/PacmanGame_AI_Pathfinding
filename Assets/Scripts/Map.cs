/**
 * @file: Map.cs
 * @description: This script handles the creation, updating, and management of the game map. 
 * It sets up the grid layout, displays walls, points, and the character's position, and manages 
 * map updates such as removing points and moving the character. It also calculates the total 
 * number of points and retrieves their coordinates for pathfinding purposes.
 * @assignment: Pacman AI Pathfinding
 * @date: 11.12.2024
 * @author: Beyza Yıldızlı beyzayildizli10@gmail.com
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    [Header("MapList")]
    public MapLists mapList; 
    public CharacterMovement characterMovement; 
    public GameInfoManager gameManager;

    [Header("Raw Images for Map Components")]
    public RawImage wallImg;  
    public RawImage mapImg;   
    public RawImage characterImg;
    public RawImage pointImg;

    [Header("Map Grid Setup")]
    public RectTransform panel;
    private GameObject[,] cellGrid;

    [Header("Map Data")]
    public int level = 0;
    public string[,] map;
    private string[,] originalMap;

    [Header("Constants")]
    private const string CHARACTER = "X";
    private const string WALL = "1";
    private const string POINT = "0";

    public void CreateNewLevel(int level){
        gameManager.completionPanel.SetActive(false);
        gameManager.resultPanel.SetActive(false); 
        originalMap = mapList.levelMaps[level];
        map = (string[,])originalMap.Clone(); 
        CreateMap(map);
        UpdateCharacterImage(map);
        UpdatePointImages(map);
        gameManager.point = 0;
        gameManager.pointText.text = "Pac-man: 0";
        gameManager.totalPoint = CountTotalPoints();
        gameManager.remainingPoint =CountTotalPoints();
        gameManager.stepCount = 0;
        gameManager.stepText.text = "Step: 0";
    }

    private void CreateMap(string[,] map)
    {
        if (map == null)
        {
            return;
        }

        int rows = map.GetLength(0);
        int cols = map.GetLength(1);

        cellGrid = new GameObject[rows, cols];
        float panelWidth = panel.rect.width;
        float panelHeight = panel.rect.height;

        float cellSize = Mathf.Min(panelWidth / cols, panelHeight / rows);
        float centerX = (cols - 1) * cellSize / 2;
        float centerY = (rows - 1) * cellSize / 2;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject cellObj = new GameObject("MapCell_" + row + "_" + col);
                cellGrid[row, col] = cellObj;

                RectTransform rectTransform = cellObj.AddComponent<RectTransform>();
                rectTransform.sizeDelta = new Vector2(cellSize, cellSize);
                rectTransform.anchoredPosition = new Vector2(
                    col * cellSize - centerX,
                    -row * cellSize + centerY
                );

                RawImage rawImage = cellObj.AddComponent<RawImage>();

                if (map[row, col] == WALL)
                {
                    rawImage.texture = wallImg.texture;
                }
                else
                {
                    rawImage.texture = mapImg.texture;
                }

                cellObj.transform.SetParent(panel, false);
            }
        }
    }

    public void UpdatePointImages(string[,] map)
    {
        int rows = map.GetLength(0);
        int cols = map.GetLength(1);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                if (map[row, col] == POINT)
                {
                    bool pointExists = false;  
                    foreach (Transform child in cellGrid[row, col].transform)
                    {
                        if (child.name.StartsWith("Point"))  
                        {
                            pointExists = true; 
                            break;
                        }
                    }

                    if (!pointExists)
                    {
                        GameObject point = new GameObject("Point_" + row + "_" + col); 
                        RectTransform pointRect = point.AddComponent<RectTransform>();
                        pointRect.sizeDelta = cellGrid[row, col].GetComponent<RectTransform>().sizeDelta;
                        point.transform.SetParent(cellGrid[row, col].transform, false);

                        RawImage pointImage = point.AddComponent<RawImage>();
                        pointImage.texture = pointImg.texture;  
                    }
                }
            }
        }
    }

    public void UpdateCharacterImage(string[,] map)
    {
        int rows = map.GetLength(0);
        int cols = map.GetLength(1);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Transform cellTransform = cellGrid[row, col].transform;
                foreach (Transform child in cellTransform)
                {
                    if (child.name == "Character")
                    {
                        Destroy(child.gameObject);
                    }
                }
                if (map[row, col] == CHARACTER)
                {
                    GameObject character = new GameObject("Character");
                    RectTransform characterRect = character.AddComponent<RectTransform>();
                    characterRect.sizeDelta = cellGrid[row, col].GetComponent<RectTransform>().sizeDelta;
                    character.transform.SetParent(cellGrid[row, col].transform, false);

                    RawImage characterImage = character.AddComponent<RawImage>();
                    characterImage.texture = characterImg.texture;
                }
            }
        }
    }

    public void RemoveCharacterFromCell(int row, int col)
    {
        Transform cellTransform = cellGrid[row, col].transform;

        foreach (Transform child in cellTransform)
        {
            if (child.name == "Character")
            {
                Destroy(child.gameObject); 
                return; 
            }
        }
    }

    public void RemovePointFromCell(int row, int col)  
{
    Transform cellTransform = cellGrid[row, col].transform;

    foreach (Transform child in cellTransform)
    {
        if (child.name.StartsWith("Point"))  
        {
            Destroy(child.gameObject); 
            return; 
        }
    }
}

    public int CountTotalPoints()  
    {
        int totalPoints = 0;  
        for (int row = 0; row < map.GetLength(0); row++)
        {
            for (int col = 0; col < map.GetLength(1); col++)
            {
                if (map[row, col] == POINT) 
                {
                    totalPoints++;
                }
            }
        }
        return totalPoints;
    }

   public List<int[]> GetPointCoordinates(string[,] map) 
    {
        List<int[]> pointCoordinates = new List<int[]>();  

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (map[i, j] == POINT)  
                {
                    pointCoordinates.Add(new int[] { i, j });
                }
            }
        }
        return pointCoordinates;
    }
}