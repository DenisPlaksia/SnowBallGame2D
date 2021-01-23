using UnityEngine;
using UnityEngine.UI;
using System;
public class ForceShowUI : MonoBehaviour
{
    private Image _forceImage;
    public float maxTime = 3f;
    private float _timeLeft = 0f;
    [SerializeField] private Button _button;


    public event Action<float> OnSnowPush;
    private void Start()
    {
        _forceImage = GetComponent<Image>();
        _button.onClick.AddListener(() => PressButton(_timeLeft));
    }

    private void Update()
    {
        if (_timeLeft < maxTime)
        {
            _timeLeft += Time.deltaTime;
            _forceImage.fillAmount = _timeLeft / maxTime;
        }
        else if (_timeLeft >= maxTime)
        {
            _timeLeft = 0f;
            _forceImage.fillAmount = _timeLeft;
        }
    }

    private void PressButton(float value)
    {
        OnSnowPush?.Invoke(value);
    }
}
