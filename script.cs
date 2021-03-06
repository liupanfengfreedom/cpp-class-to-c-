﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Runtime.InteropServices;
using System;
public class script : MonoBehaviour                 
{
    public bool b_test = false;
    public bool b_test1 = false;
    int i;
    IntPtr dllp1;
    int sum1;
    IntPtr dllp2;
    int sum2;
    // Use this for initialization
    void Start () {
        i = addlib_add(2,3);
        Debug.Log(i);
        dllp1 = importdllclass();
        Debug.Log(dllp1);
        sum1 = dllclassadd(dllp1,1,2);
        Debug.Log("sum1 :"+sum1);

        dllp2 = importdllclass();
        Debug.Log(dllp2);
        sum2 = dllclassadd(dllp2, 3, 2);
        Debug.Log("sum2 :" + sum2);

    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sum1 = dllclassadd(dllp1, 1, 2);
            Debug.Log("sum1 :" + sum1);

            sum2 = dllclassadd(dllp2, 3, 2);
            Debug.Log("sum2 :" + sum2);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            releasedllclass(dllp2);
        }
	}
    [DllImport("dlltestv01", EntryPoint = "addlib_add", CallingConvention = CallingConvention.Cdecl)]
    public static extern int addlib_add(int a,int b);

    [DllImport("dlltestv01", EntryPoint = "importdllclass", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr importdllclass();

    [DllImport("dlltestv01", EntryPoint = "dllclassadd", CallingConvention = CallingConvention.Cdecl)]
    public static extern int dllclassadd(IntPtr pointer,int a, int b);
    [DllImport("dlltestv01", EntryPoint = "releasedllclass", CallingConvention = CallingConvention.Cdecl)]
    public static extern  int releasedllclass(IntPtr p);

}
// C# wrap 
public class SomeNativeObject
{
    private IntPtr m_NativeObject = IntPtr.Zero;
    public SomeNativeObject()
    {
        m_NativeObject = Internal_CreateNativeObject();
    }
    ~SomeNativeObject()
    {
        Destroy();
    }
    public void Destroy()
    {
        if (m_NativeObject != IntPtr.Zero)
        {
            Internal_DestroyNativeObject(m_NativeObject);
            m_NativeObject = IntPtr.Zero;
        }
    }
    public void SomeNativeMethod(int SomeParameter)
    {
        if (m_NativeObject == IntPtr.Zero)
            throw new Exception("No native object");
        Internal_SomeNativeMethod(m_NativeObject, SomeParameter);
    }
    [DllImport("YourDLL")]
    private static extern IntPtr Internal_CreateNativeObject();
    [DllImport("YourDLL")]
    private static extern Internal_DestroyNativeObject(IntPtr obj);
    [DllImport("YourDLL")]
    private static extern void Internal_SomeNativeMethod(IntPtr obj, int SomeParameter);
}