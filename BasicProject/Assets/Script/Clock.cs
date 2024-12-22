using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour {
    [SerializeField]
    Transform hourPrivot, minutePrivot, secondPrivot;
    private void Awake()
    {
        System.TimeSpan time = System.DateTime.Now.TimeOfDay;
        float eularHour = ((float)time.TotalHours % 12.0f) / 12.0f * 360.0f;
        float eularMinute = ((float)time.TotalMinutes % 60.0f) / 60.0f * 360.0f;
        float eularSeconds = ((float)time.TotalSeconds % 60f) / 60.0f * 360.0f;
        hourPrivot.localRotation = Quaternion.Euler(0.0f, -eularHour, 0.0f);
        minutePrivot.localRotation = Quaternion.Euler(0.0f, -eularMinute, 0.0f);
        secondPrivot.localRotation = Quaternion.Euler(0.0f, -eularSeconds, 0.0f);
    }
    private void Update()
    {
        System.TimeSpan time = System.DateTime.Now.TimeOfDay;
        float eularHour = ((float)time.TotalHours % 12.0f) / 12.0f * 360.0f;
        float eularMinute = ((float)time.TotalMinutes % 60.0f) / 60.0f * 360.0f;
        float eularSeconds = ((float)time.TotalSeconds % 60f) / 60.0f * 360.0f;
        hourPrivot.localRotation = Quaternion.Euler(0.0f, -eularHour, 0.0f);
        minutePrivot.localRotation = Quaternion.Euler(0.0f, -eularMinute, 0.0f);
        secondPrivot.localRotation = Quaternion.Euler(0.0f, -eularSeconds, 0.0f);
    }
}
