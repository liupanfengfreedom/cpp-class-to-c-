using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICondition {
    bool checkcondition();
}

[System.Serializable]
public abstract class icondition : ISerializationCallbackReceiver
{
    public abstract bool checkcondition();
    public void OnAfterDeserialize()
    {
        throw new System.NotImplementedException();
    }

    public void OnBeforeSerialize()
    {
        throw new System.NotImplementedException();
    }
}
