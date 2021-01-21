using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private int _health = 3;
    private int _score;
    [SerializeField] private int scoreToWin;
    public event Action<int> OnHealthChange;
    public event Action<int> OnScoreChange;
    private void Start()
    {
        
    }

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
        _score += value;
        OnScoreChange?.Invoke(_score);
        if(_score >= scoreToWin)
        {
            Win();
        }
    }

    private void Win()
    {
        Debug.Log("WIN");
    }
    private void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<SnowBall>() != null)
        {
            collision.gameObject.SetActive(false);
            HealthChange(1);
        }
    }
}
