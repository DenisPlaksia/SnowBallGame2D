using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private int _scoreToWin;
    public event Action<int> OnHealthChange;
    public event Action<int> OnScoreChange;

    private int _health = 3;
    
    public int Score { get; set; }

    public void HealthChange(int value)
    {
        _health -= value;
        OnHealthChange?.Invoke(_health);
        if (_health <= 0)
        {
            Death();
        }
    }
    public void AddScore(int value)
    {
        Score += value;
        OnScoreChange?.Invoke(Score);
        if(Score >= _scoreToWin)
        {
            Win();
        }
    }

    private void Win()
    {
        GameController.Game.WinGame(_health);
    }
    private void Death()
    {
        GameController.Game.LoseGame();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var collisionObject = collision.gameObject.GetComponent<SnowBall>();
        if (collisionObject != null)
        {
            collisionObject.gameObject.SetActive(false);
            HealthChange(1);
        }
    }
}
