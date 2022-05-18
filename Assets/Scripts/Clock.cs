using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    [SerializeField] private int addHour;

    const float degreesPerHour = 30f;
    const float degreesPerMinute = 6f;
    const float degreesPerSecond = 6f;

    public Transform hoursTransform, minutesTransform, secondsTransform;

    public bool smooth;

    private void Awake()
    {
        DateTime time = DateTime.Now;
        TimeSpan timechange = new System.TimeSpan(addHour, 0, 0);
        DateTime setTime = time.Add(timechange);

        hoursTransform.localRotation = Quaternion.Euler(0f, setTime.Hour * degreesPerHour, 0f);

        minutesTransform.localRotation = Quaternion.Euler(0f, setTime.Minute * degreesPerMinute, 0f);

        secondsTransform.localRotation = Quaternion.Euler(0f, setTime.Second * degreesPerSecond, 0f);
    }

    private void Update()
    {
        if (smooth)
        {
            UpdateContinuousSmooth();
        }
        else
        {
            UpdateDiscription();
        }
    }

    void UpdateContinuousSmooth()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;

        hoursTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalHours * degreesPerHour, 0f);

        minutesTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalMinutes * degreesPerMinute, 0f);

        secondsTransform.localRotation = Quaternion.Euler(0f, (float)time.TotalSeconds * degreesPerSecond, 0f);
    }

    void UpdateDiscription()
    {
        DateTime time = DateTime.Now;
        TimeSpan timechange = new System.TimeSpan(addHour, 0, 0);
        DateTime setTime = time.Add(timechange);

        hoursTransform.localRotation = Quaternion.Euler(0f, setTime.Hour * degreesPerHour, 0f);

        minutesTransform.localRotation = Quaternion.Euler(0f, setTime.Minute * degreesPerMinute, 0f);

        secondsTransform.localRotation = Quaternion.Euler(0f, setTime.Second * degreesPerSecond, 0f);
    }

}
