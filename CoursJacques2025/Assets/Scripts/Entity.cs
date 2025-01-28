using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    
    #region DATA INITIALIZATION
    
    // Stored data
    public EntityData entityData;
    
    // modifiable data
    public EntityDataInstance currentEntityData;
    public void Awake()
    {
        currentEntityData = entityData.Instance();
    }
    
    #endregion

    public virtual void AddLife(int addedNb)
    {
        currentEntityData.pv = Mathf.Clamp(currentEntityData.pv + addedNb, 0, entityData.pv);
        if (currentEntityData.pv == 0)
        {
            Die();
        }
    }

    protected abstract void Die();

}
