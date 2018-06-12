using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class displaytime : MonoBehaviour {
    Text timetext;
	// Use this for initialization
	void Start () {
        timetext = GetComponent<Text>();
        StartCoroutine(displayvalidtimecoroutine());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator displayvalidtimecoroutine()
    {
        // yield return new WaitForSeconds(0.1f);
      
        while (!TimeVerifier.b_dataready)
        {
            yield return new WaitForSeconds(0.1f);
        }
        Debug.Log("_locker" + TimeVerifier._Locker.ToString());
        string timedata = TimeVerifier.getvaliddata();
        timetext.text = "expiration time is " + TimeVerifier.getvaliddata();
    }
}
