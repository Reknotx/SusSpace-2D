using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>Performs the logic for the player in the world.</summary>
 */
public class PlayerController : Element
{

    /**
     * <summary>Executes the movement logic for the player once they have either
     * used an item or they are pushing off of the ship. <para>Also sends an update
     * to the item hotbar to properly display the player's remaining items.</para> Sets
     * the player's data to indicate they are moving so their view will update
     * their position.</summary>
     * 
     * <param name="destination">The destination the player is being moved towards.</param>
     */
    public void PerformMovement(Vector3 destination)
    {
        app.model.player.destination = destination;

        app.model.player.TimeStart = Time.time;

        app.model.player.posAtStartOfMove = app.view.player.gameObject.transform.position;
        //arrow.gameObject.SetActive(false);

        if (!app.model.player.initialPushOff)
        {
            app.model.player.heldItems.UseCurrentItem();

            //This breaks the software design pattern.
            if (app.model.player.SpeedModifer != 1)
            {
                app.model.player.SpeedModifer = 1f;
                app.view.player.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
        else
        {
            //execute the initial push off
            app.model.player.initialPushOff = false;
        }

        //Update the hotbar
        app.view.display.UpdateHotbar(app.model.player.heldItems.GetItemSprites());

        app.model.player.Moving = true;
    }

    /**
     * <summary>Called at the end of the players movement cycle when they have reached their
     * destination.</summary>
     */
    public void EndMove()
    {
        app.model.player.Moving = false;
        app.model.player.posAtStartOfMove = app.view.player.transform.position;
        app.model.player.destination = app.view.player.transform.position;
    }

    /**
     * <summary>Called to adjust the modifier to the player's speed after colliding
     * with certain items.</summary>
     * 
     * <param name="newModifier">The new modifier for the player's speed.</param>
     */
    public void AdjustSpeedModifier(float newModifier)
    {
        app.model.player.SpeedModifer = newModifier;
        if (newModifier <= 1f)
        {
            app.view.player.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }

    /**
     * <summary>Called when the player touches the ship and stops their movement
     * to prevent the player from going further into the sprite. <para>Allows the player
     * to push off of the ship as well to reach items.</para></summary>
     */
    public void CollidedWithShip()
    {
        app.model.player.Moving = false;
        app.model.player.posAtStartOfMove = app.view.player.transform.position;
        app.model.player.destination = app.view.player.transform.position;
        app.model.player.initialPushOff = true;
    }

    /**
     * <summary>
     * <para>Aims the player's aiming arrow to indicate where the player will
     * be moving to more accurately.</para> <para>The tip of the arrow indicates where the
     * player will end up at the end of their movement.</para>
     * </summary>
     * 
     * <param name="mousePos">The position of the mouse in 3D space.</param>
     * 
     */
    public void AimArrow(Vector3 mousePos)
    {
        //if (!app.model.player.heldItems.HasItems()) return;


        Vector3 arrowPos = Camera.main.WorldToScreenPoint(app.model.player.arrowRotationPoint.position);
        mousePos.x = mousePos.x - arrowPos.x;
        mousePos.y = mousePos.y - arrowPos.y;
        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        //Determine scale ot represent distance
        float yScale = 0f;
        if (app.model.player.initialPushOff)
        {
            yScale = app.model.player.InitialPushOffDistance;
        }
        else
        {
            yScale = app.model.player.heldItems.GetCurrentItem();
        }


        app.model.player.arrowScale.localScale = new Vector3(app.model.player.arrowScale.localScale.x,
                                                             yScale,
                                                             app.model.player.arrowScale.localScale.z);


        app.model.player.arrowRotationPoint.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }
}
