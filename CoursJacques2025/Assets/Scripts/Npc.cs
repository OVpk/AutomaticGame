using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Npc : Entity
{
    [SerializeField] private int moveSpeed;

    protected bool canMove = true;

    [SerializeField] protected Vector3 campPosition;

    protected Vector3 objective;

    protected void UpdateMovement()
    {
        if (canMove)
        {
            MoveToObjective(objective);
        }
    }

    private void MoveToObjective(Vector3 objectivePosition)
    {
        Vector3 direction = (objectivePosition - transform.position).normalized;
        if (direction != Vector3.zero)
        {
            transform.position += direction * moveSpeed;
        }
        else
        {
            ObjectiveReached();
        }
    }

    protected virtual void ObjectiveReached()
    {}

    protected override void Die()
    {
        
    }
}
