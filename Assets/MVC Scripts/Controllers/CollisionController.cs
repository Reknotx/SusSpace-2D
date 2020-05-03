using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : Element
{
    public void Collision(CollisionNotification.CollisionType collisionEvent, GameObject obj)
    {
        switch (collisionEvent)
        {
            case CollisionNotification.CollisionType.CollectableItem:
                app.model.player.heldItems.AddItem(obj);
                app.controller.display.UpdateHotbar();
                obj.SetActive(false);
                break;

            case CollisionNotification.CollisionType.PowerUpItem:
                obj.GetComponent<PowerUpItem>().UseItem();
                break;

            case CollisionNotification.CollisionType.HarmfulItem:
                obj.GetComponent<HarmfulItem>().ActivateHarmingEffect();
                break;

            case CollisionNotification.CollisionType.Objective:
                obj.GetComponent<Objective>().ActivateObjectiveBehavior();
                break;

            default:
                break;
        }
    }
}
