using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
