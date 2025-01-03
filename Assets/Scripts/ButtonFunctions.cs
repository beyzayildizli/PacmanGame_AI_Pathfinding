/**
 * @file: ButtonFunctions.cs
 * @description: This script contains button functions for managing the game's flow.
 * @assignment: Pacman AI Pathfinding
 * @date: 11.12.2024
 * @author: Beyza Yıldızlı beyzayildizli10@gmail.com
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    [Header("References")]
    public Map mapScript; 
    public CharacterMovement characterMovement;
    public MapLists mapLists;
    public GameSounds gameSounds;
    public CalculateBestWay calculateBestWay;

    [Header("UI Elements")]
    public RectTransform introPanel;
    public RectTransform finishPanel;
    public Button replayButton;

    void Start(){
        finishPanel.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitGameButton();
        }
    }

    public void MoveBestWay()
    {
        characterMovement.moveActive = false;
        replayButton.gameObject.SetActive(false);
        gameSounds.PlayButtonClickSound();
        mapScript.CreateNewLevel(mapScript.level);
        string[,] map = mapScript.map;
        List<int[]> path = calculateBestWay.TotalBestWay(map, characterMovement.FindCharacterPosition(), mapScript.GetPointCoordinates(map));
        if (path != null)
        {
            StartCoroutine(characterMovement.MoveCharacterWithDelay(path));
        }
    }

    public void startGameButton(){
        gameSounds.StopOtherSounds();
        introPanel.gameObject.SetActive(false);
    playLevel(mapScript.level);
    }

    private void playLevel(int level){
        mapScript.CreateNewLevel(level);
        characterMovement.moveActive = true;
    }

    public void replayLevelButton(){
        gameSounds.PlayButtonClickSound();
        playLevel(mapScript.level);
    }

    public void playNextLevelButton(){
        gameSounds.PlayButtonClickSound();
        mapScript.level ++;
        if(mapLists.levelMaps.Count > mapScript.level){
            replayButton.gameObject.SetActive(true);
            playLevel(mapScript.level);
        } else{
            finishPanel.gameObject.SetActive(true);
            gameSounds.PlayFinalMusic();
        }
    }

    public void quitGameButton(){
        /*if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
            return;
        }*/
        Application.Quit();
    }
}