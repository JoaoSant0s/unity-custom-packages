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

        //TestString();

        //TestBool();

        //TestDouble();
    }

    private void TestInt()
    {
        Debug.Log("");
        Debug.Log("TestInt");

        var testKey = "testIntUnit";        
        var mainValue = -1233311;

        saveService.Set<int>(testKey, -1233311);
        var value = saveService.Get<int>(testKey);

        Debug.Log(mainValue);
        Debug.Log(value);
        Debug.Log(mainValue == value);
    }

    private void TestFloat()
    {
        Debug.Log("");
        Debug.Log("TestFloat");

        var testKey = "testFloatUnit";
        var mainValue = -1151.201555f;

        saveService.Set<float>(testKey, mainValue);
        var value = saveService.Get<float>(testKey);

        Debug.Log(mainValue);
        Debug.Log(value);
        Debug.Log(mainValue == value);
    }

    private void TestString()
    {
        Debug.Log("");
        Debug.Log("TestString");

        var testKey = "testStringUnit";
        var mainValue = "testing the value";

        saveService.Set<string>(testKey, mainValue);
        var value = saveService.Get<string>(testKey);

        Debug.Log(mainValue);
        Debug.Log(value);
        Debug.Log(mainValue == value);
    }

    private void TestBool()
    {
        Debug.Log("");
        Debug.Log("TestBool");

        var testKey = "testBoolUnit";
        var mainValue = true;

        saveService.Set<bool>(testKey, mainValue);
        var value = saveService.Get<bool>(testKey);

        Debug.Log(mainValue);
        Debug.Log(value);
        Debug.Log(mainValue == value);    
    }

    private void TestDouble()
    {
        Debug.Log("");
        Debug.Log("TestDouble");

        var testKey = "testDoubleUnit";
        var mainValue = 155151515d;

        saveService.Set<double>(testKey, mainValue);
        var value = saveService.Get<double>(testKey);

        Debug.Log(mainValue);
        Debug.Log(value);
        Debug.Log(mainValue == value);    
    }
}

