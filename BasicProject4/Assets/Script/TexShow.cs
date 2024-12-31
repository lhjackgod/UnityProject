using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class TexShow : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI texGUI;
    private enum DISPLAYMODE { FPS, MS};
    [SerializeField]
    DISPLAYMODE displayMode = DISPLAYMODE.FPS;
    [SerializeField, Range(0.1f, 1.0f)]
    float sampleTimes = 0.1f;
    private int frames = 0;
    private float durationTimes = 0f;
    private float bestDurationTime = float.MaxValue;
    private float worseDurationTime = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float durationTime = Time.unscaledDeltaTime;
        bestDurationTime = bestDurationTime < durationTime ? bestDurationTime : durationTime;
        worseDurationTime = worseDurationTime < durationTime ? durationTime : worseDurationTime;
        frames++;
        durationTimes += durationTime;
        if(durationTimes > sampleTimes)
        {
            if(displayMode == DISPLAYMODE.FPS)
            {
                texGUI.SetText("FPS\n{0:0}\n{1:0}\n{2:0}", frames / durationTimes, 1f / bestDurationTime, 1f / worseDurationTime);
            }

            else
            {
                texGUI.SetText("MS\n{0:0}\n{1:0}\n{2:0}", 1000f * (frames / durationTimes),
                    1000f * bestDurationTime,
                    1000f * worseDurationTime);
            }
            durationTimes = 0f;
            frames = 0;
            bestDurationTime = float.MaxValue;
            worseDurationTime = 0f;
        }
        
    }
}
