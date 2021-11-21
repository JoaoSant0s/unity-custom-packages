using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using JoaoSant0s.ServicePackage.Save;
using JoaoSant0s.ServicePackage.General;
using JoaoSant0s.CommonWrapper;

public class TestSaveService : MonoBehaviour
{
    private SaveLocalService saveService;

    private void Awake() 
    {
        saveService = Services.Get<SaveLocalService>();
    }

    private void Start() 
    {
        TestInt();

        TestFloat();

        TestString();

        TestBool();

        TestDouble();

        TestVector2();

        TestVector3();

        TestSerializableObject();

        TestQuaternion();
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

    private void TestVector2()
    {
        Debug.Log("");
        Debug.Log("TestVector2");

        var testKey = "TestVector2Unit";
        var mainValue = new Vector2(25.5f, 81f);

        saveService.Set<Vector2>(testKey, mainValue);
        var value = saveService.Get<Vector2>(testKey);

        Debug.Log(mainValue);
        Debug.Log(value);
        Debug.Log(mainValue == value);    
    }

    private void TestVector3()
    {
        Debug.Log("");
        Debug.Log("TestVector3");

        var testKey = "TestVector3Unit";
        var mainValue = new Vector3(25.5f, 81f, 1212.45454f);

        saveService.Set<Vector3>(testKey, mainValue);
        var value = saveService.Get<Vector3>(testKey);

        Debug.Log(mainValue);
        Debug.Log(value);
        Debug.Log(mainValue == value);    
    }

    private void TestSerializableObject()
    {
        Debug.Log("");
        Debug.Log("TestSerializableObject");

        var testKey = "TestSerializableObject";
        var mainValue = new TestObject() {stringValue = "Test Serializable Object", floatValue = 21.40f };

        saveService.Set<TestObject>(testKey, mainValue);
        var value = saveService.Get<TestObject>(testKey);

        Debug.Log(mainValue);
        Debug.Log(value);
        Debug.Log(mainValue.Equals(value));
    }

    private void TestQuaternion()
    {
        Debug.Log("");
        Debug.Log("TestQuaternion");

        var testKey = "TestQuaternion";
        var mainValue = Quaternion.AngleAxis(45f, Vector3.up);

        saveService.Set<Quaternion>(testKey, mainValue);
        var value = saveService.Get<Quaternion>(testKey);

        Debug.Log(mainValue);
        Debug.Log(value);
        Debug.Log(mainValue.Equals(value));
    }
}

[Serializable]
public class TestObject
{
    public string stringValue;
    public float floatValue;

    public override string ToString()
    {
        return JsonUtility.ToJson(this);
    }

    public override bool Equals(object obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            TestObject otherTestObject = obj as TestObject;

            return otherTestObject.stringValue == stringValue && otherTestObject.floatValue == floatValue;
        }
    }

    public override int GetHashCode()
    {        
        return stringValue.GetHashCode() ^ floatValue.GetHashCode();
    }
}

