﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    int score = 0;

    private void Awake()
    {
        SetUpSingleton();
    }

    //to make sure that only 1 GameSession is running
    private void SetUpSingleton()
    {
        int numberGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numberGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    //get the value of score
    public int GetScore()
    {
        return score;
    }

    //add scoreValue to score
    public void AddToScore(int scoreValue)
    {
        score += scoreValue;

        if (score >= 100)
        {
            SceneManager.LoadScene("YouWin");
        }
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
