using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointTransform;
    [SerializeField, Range(10, 100)]
    int resolution = 10;
    Transform[] points;
    private void Awake()
    {
        points = new Transform[resolution];
        float step = 2.0f / (float)resolution;
        Vector3 position = Vector3.zero;
        for(int i = 0; i < points.Length; i++)
        {
            Transform clonePosition = points[i] = Instantiate(pointTransform);
            clonePosition.SetParent(transform);
            position.x = (i + 0.5f) * step - 1.0f;
            clonePosition.localPosition = position;
            clonePosition.localScale = Vector3.one * step;
        }
    }
    private void Update()
    {
        float time = Time.time;
        for(int i = 0; i < points.Length; i++)
        {
            Transform clonePoint = points[i];
            Vector3 position = clonePoint.localPosition;
            position.y = Mathf.Sin(Mathf.PI * (position.x + time));
            clonePoint.localPosition = position;
        }
    }
}
