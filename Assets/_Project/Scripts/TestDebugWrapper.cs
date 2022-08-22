using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using JoaoSant0s.CommonWrapper;
using JoaoSant0s.Extensions.Strings;
using JoaoSant0s.Extensions.Numbers;
using JoaoSant0s.Extensions.Vectors;
using JoaoSant0s.Extensions.Collections;
using JoaoSant0s.ServicePackage.Console;

public class TestDebugWrapper : MonoBehaviour
{
    [SerializeField]
    private Vector2Int elementsAmount;

    [SerializeField]
    private Vector2 elementsTime;

    [SerializeField]
    private Text[] texts;

    [SerializeField]
    private Text consoleText;

    private ConsoleManager console;

    void Start()
    {
        console = ConsoleManager.Instance;
        console.OnLogAdded += OnLogAdded;

        var asset = TesteScriptableObject.Get();
        Debug.Log(asset);
        asset = TesteScriptableObject.Get();
        Debug.Log(asset);

        texts[0].text = "Text".ToBold();
        texts[1].text = "Text".ToItalic();

        texts[2].text = "Text".ToModifiedColor(Color.red);
        texts[3].text = "Text".ToSize(50);

        var testDeg = 180;
        var testRad = Mathf.PI;

        Debug.Log("Mathfs Start");

        Debugs.Log("Eerp", 2, 8, Mathfs.Eerp(2, 8, 0.5f));
        Debugs.Log("InverseEerp", 2, 8, Mathfs.InverseEerp(2, 8, 4));

        Debugs.Log("Lerp", 2, 8, Mathf.Lerp(2, 8, 0.5f));
        Debugs.Log("InverseLerp", 2, 8, Mathf.InverseLerp(2, 8, 4));

        console.StopProcessing();

        Debugs.Log("Sum", Mathfs.Sum(2, 4, 6, 8));
        Debugs.Log("Product", Mathfs.Product(2, 4, 6, 8));
        Debugs.Log("Avarage", Mathfs.Avarage(2, 4, 6, 8));

        Debug.Log("Mathfs End");

        Debugs.Log(testDeg.Deg2Rad(), testRad.Rad2Deg());
        Debugs.Log(elementsAmount.RandomInterval(), elementsTime.RandomInterval(), VectorWrapper.RandomVector2(2, 5), VectorWrapper.RandomVector2(2f, 5f));
        var array = new int[4] { 5, 45, 81, 32 };
        var list = new List<int>() { 5, 45, 81, 32 };
        var dictionary = new Dictionary<int, string>();

        dictionary.Add(0, "a");
        dictionary.Add(2, "b");
        dictionary.Add(3, "c");

        console.ResumeProcessing();

        Debugs.Log(array);
        Debugs.Log(array.Random());

        Debugs.Log(list);
        Debugs.Log(list.Random());

        Debugs.Log(array.ToSubsetArray(1));
        Debugs.Log(list.ToSubsetList(1, 3));
        Debugs.Log(dictionary.ToSubsetArray(1));

        Debugs.DrawRectangle(new Vector2(10, 10), new Vector2(20, 20), 20);
        Debugs.DrawRectangle(new Vector2(-10, -10), -30, -20, Color.red, 20);

        Debugs.DrawRectangle(new Vector2(10, 10), new Vector2(20, 20), Color.green, 20, axisType: DrawAxisType.XZ);
        Debugs.DrawRectangle(new Vector2(-10, -10), -30, -20, Color.blue, 20, axisType: DrawAxisType.XZ);
    }

    private void OnLogAdded(LogObject log)
    {
        consoleText.text += $"{log.type.ToString()} - {log.logString} \n\n";
    }
}
