using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SusSpaceController : Element
{
    public DisplayController display;
    public CollisionController collisions;
    public PlayerController player;
    public SceneController scene;


    private void Start()
    {
        if (display == null)
        {
            display = FindObjectOfType<DisplayController>();
        }

        if (collisions == null)
        {
            collisions = FindObjectOfType<CollisionController>();
        }

        if (player == null)
        {
            player = FindObjectOfType<PlayerController>();
        }

        if (scene == null)
        {
            scene = FindObjectOfType<SceneController>();
        }
    }
}
