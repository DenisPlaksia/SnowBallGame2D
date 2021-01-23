using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReloadGame : MonoBehaviour
{
    [SerializeField] private Button _reloadButton;

    private void Start()
    {
        _reloadButton.onClick.AddListener(Reload);
    }

    private void Reload()
    {
        GameController.Game.ReloadGame();
    }
}
