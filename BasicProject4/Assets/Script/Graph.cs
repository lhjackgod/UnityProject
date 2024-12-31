using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    [SerializeField]
    Transform obj;
    [SerializeField, Range(10, 100)]
    int resolution = 10;
    [SerializeField]
    FunctionLibrary.FUCNTIONTYPE functionType = FunctionLibrary.FUCNTIONTYPE.Wave;
    [SerializeField, Min(0f)]
    float functionDuraion = 1f, translationDuration = 1f;
    private float step;
    Transform[] objections;
    float durationTime = 0.0f;
    FunctionLibrary.FUCNTIONTYPE fromFunctionType;
    FunctionLibrary.FUCNTIONTYPE toFunctionType;
    private void Awake()
    {
        step = 2.0f / resolution;
        objections = new Transform[resolution * resolution];
        for(int i = 0; i < resolution * resolution; i++)
        {
            objections[i] = Instantiate(obj);
            objections[i].SetParent(this.transform);
            objections[i].localScale = Vector3.one * step;
        }
        fromFunctionType = functionType;
        toFunctionType = functionType;
    }

    private void Update()
    {
        durationTime += Time.deltaTime;
        if(durationTime >= functionDuraion)
        {
            durationTime -= functionDuraion;
            fromFunctionType = toFunctionType;
            toFunctionType = (FunctionLibrary.FUCNTIONTYPE) FunctionLibrary.getFunctionName((int)fromFunctionType);
        }
        updateFunction();
    }
    private void updateFunction()
    {
        float u, v = (0.5f + 0f) * step - 1.0f;
        float time = Time.time;
        for(int i = 0, x = 0, z = 0; i < resolution * resolution; i++,x++)
        {
            if(x == resolution)
            {
                x = 0;
                z++;
                v = (0.5f + z) * step - 1.0f;
            }
            u = (0.5f + x) * step - 1.0f;
            objections[i].localPosition = FunctionLibrary.Morph(u, v, time, FunctionLibrary.getFunction((int)fromFunctionType),
                FunctionLibrary.getFunction((int)toFunctionType), durationTime / translationDuration);
        }
    }
}
