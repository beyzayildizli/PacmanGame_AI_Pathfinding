/**
 * @file: GameSounds.cs
 * @description: This script manages the game's audio, including background music and sound effects.
 * It handles playing and stopping various sounds. The script ensures only one sound is played at a time 
 * and provides methods to control audio during gameplay.
 * @assignment: Pacman AI Pathfinding
 * @date: 11.12.2024
 * @author: Beyza Yıldızlı beyzayildizli10@gmail.com
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSounds : MonoBehaviour
{
    [Header("AudioSource & AudioClips")]
    public AudioSource audioSource; 
    public AudioClip introMusic; 
    public AudioClip finalMusic;
    public AudioClip eatingSound;
    public AudioClip ghostStepSound;
    public AudioClip buttonClickSound; 

    void Start(){
        PlaySound(introMusic);
    }

    public void StopOtherSounds()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void PlayGhostStepSound()
    {
        if (audioSource.isPlaying && audioSource.clip == ghostStepSound)
        {
            audioSource.Stop();
        }
        PlaySound(ghostStepSound);
    }

    public void PlayEatingSound()
    {
        PlaySound(eatingSound);
    }
    public void PlayFinalMusic()
    {
        PlaySound(finalMusic);
    }
    public void PlayButtonClickSound()
    {
        PlaySound(buttonClickSound);
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
