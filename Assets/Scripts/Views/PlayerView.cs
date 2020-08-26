using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>Handles player collision detection and movement.</summary>
 */
public class PlayerView : Element
{
    public bool movingOverride = false;
    private Rigidbody2D playerRB;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        if (movingOverride)
        {
            LinearInterpolate();
        }
        else
        {
            if (!app.model.player.Moving) return;

            LinearInterpolate();
            //LinearInterpolateWithRB();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //the background layer needs to be ignored with collisions.
        if (other.gameObject.layer == 9) return;

        //Barriers and ship are on this layer
        if (other.gameObject.layer == 10)
        {
            app.controller.player.CollidedWithShip();
            return;
        }

        var Object = other.gameObject.GetComponent<Object>();

        CollisionNotification.CollisionType eventType = 0;

        if (Object is HelpfulItem)
        {
            if (Object is CollectableItem)
            {
                eventType = CollisionNotification.CollisionType.CollectableItem;
                //app.controller.AddItemToPlayer(other.gameObject);
            }
            else if (Object is PowerUpItem)
            {
                //PowerUpItem temp = other.gameObject.GetComponent<PowerUpItem>();
                //temp.UseItem();
                eventType = CollisionNotification.CollisionType.PowerUpItem;
            }
        }
        else if (Object is HarmfulItem)
        {
            //Is a harmful item
            //HarmfulItem temp = other.GetComponent<HarmfulItem>();
            //temp.ActivateHarmingEffect();
            eventType = CollisionNotification.CollisionType.HarmfulItem;
        }
        else if (Object is Objective)
        {
            //Is an objective
            //Objective temp = other.GetComponent<Objective>();
            //temp.ActivateObjectiveBehavior();
            eventType = CollisionNotification.CollisionType.Objective;
        }

        app.controller.collisions.Collision(eventType, other.gameObject);
    }

    /**
     * <summary>Linearly interpolates player to destination.</summary>
     */
    private void LinearInterpolate()
    {
        //need to linearly interpolate to max distance
        float u = (Time.time - app.model.player.TimeStart) / app.model.player.TimeDuration;

        if (u >= 1f)
        {
            u = 1f;
        }

        u = EaseOut(u);

        //standard Linear interpolation
        Vector3 currentPosOnInter = (1 - u) * app.model.player.posAtStartOfMove + u * app.model.player.destination;
        transform.position = currentPosOnInter;

        if (u == 1)
        {
            //app.model.player.Moving = false;
            app.controller.player.EndMove();
        }
    }

    private void LinearInterpolateWithRB()
    {
        playerRB.MovePosition(Vector2.MoveTowards(app.view.player.transform.position, app.model.player.destination, 0.05f));
    }

    /**
     * <summary>Used to make linear interpolation formula into ease out one.</summary>
     */
    float EaseOut(float t)
    {
        return 1 - Mathf.Pow(1 - t, app.model.player.easingMod);
    }
}
