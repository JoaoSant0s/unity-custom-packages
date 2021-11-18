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
        var testIntUnit = "testIntUnit";
        var testFloatUnit = "testFloatUnit";
        var testStringUnit = "testStringUnit";
        var testBoolUnit = "testBoolUnit";
        var testVector3Unit = "testVector3Unit";

        saveService.Set<int>(testIntUnit, -11);
        Debug.Log(saveService.Get<int>(testIntUnit));

        saveService.Set<float>(testFloatUnit, -11.2031265f);
        Debug.Log(saveService.Get<float>(testFloatUnit));

        saveService.Set<string>(testStringUnit, "testStringUnit");
        Debug.Log(saveService.Get<string>(testStringUnit));

        saveService.Set<bool>(testBoolUnit, true);
        Debug.Log(saveService.Get<bool>(testBoolUnit));

        Debug.Log(saveService.GetOrDefault<Vector3>("noValue", Vector3.zero));
        
        saveService.Set<Vector3>(testVector3Unit, new Vector3(1.0001f, -11.0001f, -11.2031201f));
        var value = saveService.Get<Vector3>(testVector3Unit);
        Debug.Log(value);
        transform.Translate(value);
    }
}

