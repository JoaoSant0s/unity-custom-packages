using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using JoaoSant0s.CommonWrapper;
using JoaoSant0s.Extensions.Strings;
using JoaoSant0s.Extensions.Numbers;
using JoaoSant0s.Extensions.Vectors;

public class TestDebugWrapper : MonoBehaviour
{
    [SerializeField]
    private Vector2Int elementsAmount;

    [SerializeField]
    private Vector2 elementsTime;

    [SerializeField]
    private Text[] texts;

    void Start()
    {
        texts[0].text = "Text".ToBold();
        texts[1].text = "Text".ToItalic();

        texts[2].text = "Text".ToModifiedColor(Color.red);
        texts[3].text = "Text".ToSize(50);

        var testDeg = 180;
        var testRad = Mathf.PI;

        Debugs.Log(testDeg.Deg2Rad(), testRad.Rad2Deg());
        Debugs.Log(elementsAmount.RandomInterval(), elementsTime.RandomInterval(), VectorWrapper.RandomVector2(2, 5), VectorWrapper.RandomVector2(2f, 5f));

        Debugs.Log(new int[3] { 5, 45, 81 });

        Debugs.DrawRectangle(new Vector2(10, 10), new Vector2(20, 20), 20);
        Debugs.DrawRectangle(new Vector2(-10, -10), -30, -20, Color.red, 20);

        Debugs.DrawRectangle(new Vector2(10, 10), new Vector2(20, 20), Color.green, 20, axisType: DrawAxisType.XZ);
        Debugs.DrawRectangle(new Vector2(-10, -10), -30, -20, Color.blue, 20, axisType: DrawAxisType.XZ);
    }
}
