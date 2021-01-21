using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreShow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score;
    [SerializeField] private Player _player;

    private void Start()
    {
        _player.OnScoreChange += Show;
    }

    private void Show(int value)
    {
        _score.SetText(value.ToString());
    }
}
