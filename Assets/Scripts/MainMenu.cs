﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainLevel";
    public SceneFader sceneFader;
    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
        Debug.Log("Play");
    }
    
    public void Quit ()
    {
        Debug.Log("Exiting....");
        Application.Quit();
    }
}
