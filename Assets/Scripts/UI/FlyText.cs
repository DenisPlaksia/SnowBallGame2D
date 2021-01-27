using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlyText : MonoBehaviour
{
    private TextMeshProUGUI _textFly;
    private Animation _animation;
    private const string FlyAnimationName = "FlyText";
    private List<string> _message = new List<string>()
    {
        "Good",
        "Nice",
        "Perfect",
        "Super",
    };

    private void Awake()
    {
        _textFly = GetComponent<TextMeshProUGUI>();
        _animation = GetComponent<Animation>();
    }

    private void Update()
    {
        if(_animation.isPlaying == false)
        {
            gameObject.SetActive(false);
        }
    }

    public void PlayAnimation()
    {
        _animation.Play(FlyAnimationName);
        TextSet(_message[Random.Range(0, _message.Count)]);
    }

    public void TextSet(string message)
    {
        _textFly.SetText(message);
    }
}
