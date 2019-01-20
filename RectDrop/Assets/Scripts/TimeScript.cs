using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    private float maxTime;
    private float currentTime;
    public Image timeImage;

    public void StartClock(float _maxTime)
    {
        maxTime = _maxTime;
        currentTime = _maxTime;
        timeImage.fillAmount = 1.0f;
    }

    public bool UpdateClock(float deltaTime)
    {
        currentTime -= deltaTime;
        timeImage.fillAmount = Mathf.Max(currentTime / maxTime, 0);

        if (currentTime > 0)
            return true;
        return false;
    }

    public void AddTime(float deltaTime)
    {
        currentTime = Mathf.Min(currentTime + deltaTime, maxTime);
        timeImage.fillAmount = Mathf.Max(currentTime / maxTime, 0);
    }
}
