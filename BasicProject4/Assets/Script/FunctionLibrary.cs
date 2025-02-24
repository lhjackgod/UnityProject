using UnityEngine;
using static System.MathF;
public static class FunctionLibrary
{
    public delegate Vector3 Function(float u, float v, float t);
    public enum FUCNTIONTYPE
    {
        Wave, MultiWave, Sphere, Torus
    }
    public static Vector3 Wave(float u, float v, float t)
    {
        Vector3 p = new Vector3(u, 0, v);
        p.y = Sin(PI * (u + v + t));
        return p;
    }

    public static Vector3 MultiWave(float u, float v, float t)
    {
        Vector3 p = new Vector3(u, 0, v);
        p.y = Sin(PI * (u + 0.5f + t));
        p.y += Sin(2.0f * PI * (v + t)) * 0.5f;
        p.y += Sin(PI * (u + v + 0.25f * t));
        return p;
    }

    public static Vector3 Ripple(float u, float v, float t)
    {
        Vector3 p;
        p.x = u;
        p.z = v;
        float d = Sqrt(u * u + v * v);
        p.y = Sin(PI * (4f * d - t));

        return p;
    }

    public static Vector3 Sphere(float u, float v, float t)
    {
        float r = 0.9f + 0.1f * Sin(PI * (6f * u + 4f * v + t));//total sphere r 0, 1
        float s = r * Cos(0.5f * PI * v); //bottom cycle
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r * Sin(PI * 0.5f * v);
        p.z = s * Cos(PI * u);
        return p;
    }

    public static Vector3 Torus(float u, float v, float t)
    {
        float r1 = 0.7f + 0.1f * Sin(PI * (6f * u + 0.5f * t));
        float r2 = 0.15f + 0.05f * Sin(PI * (8f * u + 4f * v + 2f * t));
        float s = r1 + r2 * Cos(PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r2 * Sin(PI * v);
        p.z = s * Cos(PI * u);
        return p;
    }

    private static Function[] functions = new Function[] { Wave, MultiWave, Sphere, Torus };
    public static Function getFunction(int index)
    {
        return functions[index];
    }

    public static int getFunctionName(int index)
    {
        return (index + 1) % functions.Length;
    }

    public static Vector3 Morph(float u, float v, float t, Function from,
        Function to, float progress)
    {
        return Vector3.Lerp(from(u, v, t), to(u, v, t), progress);
    }
}