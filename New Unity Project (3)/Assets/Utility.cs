using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RCondition
{
    bool condition;
    bool condition_and=true;
    bool condition_or = false;
    public void writboolvalue(bool b)
    {
        condition_and &= b;
        condition_or |= b;
        condition = b;
    }
    public void initvalue() {
        condition_and = true;
        condition_or = false;
    }
    public bool get_condition()
    {
        return condition;
    }
    public bool get_andboolvalue()
    {
        return condition_and;
    }
    public bool get_orboolvalue()
    {
        return condition_or;
    }
}
[System.Serializable]
public class RConditionEvent : UnityEvent<RCondition>
{
    public void RCInvoke(RCondition r) {
        r.initvalue();
        Invoke(r);
    }
  
}

public class CoroutineControl
{
    MonoBehaviour mb;
    IEnumerator corroutine;
    bool runing = false;
    public CoroutineControl(MonoBehaviour mb, IEnumerator cr)
    {
        this.mb = mb;
        corroutine = cr;
    }
    public void startcoroutine()
    {
        if (!runing)
        {
            mb.StartCoroutine(corroutine);
            runing = true;
        }
    }
    public void stopcoroutine()
    {
        if (runing)
        {
            mb.StopCoroutine(corroutine);
            runing = false;
        }
    }
    public bool isruning()
    {
        return runing;
    }
}
