using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>Handles the controlling of UI elements in the game.</summary>
 */
public class DisplayController : Element
{
    /**
     * <summary>Opens the pause menu and pauses the game.</summary>
     */
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

    /**
     * <summary>Updates the counter showing objectives remaining.</summary>
     */
    public void UpdateObjectiveCounter()
    {
        app.view.display.UpdateObjectiveCounter();

    }

    /**
     * <summary>Updates the item hotbar.</summary>
     */
    public void UpdateHotbar()
    {
        app.view.display.UpdateHotbar(app.model.player.heldItems.GetItemSprites());
    }
}
