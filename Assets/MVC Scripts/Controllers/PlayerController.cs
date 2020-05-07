using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Element
{
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

    public void EndMove()
    {
        app.model.player.Moving = false;
        app.model.player.posAtStartOfMove = app.view.player.transform.position;
        app.model.player.destination = app.view.player.transform.position;
    }

    public void AdjustSpeedModifier(float newModifier)
    {
        app.model.player.SpeedModifer = newModifier;
        if (newModifier <= 1f)
        {
            app.view.player.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        }
    }

    public void CollidedWithShip()
    {
        app.model.player.Moving = false;
        app.model.player.posAtStartOfMove = app.view.player.transform.position;
        app.model.player.destination = app.view.player.transform.position;
        app.model.player.initialPushOff = true;
    }

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
