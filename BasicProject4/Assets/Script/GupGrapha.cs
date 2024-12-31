using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GupGrapha : MonoBehaviour
{
    ComputeBuffer m_ComputeBuffer;
    [SerializeField]
    ComputeShader m_ComputeShader;
    [SerializeField, Range(10, 100)]
    int resolution = 10;
    [SerializeField]
    Material m_Material;
    [SerializeField]
    Mesh m_Mesh;
    static readonly int
        positionID = Shader.PropertyToID("_Positions"),
        resolutionID = Shader.PropertyToID("_Resolution"),
        stepID = Shader.PropertyToID("_step"),
        timeID = Shader.PropertyToID("Time");
    void UpdateFunctionOnGPU()
    {
        float step = 2f / resolution;
        m_ComputeShader.SetInt(resolutionID, resolution);
        m_ComputeShader.SetFloat(stepID, step);
        m_ComputeShader.SetFloat(timeID, Time.time);
        m_ComputeShader.SetBuffer(0, positionID, m_ComputeBuffer);

        int groups = Mathf.CeilToInt(resolution / 8f);
        m_ComputeShader.Dispatch(0, groups, groups, 1);
    }

    private void OnEnable()
    {
        m_ComputeBuffer = new ComputeBuffer(resolution * resolution, 3 * 4);
    }
    private void OnDisable()
    {
        m_ComputeBuffer.Release();
        m_ComputeBuffer = null;
    }
    private void Update()
    {
        UpdateFunctionOnGPU();
        Bounds bound = new Bounds(Vector3.zero, Vector3.one * (2.0f + 2.0f / resolution));
        Graphics.DrawMeshInstancedProcedural(m_Mesh, 0, m_Material, bound, m_ComputeBuffer.count);
    }
}
