using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JoaoSant0s.ServicePackage.Save;
using JoaoSant0s.ServicePackage.General;

public class TestSaveService : MonoBehaviour
{
    private SaveService saveService;

    private void Awake() 
    {
        saveService = Services.Get<SaveService>();
    }

    private void Start() 
    {
        //TestInt();

        //TestFloat();

        TestString();

        //var testBoolUnit = "testBoolUnit";
        //var testVector3Unit = "testVector3Unit";

        //saveService.Set<string>(testStringUnit, "testStringUnit");
        //Debug.Log(saveService.Get<string>(testStringUnit));

        //saveService.Set<bool>(testBoolUnit, true);
        //Debug.Log(saveService.Get<bool>(testBoolUnit));

        //Debug.Log(saveService.GetOrDefault<Vector3>("noValue", Vector3.zero));
        
        //saveService.Set<Vector3>(testVector3Unit, new Vector3(1.0001f, -11.0001f, -11.2031201f));
        //var value = saveService.Get<Vector3>(testVector3Unit);
        //Debug.Log(value);
        //transform.Translate(new Vector3(value, value, value));
    }

    private void TestInt()
    {
        Debug.Log("");
        Debug.Log("TestInt");

        var testIntUnit = "testIntUnit";        
        var mainValue = -1233311;

        saveService.Set<int>(testIntUnit, -1233311);
        var value = saveService.Get<int>(testIntUnit);

        Debug.Log(mainValue);
        Debug.Log(value);
        Debug.Log(mainValue == value);
    }

    private void TestFloat()
    {
        Debug.Log("");
        Debug.Log("TestFloat");

        var testFloatUnit = "testFloatUnit";
        var mainValue = -1151.201555f;

        saveService.Set<float>(testFloatUnit, mainValue);
        var value = saveService.Get<float>(testFloatUnit);

        Debug.Log(mainValue);
        Debug.Log(value);
        Debug.Log(mainValue == value);
    }

    private void TestString()
    {
        Debug.Log("");
        Debug.Log("TestString");

        var testStringUnit = "testStringUnit";
        var mainValue = "testing the value";

        saveService.Set<string>(testStringUnit, mainValue);
        var value = saveService.Get<string>(testStringUnit);

        Debug.Log(mainValue);
        Debug.Log(value);
        Debug.Log(mainValue == value);
    }
}

