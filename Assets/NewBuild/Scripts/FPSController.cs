
using System;
using UnityEngine;
using UnityEngine.UI;

public class FPSController : MonoBehaviour
{
    public Text fpsText;
    private float _timerUpdateFps = 1;

    private void Start()
    {
        Application.targetFrameRate = 90;
    }

    private void Update()
    {
        if (_timerUpdateFps <= 0)
        {
            fpsText.text = $"fps:{(int)(1.0f / Time.unscaledDeltaTime)}";
            _timerUpdateFps = 2;
        }
        else
        {
            _timerUpdateFps -= Time.unscaledDeltaTime;
        }
    }
}
