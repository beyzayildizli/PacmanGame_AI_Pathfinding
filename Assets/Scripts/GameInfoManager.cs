/**
 * @file: GameInfoManager.cs
 * @description: This script manages the game's UI updates for step count and points. 
 * It handles the tracking of steps, collected points, and the remaining points, 
 * along with controlling the appearance of completion and result panels.
 * @assignment: Pacman AI Pathfinding
 * @date: 11.12.2024
 * @author: Beyza Yıldızlı beyzayildizli10@gmail.com
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameInfoManager : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject completionPanel;
    public GameObject resultPanel;
    public TextMeshProUGUI stepText;
    public TextMeshProUGUI pointText;

    [Header("Point and Step Info")]
    public int totalPoint;
    public int remainingPoint;
    public int point;
    public int stepCount;

    // Initializes the game with the given total point count
    public void InitializeGame(int totalPointCount)
    {
        totalPoint = totalPointCount;
        remainingPoint = totalPoint;
        point = 0;
        stepCount = 0;

        UpdateStepText();
        UpdatePointText();
    }

    // Adds a step and updates the step text
    public void AddStep()
    {
        stepCount++;
        UpdateStepText();
    }

    // Increments the collected points and checks for completion
    public void CollectPoint()
    {
        point++;
        remainingPoint--;

        UpdatePointText();

        if (remainingPoint == 0)
        {
            ShowCompletionPanel();
        }
    }

    // Updates the step text on the UI
    public void UpdateStepText()
    {
        stepText.text = "Step: " + stepCount;
    }

    // Updates the point text on the UI
    public void UpdatePointText()
    {
        pointText.text = "Pac-man: " + point;
    }

    // Shows the completion panel when the game ends
    private void ShowCompletionPanel()
    {
        completionPanel.SetActive(true);
    }
}

