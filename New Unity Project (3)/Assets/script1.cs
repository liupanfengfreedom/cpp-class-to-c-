using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script1 : MonoBehaviour {
    public RConditionEvent conditioncase1;
    RCondition returnvalue= new RCondition();
    // Use this for initialization
    void Start () {
        //conditioncase1.AddListener(f1);
        //conditioncase1.RemoveAllListeners();
        int i = conditioncase1.GetPersistentEventCount();

      //  Debug.Log(i);
      //  if (conditioncase1.)
        {

        }


    }
	
	// Update is called once per frame
	void Update () {
        conditioncase1.RCInvoke(returnvalue);
        //Debug.Log("get and boolvalue  " + returnvalue.get_andboolvalue());
        //Debug.Log("get or boolvalue   " + returnvalue.get_orboolvalue());
    }
}
