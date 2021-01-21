using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timer;


    private void Update()
    {
        _timer.SetText((Mathf.Round(Time.timeSinceLevelLoad)).ToString());
    }
}
