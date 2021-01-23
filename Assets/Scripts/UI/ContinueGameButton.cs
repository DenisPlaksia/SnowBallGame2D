using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueGameButton : MonoBehaviour
{
    [SerializeField] private Button _continueButton;

    // Start is called before the first frame update
    void Start()
    {
        _continueButton.onClick.AddListener(Continue);
    }

    private void Continue()
    {
        GameController.Game.ResumeGame();
    }
}
