using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : Element
{
    private void Update()
    {
        if (!app.model.player.Moving) return;

        LinearInterpolate();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //the background layer needs to be ignored with collisions.
        if (other.gameObject.layer == 9) return;

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

    float EaseOut(float t)
    {
        return 1 - Mathf.Pow(1 - t, app.model.player.easingMod);
    }
}
