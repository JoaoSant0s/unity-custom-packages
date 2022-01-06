using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.CommonWrapper;

public class TestDebugWrapper : MonoBehaviour
{

    void Start()
    {
        Debugs.LogColor("TestIntArray", Color.green);

        Debugs.Log(new int[3] { 5, 45, 81 });

        Debugs.DrawRectangle(new Vector2(10, 10), new Vector2(20, 20), 20);
        Debugs.DrawRectangle(new Vector2(-10, -10), -30, -20, Color.red, 20);

        Debugs.DrawRectangle(new Vector2(10, 10), new Vector2(20, 20), Color.green, 20, axisType: DrawAxisType.XZ);
        Debugs.DrawRectangle(new Vector2(-10, -10), -30, -20, Color.blue, 20, axisType: DrawAxisType.XZ);
    }
}
