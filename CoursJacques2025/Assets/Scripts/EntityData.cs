using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityData : ScriptableObject
{
    [field: Header("Entity Life"),SerializeField]
    public int pv { get; private set; }
    
    public EntityDataInstance Instance()
    {
        return new EntityDataInstance(this);
    }
}

public class EntityDataInstance
{
    public int pv;

    public EntityDataInstance(EntityData data)
    {
        pv = data.pv;
    }
    
}
