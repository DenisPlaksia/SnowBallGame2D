using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private int _scoreToWin;
    public event Action<int> OnHealthChange;
    public event Action<int> OnScoreChange;

    private int _health = 3;

    private int _score = 0;
    public int Score
    {
        get => _score;
        set
        {
            if(value > 0)
            {
                _score += value;
                OnScoreChange?.Invoke(_score);
                if(_score >= _scoreToWin)
                {
                    Win();
                }
            }
        }
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

    private void Win() => GameController.Game.WinGame(_health);
    private void Death() => GameController.Game.LoseGame();

}
