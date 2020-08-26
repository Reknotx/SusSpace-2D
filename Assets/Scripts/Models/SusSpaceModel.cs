using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>Contains references to all of the games models which hold necessary data.</summary>
 */
public class SusSpaceModel : Element
{
    public PlayerModel player;
    public ObjectiveCollectionModel objectives;
    public DisplayModel display;


    private void Start()
    {
        if (player == null)
        {
            player = FindObjectOfType<PlayerModel>();
        }

        if (objectives == null)
        {
            objectives = FindObjectOfType<ObjectiveCollectionModel>();
        }

        if (display == null)
        {
            display = FindObjectOfType<DisplayModel>();
        }
    }
}
