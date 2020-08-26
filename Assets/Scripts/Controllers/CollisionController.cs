using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>Filters the collision between player and game objects.</summary>
 */
public class CollisionController : Element
{
    /**
     * <summary>Filters the collision the player has with world objects.</summary>
     * 
     * <param name="collisionEvent">The type of object that was collided with.</param>
     * <param name="obj">The object that was collided with.</param>
     */
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
