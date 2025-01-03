/**
 * @file: CharacterMovement.cs
 * @description: This script handles the movement of the character. The character moves based 
 * on user input and the game logic, updating its position on the map and interacting with
 * points and walls. It also manages the game state, such as step count and point collection,
 * while triggering appropriate sound effects and UI updates.
 * @assignment: Pacman AI Pathfinding
 * @date: 11.12.2024
 * @author: Beyza Yıldızlı beyzayildizli10@gmail.com
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class CharacterMovement : MonoBehaviour
{
    [Header("References")]
    public Map mapScript; 
    public string[,] map; 
    public GameInfoManager gameManager;
    public ScoreLists scoreLists;
    public GameSounds gameSounds;

    [Header("Character Position")]
    public int currentRow; 
    public int currentCol; 

    [Header("Constants")]
    private const string CHARACTER = "X"; 
    private const string WALL = "1"; 
    private const string POINT = "0";
    private const string EMPTY = " ";
    public bool moveActive = false;

    void Update()
    {
        if (moveActive)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                int[] position = FindCharacterPosition();
                if (position != null) MoveCharacter(position[0] - 1, position[1], 0); 
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                int[] position = FindCharacterPosition();
                if (position != null) MoveCharacter(position[0], position[1] - 1, 0); 
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                int[] position = FindCharacterPosition();
                if (position != null) MoveCharacter(position[0] + 1, position[1], 0); 
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                int[] position = FindCharacterPosition();
                if (position != null) MoveCharacter(position[0], position[1] + 1, 0); 
            }
        }
    }


    public int[] FindCharacterPosition()
    {
        map = mapScript.map;
        if (map == null)
        {
            return null;
        }

        for (int row = 0; row < map.GetLength(0); row++)
        {
            for (int col = 0; col < map.GetLength(1); col++)
            {
                if (map[row, col] == CHARACTER)
                {
                    currentRow = row;
                    currentCol = col;
                    return new int[] { currentRow, currentCol };
                }
            }
        }
        Debug.LogError("Haritada 'X' değeri bulunamadı!");
        return null;
    }

    public string MoveCharacter(int row, int col, int situation)
    {
        if (row < 0 || col < 0 || row >= mapScript.map.GetLength(0) || col >= mapScript.map.GetLength(1))
        {
            Debug.LogError("Geçersiz konum!");
            return "Geçersiz konum!";
        }

        if (mapScript.map[row, col] == WALL)
        {
            return "Burası duvar";
        }
        else if (mapScript.map[row, col] == POINT || mapScript.map[row, col] == EMPTY)
        {
            gameManager.stepCount += 1;
            gameSounds.PlayGhostStepSound();
            gameManager.UpdateStepText(); 

            if (mapScript.map[row, col] == POINT)
            {
                gameSounds.PlayEatingSound();
                mapScript.RemovePointFromCell(row, col);
                gameManager.point += 1;
                gameManager.remainingPoint--;
                gameManager.UpdatePointText(); 
                if (gameManager.remainingPoint == 0)
                {
                    if (situation == 0){
                        moveActive = false;
                        scoreLists.SetUserStep();
                        gameManager.completionPanel.SetActive(true); 
                        scoreLists.UpdateLevelUI(mapScript.level);
                    }else{
                        scoreLists.SetMinStep();
                        gameManager.resultPanel.SetActive(true); 
                        scoreLists.UpdateLevelUI(mapScript.level);
                    }
                }
            }

            mapScript.map[row, col] = CHARACTER;
            mapScript.map[currentRow, currentCol] = EMPTY; 
            mapScript.RemoveCharacterFromCell(currentRow, currentCol);
            currentRow = row;
            currentCol = col;

            mapScript.UpdatePointImages(mapScript.map);
            mapScript.UpdateCharacterImage(mapScript.map);

            return "Karakter hareket etti";
        }
        return "Bilinmeyen durum!";
    } 

    public IEnumerator MoveCharacterWithDelay(List<int[]> path)
    {
        foreach (int[] step in path)
        {
            MoveCharacter(step[0], step[1], 1);
            yield return new WaitForSeconds(0.3f); 
        }
    }
}