using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleuseItems : CollectableItem
{
    public override void UseItem()
    {
        app.model.player.heldItems.RemoveItem();
        Destroy(this.gameObject);
    }
}
