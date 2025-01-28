using UnityEngine;

public class Harvester : Npc
{
    public enum HarvesterType
    {
        Woodcutter,
        Farmer
    }

    private enum HarvesterState
    {
        GoToCollectible,
        Harvest,
        GoToCamp
    }

    [SerializeField] private HarvesterType harvesterType;
    private HarvesterState currentState;

    private int resources = 0;
    
    private void Update()
    {
        HarvesterState lastState = currentState;
        UpdateMovement();
        if (lastState != currentState)
        {
            UpdateBehavior();
        }
    }
    
    private void UpdateBehavior()
    {
        switch (currentState)
        {
            case HarvesterState.GoToCollectible :
                objective = FindNextObjective();
                canMove = true;
                break;
            case HarvesterState.Harvest :
                canMove = false;
                //activer collider
                break;
            case HarvesterState.GoToCamp :
                objective = campPosition;
                canMove = true;
                break;
        }
    }

    private Vector3 FindNextObjective()
    {
        Vector3 nextObjective = CollectibleManager.Instance.allCollectibles[0].gameObject.transform.position;
        for (int i = 1; i < CollectibleManager.Instance.allCollectibles.Count; i++)
        {
            if (harvesterType == CollectibleManager.Instance.allCollectibles[i].requiredHarvester)
            {
                Vector3 collectiblePosition = CollectibleManager.Instance.allCollectibles[i].gameObject.transform.position;
                float distanceWithNew = Vector3.Distance(transform.position, collectiblePosition);
                float distanceWithLast = Vector3.Distance(transform.position, nextObjective);
                if (distanceWithNew < distanceWithLast)
                {
                    nextObjective = collectiblePosition;
                }
            }
        }
        return nextObjective;
    }
    
    protected override void ObjectiveReached()
    {
        currentState = HarvesterState.Harvest;
    }
    
}
