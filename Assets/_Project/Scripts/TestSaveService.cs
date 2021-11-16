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
        Debug.Log(saveService.Contains("test"));
    }
}
