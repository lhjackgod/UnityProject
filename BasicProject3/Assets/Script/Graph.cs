using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform paraentPosition;
    [SerializeField, Range(10, 100)]
    int resolution = 10;
    Transform[] points;
    [SerializeField]
    FunctionLibrary.FUNCTIONNAMES function;
    private float step;
    private void Awake()
    {
        points = new Transform[resolution * resolution];

        step = 2.0f / (float)resolution;
        for (int i = 0; i < resolution * resolution; i++)
        {
            points[i] = Instantiate(paraentPosition);
            points[i].parent = this.transform;
            points[i].localScale = Vector3.one * step;
        }
    }
    private void Update()
    {
        FunctionLibrary.Funcation f = FunctionLibrary.get_function(function);
        float time = Time.time;
        float u, v = 0.5f * step - 1.0f;
        for(int i = 0, x = 0, z = 0; i < resolution * resolution; i++, x++)
        {
            if(x == resolution)
            {
                x = 0;
                z += 1;
                v = (z + 0.5f) * step - 1.0f;
            }
            u = (x + 0.5f) * step - 1.0f;
            points[i].localPosition = f(u, v, time);
        }
    }
}
