using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayController : Element
{
    public void PauseMenu()
    {
        app.view.display.menuPanel.SetActive(!app.view.display.menuPanel.activeSelf);

        if (app.view.display.menuPanel.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void DisplayEndCard()
    {
        app.view.display.endPanel.SetActive(!app.view.display.endPanel.activeSelf);
    }

    public void UpdateObjectiveCounter()
    {
        app.view.display.UpdateObjectiveCounter();

    }

    public void UpdateHotbar()
    {
        app.view.display.UpdateHotbar(app.model.player.heldItems.GetItemSprites());
    }
}
