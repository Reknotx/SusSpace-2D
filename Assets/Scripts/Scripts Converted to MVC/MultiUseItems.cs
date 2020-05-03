using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiUseItems : CollectableItem
{
    private int numberOfUses;

    public List<Sprite> remainingChargesSprites;

    private void Start()
    {
        numberOfUses = itemData.NumberOfUses;
    }

    public override void UseItem()
    {
        numberOfUses--;

        if (numberOfUses == 0)
        {
            app.model.player.heldItems.RemoveItem();
            Destroy(this.gameObject);
        }
        else
        {
            UpdateRemainingUsesSprite();
        }
    }

    public void UpdateRemainingUsesSprite()
    {
        if (remainingChargesSprites.Count >= 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = remainingChargesSprites[numberOfUses - 1];
        }
    }
}
