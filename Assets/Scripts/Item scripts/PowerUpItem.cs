using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BenefitToPlayer
{
    grabItem = 0,
    speedBoost = 1
}

public class PowerUpItem : HelpfulItem
{
    public BenefitToPlayer benefitType;

    public delegate void BenefitPlayer();

    public BenefitPlayer benefit;

    private void Awake()
    {
        switch (benefitType)
        {
            case BenefitToPlayer.grabItem:
                benefit = GrabNearestItem;
                break;

            case BenefitToPlayer.speedBoost:
                benefit = SpeedBoost;
                break;

            default:
                break;
        }
    }

    public override void UseItem()
    {
        if (benefit != null) benefit();
        Destroy(this.gameObject);
    }

    public void GrabNearestItem()
    {
        /*
         * Need to search within a radius of the lasso for available
         * helpful gameobjects. If any are within range the object
         * needs to be added to the player. In order to maintain the
         * current behavior where the player handles the trigger events
         * the item will need to be dragged onto the player. In initial
         * stage this will just be a quick snap onto the player, in later
         * iterations this effect will be visual and a gradual drag that
         * happens overtime.
         */
        List<Collider2D> nearbyObjects = new List<Collider2D>();
        ContactFilter2D filter = new ContactFilter2D();
        filter.SetLayerMask(LayerMask.GetMask("Helpful Items"));

        int itemsInRange = Physics2D.OverlapCircle(transform.position, 10f, filter, nearbyObjects);

        if (itemsInRange == 0) return;

        GameObject closestItem = nearbyObjects[0].gameObject;

        float itemRangeToLasso = Vector2.Distance(this.transform.position, closestItem.transform.position);

        foreach (Collider2D item in nearbyObjects)
        {
            float tempDist = Vector2.Distance(this.transform.position, item.gameObject.transform.position);

            if (tempDist <= itemRangeToLasso)
            {
                closestItem = item.gameObject;
                itemRangeToLasso = tempDist;
            }
        }

        closestItem.transform.position = app.view.player.transform.position;

    }

    public void SpeedBoost()
    {
        app.controller.player.AdjustSpeedModifier(2f);
    }
}
