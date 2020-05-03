using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputView : Element
{
    public bool testing = false;
    bool aimingMode;
    //public Transform arrowRotation;

    void Update()
    {

        if (app.model.player.Moving || Time.timeScale == 0) return;

        if (Input.GetMouseButtonDown(0))
        {
            aimingMode = true;
            app.model.player.arrowRotationPoint.gameObject.SetActive(true);
            //arrow.gameObject.SetActive(true);
        }

        if (!aimingMode) return;

        if (testing && Input.GetMouseButtonUp(0))
        {
            Vector3 testingMousePos2D = Input.mousePosition;

            testingMousePos2D.z = -Camera.main.transform.position.z;

            Vector3 testingMousePos3D = Camera.main.ScreenToWorldPoint(testingMousePos2D);

            app.view.player.transform.position = testingMousePos3D;

            return;

        }
        else
        {
            //Get mouse positions - START
            Vector3 mousePos2D = Input.mousePosition;

            mousePos2D.z = -Camera.main.transform.position.z;

            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

            Vector3 mouseDelta = mousePos3D - app.view.player.gameObject.transform.position;
            //Get mouse positions - END

            //Aim the arrow to point at the mouse
            app.controller.player.AimArrow(mousePos2D);

            mouseDelta.Normalize();

            if (!app.model.player.initialPushOff)
            {
                mouseDelta *= app.model.player.heldItems.GetCurrentItem();
            }
            else
            {
                mouseDelta *= app.model.player.InitialPushOffDistance;
            }

            Vector3 destination = app.view.player.transform.position + mouseDelta * app.model.player.SpeedModifer;

            if(Input.GetMouseButtonUp(0))
            {
                //use currently held item
                aimingMode = false;

                app.model.player.arrowRotationPoint.gameObject.SetActive(false);
                app.controller.player.PerformMovement(destination);

            }
        }
    }
}
