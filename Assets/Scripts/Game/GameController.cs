﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _pauseGame;
    [SerializeField] private List<GameObject> _stars = new List<GameObject>();
    public static GameController Game;

    public void Awake()
    {
        Game = this;
    }

    public void Start()
    {
        Time.timeScale = 1;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void WinGame(int value)
    {
        Time.timeScale = 0;
        _stars[value].SetActive(true);
        _winPanel.SetActive(true);
    }

    public void LoseGame()
    {
        Time.timeScale = 0;
        _losePanel.SetActive(true);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        _pauseGame.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        _pauseGame.SetActive(false);
    }
}