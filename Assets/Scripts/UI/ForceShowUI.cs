using UnityEngine;
using UnityEngine.UI;
using System;
public class ForceShowUI : MonoBehaviour
{
    private Image _forceImage;
    public float maxTime = 3f;
    private float timeLeft = 0f;
    [SerializeField] private Button button;


    public event Action<float> OnSnowPush;
    private void Start()
    {
        _forceImage = GetComponent<Image>();
        button.onClick.AddListener(() => PressButton(timeLeft));
    }

    private void Update()
    {
        if (timeLeft < maxTime)
        {
            timeLeft += Time.deltaTime;
            _forceImage.fillAmount = timeLeft / maxTime;
        }
        else if (timeLeft >= maxTime)
        {
            timeLeft = 0f;
            _forceImage.fillAmount = timeLeft;
        }
    }

    private void PressButton(float value)
    {
        OnSnowPush?.Invoke(value);
    }
}
