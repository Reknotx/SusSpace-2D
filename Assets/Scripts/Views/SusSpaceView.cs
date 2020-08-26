using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>Holds references the the various views of the game which update the game's state.</summary>
 */
public class SusSpaceView : Element
{
    public DisplayView display;
    public InputView input;
    public PlayerView player;

    private void Start()
    {
        if (display == null)
        {
            display = FindObjectOfType<DisplayView>();
        }

        if (input == null)
        {
            input = FindObjectOfType<InputView>();
        }

        if (player == null)
        {
            player = FindObjectOfType<PlayerView>();
        }
    }
}
