using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform pointTransform;
    [SerializeField, Range(10, 100)]
    int resolution = 10;
    private void Awake()
    {
        float step = 2.0f / (float)resolution;
        Vector3 position = Vector3.zero;
        for(int i = 0; i < resolution; i++)
        {
            Transform clonePosition = Instantiate(pointTransform);
            clonePosition.SetParent(transform);
            position.x = (i + 0.5f) * step - 1.0f;
            position.y = position.x * position.x;
            clonePosition.localPosition = position;
            clonePosition.localScale = Vector3.one * step;
        }
    }
}
