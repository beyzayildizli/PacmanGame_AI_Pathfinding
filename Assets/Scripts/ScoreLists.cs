/**
 * @file: ScoreLists.cs
 * @description: This script tracks and calculates the user's performance
 * per level in the game, including steps taken, minimum steps, and score calculations. 
 * It updates the UI elements to display level-specific data.
 * @assignment: Pacman AI Pathfinding
 * @date: 11.12.2024
 * @author: Beyza Yıldızlı beyzayildizli10@gmail.com
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLists : MonoBehaviour
{
    [Header("References")]
    public Map mapScript; 
    public MapLists mapLists;
    public GameInfoManager gameManager;

    [Header("UI Elements")]
    public TextMeshProUGUI userStepText;
    public TextMeshProUGUI minStepText;
    public TextMeshProUGUI scoreText;

    private int numberOfLevels;
    private List<LevelData> levels;
    
    [System.Serializable]
    public class LevelData
    {
        public int userStep;   
        public int minStep;   
        public int score;     
    }

    void Start()
    {
        numberOfLevels = mapLists.levelMaps.Count;
        levels = new List<LevelData>();

        for (int i = 0; i < numberOfLevels; i++)
        {
            LevelData level = new LevelData
            {
                userStep = 0,
                minStep = 0,
                score = 0
            };

            levels.Add(level);
        }
    }
    public void SetUserStep()
    {
        int levelIndex = mapScript.level;
        int steps = gameManager.stepCount;
        if (IsValidLevelIndex(levelIndex))
        {
            levels[levelIndex].userStep = steps;
        }
    }

    public void SetMinStep()
    {
        int levelIndex = mapScript.level;
        int steps = gameManager.stepCount;
        if (IsValidLevelIndex(levelIndex))
        {
            levels[levelIndex].minStep = steps;
        }
        SetScore(levelIndex);
    }

    public void SetScore(int levelIndex)
    {
        if (IsValidLevelIndex(levelIndex))
        {
            int userStep = levels[levelIndex].userStep;
            int minStep = levels[levelIndex].minStep; 

            if (minStep > 0) 
            {
                int stepDifference = userStep - minStep;
                float penaltyRate = 100f / minStep; 
                float score = Mathf.Max(0, 100 - stepDifference * penaltyRate);
                levels[levelIndex].score = Mathf.RoundToInt(score);
            }
            else
            {
                Debug.LogError("Minimum adım sayısı sıfır olamaz!");
            }
        }
    }

    private bool IsValidLevelIndex(int levelIndex)
    {
        return levelIndex >= 0 && levelIndex < levels.Count;
    }

    public LevelData GetLevelData(int levelIndex)
    {
        if (IsValidLevelIndex(levelIndex))
        {
            return levels[levelIndex];
        }
        else
        {
            return null;
        }
    }

    public void UpdateLevelUI(int levelIndex)
    {
        if (IsValidLevelIndex(levelIndex))
        {
            LevelData levelData = levels[levelIndex];

            if (userStepText != null)
            {
                userStepText.text = $"User Steps: {levelData.userStep}";
            }

            if (minStepText != null)
            {
                minStepText.text = $"Min Steps: {levelData.minStep}";
            }

            if (scoreText != null)
            {
                scoreText.text = $"Score: {levelData.score}";
            }
        }
        else
        {
            Debug.LogError("Geçersiz seviye indeksi!");
        }
    }
}
