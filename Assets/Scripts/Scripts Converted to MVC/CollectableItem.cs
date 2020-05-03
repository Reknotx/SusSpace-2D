using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectableItem : HelpfulItem
{
    public HelpfulItemData itemData;

    public float GetMoveDistance()
    {
        return itemData.MoveDistance;
    }
}
