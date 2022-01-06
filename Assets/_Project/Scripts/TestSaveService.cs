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
        //TestNoCollections();

        TestCollections();
    }

    private void TestNoCollections()
    {
        TestInt();

        TestFloat();

        TestLong();

        TestDouble();

        TestBool();

        TestString();

        TestVector2();

        TestVector3();

        TestSerializableObject();

        TestQuaternion();

        TestDateTime();

        TestRect();
    }

    private void TestCollections()
    {
        TestIntArray();

        TestFloatArray();

        TestLongArray();

        TestDoubleArray();

        TestBoolArray();

        TestStringArray();

        TestVector2Array();

        TestVector3Array();

        TestQuaternionArray();

        TestDateTimeArray();

        TestRectArray();
    }

    #region Collections

    private void TestIntArray()
    {
        Debugs.LogColor("TestIntArray", Color.green);

        var testKey = "TestIntArray";
        var mainValue = new int[3] { 5, 45, 81 };

        saveService.Set<int[]>(testKey, mainValue);
        var value = saveService.Get<int[]>(testKey);

        Debugs.Log(mainValue);
        Debugs.Log(value);
    }

    private void TestFloatArray()
    {
        Debug.Log("TestFloatArray");

        var testKey = "TestFloatArray";
        var mainValue = new float[] { 12312.12312f, -12.12312f, -123.123321f };

        saveService.Set<float[]>(testKey, mainValue);
        var value = saveService.Get<float[]>(testKey);

        Debugs.Log(mainValue);
        Debugs.Log(value);
    }

    private void TestLongArray()
    {
        Debug.Log("TestLongArray");

        var testKey = "TestLongArray";
        var mainValue = new long[] { 12312L, 5454545L, -123123321L };

        saveService.Set<long[]>(testKey, mainValue);
        var value = saveService.Get<long[]>(testKey);

        Debugs.Log(mainValue);
        Debugs.Log(value);
    }

    private void TestDoubleArray()
    {
        Debug.Log("TestDoubleArray");

        var testKey = "TestDoubleArray";
        var mainValue = new double[] { 123.12D, -9291123.12D, -0.12D };

        saveService.Set<double[]>(testKey, mainValue);
        var value = saveService.Get<double[]>(testKey);

        Debugs.Log(mainValue);
        Debugs.Log(value);
    }

    private void TestBoolArray()
    {
        Debug.Log("TestBoolArray");

        var testKey = "TestBoolArray";
        var mainValue = new bool[] { true, false, true };

        saveService.Set<bool[]>(testKey, mainValue);
        var value = saveService.Get<bool[]>(testKey);

        Debugs.Log(mainValue);
        Debugs.Log(value);
    }

    private void TestStringArray()
    {
        Debug.Log("TestStringArray");

        var testKey = "TestStringArray";
        var mainValue = new string[] { "string", "string value", "value string" };

        saveService.Set<string[]>(testKey, mainValue);
        var value = saveService.Get<string[]>(testKey);

        Debugs.Log(mainValue);
        Debugs.Log(value);
    }

    private void TestVector2Array()
    {
        Debug.Log("TestVector2Array");

        var testKey = "TestVector2Array";
        var mainValue = new Vector2[] { Vector2.down, Vector2.up, Vector2.left };

        saveService.Set<Vector2[]>(testKey, mainValue);
        var value = saveService.Get<Vector2[]>(testKey);

        Debugs.Log(mainValue);
        Debugs.Log(value);
    }

    private void TestVector3Array()
    {
        Debug.Log("TestVector3Array");

        var testKey = "TestVector3Array";
        var mainValue = new Vector3[] { Vector3.down, Vector3.up, Vector3.left };

        saveService.Set<Vector3[]>(testKey, mainValue);
        var value = saveService.Get<Vector3[]>(testKey);

        Debugs.Log(mainValue);
        Debugs.Log(value);
    }

    private void TestQuaternionArray()
    {
        Debug.Log("TestQuaternionArray");

        var testKey = "TestQuaternionArray";
        var mainValue = new Quaternion[] { Quaternion.AngleAxis(45f, Vector3.up), Quaternion.AngleAxis(90f, Vector3.down) };

        saveService.Set<Quaternion[]>(testKey, mainValue);
        var value = saveService.Get<Quaternion[]>(testKey);

        Debugs.Log(mainValue);
        Debugs.Log(value);
    }

    private void TestDateTimeArray()
    {
        Debug.Log("TestDateTimeArray");

        var testKey = "TestDateTimeArray";
        var mainValue = new DateTime[] { DateTime.Now, new DateTime(123440456L) };

        saveService.Set<DateTime[]>(testKey, mainValue);
        var value = saveService.Get<DateTime[]>(testKey);

        Debugs.Log(mainValue);
        Debugs.Log(value);
    }

    private void TestRectArray()
    {
        Debug.Log("TestRectArray");

        var testKey = "TestRectArray";
        var mainValue = new Rect[] { new Rect(41, 17, 51, 39), new Rect(51, 39, 41, 17) };

        saveService.Set<Rect[]>(testKey, mainValue);
        var value = saveService.Get<Rect[]>(testKey);

        Debugs.Log(mainValue);
        Debugs.Log(value);
    }

    #endregion


    #region No Collections
    private void TestInt()
    {
        Debug.Log("TestInt");

        var testKey = "testIntUnit";
        var mainValue = -1233311;

        saveService.Set<int>(testKey, mainValue);
        var value = saveService.Get<int>(testKey);

        Debug.Log(mainValue == value);
    }

    private void TestFloat()
    {
        Debug.Log("TestFloat");

        var testKey = "testFloatUnit";
        var mainValue = -1151.201555f;

        saveService.Set<float>(testKey, mainValue);
        var value = saveService.Get<float>(testKey);

        Debug.Log(mainValue == value);
    }

    private void TestLong()
    {
        Debug.Log("TestLong");

        var testKey = "TestLongUnit";
        var mainValue = 4546251351513213L;

        saveService.Set<long>(testKey, mainValue);
        var value = saveService.Get<long>(testKey);

        Debug.Log(mainValue == value);
    }

    private void TestDouble()
    {
        Debug.Log("TestDouble");

        var testKey = "testDoubleUnit";
        var mainValue = 155151515d;

        saveService.Set<double>(testKey, mainValue);
        var value = saveService.Get<double>(testKey);

        Debug.Log(mainValue == value);
    }

    private void TestBool()
    {
        Debug.Log("TestBool");

        var testKey = "testBoolUnit";
        var mainValue = true;

        saveService.Set<bool>(testKey, mainValue);
        var value = saveService.Get<bool>(testKey);

        Debug.Log(mainValue == value);
    }

    private void TestString()
    {
        Debug.Log("TestString");

        var testKey = "testStringUnit";
        var mainValue = "testing the value";

        saveService.Set<string>(testKey, mainValue);
        var value = saveService.Get<string>(testKey);

        Debug.Log(mainValue == value);
    }

    private void TestVector2()
    {
        Debug.Log("TestVector2");

        var testKey = "TestVector2Unit";
        var mainValue = new Vector2(25.5f, 81f);

        saveService.Set<Vector2>(testKey, mainValue);
        var value = saveService.Get<Vector2>(testKey);

        Debug.Log(mainValue == value);
    }

    private void TestVector3()
    {
        Debug.Log("TestVector3");

        var testKey = "TestVector3Unit";
        var mainValue = new Vector3(25.5f, 81f, 1212.45454f);

        saveService.Set<Vector3>(testKey, mainValue);
        var value = saveService.Get<Vector3>(testKey);

        Debug.Log(mainValue == value);
    }

    private void TestSerializableObject()
    {
        Debug.Log("TestSerializableObject");

        var testKey = "TestSerializableObjectUnit";
        var mainValue = new TestObject() { stringValue = "Test Serializable Object", floatValue = 21.40f, stringArrayValue = new string[] { "string", "string value", "value string" } };

        saveService.Set<TestObject>(testKey, mainValue);
        var value = saveService.Get<TestObject>(testKey);

        Debug.Log(mainValue.Equals(value));
    }

    private void TestQuaternion()
    {
        Debug.Log("TestQuaternion");

        var testKey = "TestQuaternionUnit";
        var mainValue = Quaternion.AngleAxis(45f, Vector3.up);

        saveService.Set<Quaternion>(testKey, mainValue);
        var value = saveService.Get<Quaternion>(testKey);

        Debug.Log(mainValue == value);
    }

    private void TestDateTime()
    {
        Debug.Log("TestDateTime");

        var testKey = "TestDateTimeUnit";
        var mainValue = DateTime.Now;

        saveService.Set<DateTime>(testKey, mainValue);
        var value = saveService.Get<DateTime>(testKey);

        Debug.Log(mainValue == value);
    }

    private void TestRect()
    {
        Debug.Log("TestRect");

        var testKey = "TestRectUnit";
        var mainValue = new Rect(41, 17, 51, 39);

        saveService.Set<Rect>(testKey, mainValue);
        var value = saveService.Get<Rect>(testKey);

        Debug.Log(mainValue == value);
    }

    #endregion

}

[Serializable]
public class TestObject
{
    public string stringValue;
    public float floatValue;

    public string[] stringArrayValue;

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
        return stringValue.GetHashCode() ^ floatValue.GetHashCode() ^ stringArrayValue.GetHashCode();
    }
}

