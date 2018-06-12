using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
public class ShareMemory : MonoBehaviour {
    public GameObject validbackground;
    public GameObject invalidbackground;
    int i;
    normaldata datatosend;
    normaldata datatoread;
    private void OnEnable()
    {

    }
    // Use this for initialization
    void Start () {
        opensharedmemory();
        debugtext.settext("opensharedmemory :" + i.ToString());
        datatosend = new normaldata(1);
        datatoread = new normaldata(0);
        StartCoroutine(sendinforcoroutine());
    }

    IEnumerator sendinforcoroutine()
    {
        debugtext.settext("insendinfor 0");
        // yield return new WaitForSeconds(0.1f);
     
        while (!TimeVerifier.b_dataready)
        {
            yield return new WaitForSeconds(0.02f);
            debugtext.settext("insendinfor 1");
        }
        debugtext.settext("insendinfor 2");
        datatosend.array[0] = 0xcc;
        Debug.Log("_locker" + TimeVerifier._Locker.ToString());
        if (TimeVerifier._Locker)
        {
            
            datatosend.array[1] = 0x11;
            timeisinvalid();
        }
        else
        {
            datatosend.array[1] = 0x00;
            timeisvalid();
        }
        i = writesharedmemory(ref datatosend);
    }
    // Update is called once per frame
    void Update () {
		
	}
    private void OnApplicationQuit()
    {
        datatosend.array[0] = 0x0c;
        i = writesharedmemory(ref datatosend);
        closesharedmemory();
    }
    void timeisvalid()
    {
        validbackground.SetActive(true);
        invalidbackground.SetActive(false);
    }
    void timeisinvalid()
    {
        validbackground.SetActive(false);
        invalidbackground.SetActive(true);
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
}
