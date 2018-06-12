using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class timeverifygame : MonoBehaviour {
    normaldata datatoread;
    string path = @"E:\unitytestprojects\New Unity Project 1\timeapp\s.exe";
    char[] patharray;
    private void OnEnable()
    {
        opensharedmemory();
    }
    // Use this for initialization
    void Start () {
        path = Application.dataPath+ "/StreamingAssets/timeverify/s.exe";
        patharray = path.ToCharArray();             
        StartCoroutine(readinforcoroutine());
    }	
	// Update is called once per frame
	void Update () {

    }
    IEnumerator readinforcoroutine()//          run in background
    {
        launchapp(ref patharray[0]);
        debugtext.settext("coroutinestart");
        while (true)
        {          
        
            readsharedmemory(ref datatoread);
            //Debug.Log(datatoread.array[0].ToString());
           // debugtext.settext(datatoread.array[0].ToString());
            if (datatoread.array[0] == 0xcc)
            {
                break;
            }
            yield return new WaitForSeconds(0.02f);
        }
        debugtext.settext("[1]");
        debugtext.settext(datatoread.array[1].ToString());
       // Debug.Log(datatoread.array[1].ToString());
        if (datatoread.array[1] == 0x11)
        {
            debugtext.settext("appexit");
            //Debug.Log("appexit");
            yield return new WaitForSeconds(2f);
            Application.Quit();
        }
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct normaldata
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public int[] array;
        public normaldata(int i)
        {
            array = new int[5];
            for (int j = 0; j < 5; j++)
            {
                array[j] = i;
            }
        }
    }
    [DllImport("Uedynamiclink", EntryPoint = "opensharedmemory", CallingConvention = CallingConvention.Cdecl)]
    public static extern int opensharedmemory();

    [DllImport("Uedynamiclink", EntryPoint = "writesharedmemory", CallingConvention = CallingConvention.Cdecl)]
    public static extern int writesharedmemory(ref normaldata bytes);

    [DllImport("Uedynamiclink", EntryPoint = "readsharedmemory", CallingConvention = CallingConvention.Cdecl)]
    public static extern int readsharedmemory(ref normaldata bytes);

    [DllImport("Uedynamiclink", EntryPoint = "closesharedmemory", CallingConvention = CallingConvention.Cdecl)]
    public static extern void closesharedmemory();
    [DllImport("Uedynamiclink", EntryPoint = "launchapp", CallingConvention = CallingConvention.Cdecl)]
    public static extern void launchapp(ref char path);
}
