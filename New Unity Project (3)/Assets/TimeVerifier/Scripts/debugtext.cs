//#define DEBUGTEXT
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class debugtext : MonoBehaviour {
    static Text textdebug;
    private void OnEnable()
    {
        textdebug = GetComponent<Text>();
    }
    // Use this for initialization
    void Start () {
      

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public static void settext(string str)
    {
#if DEBUGTEXT
        textdebug.text += str;
#endif
    }
}
