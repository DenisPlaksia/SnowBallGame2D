using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthShow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _health;
    [SerializeField] private Player _player;

    private void Start()
    {
        _player.OnHealthChange += Show;    
    }

    private void Show(int value)
    {
        _health.SetText(value.ToString());
    }
}
