using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform paraentPosition;
    [SerializeField, Range(10, 100)]
    int resolution = 10;
    Transform[] points;
    private void Awake()
    {
        points = new Transform[resolution];
        float step = 2.0f / (float)resolution;
        for(int i = 0; i < resolution; i++)
        {
            points[i] = Instantiate(paraentPosition);
            Vector3 position = Vector3.zero;
            position.x = (i + 0.5f) * step - 1.0f;
            points[i].localPosition = position;
            points[i].localScale = Vector3.one * step;
        }
    }
    private void Update()
    {
        float time = Time.time;
        for(int i = 0; i < resolution; i++)
        {
            Vector3 position = points[i].localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + time));
            points[i].localPosition = position;
        }
    }
}
