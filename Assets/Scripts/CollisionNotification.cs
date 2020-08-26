using System.Collections;
using System.Collections.Generic;

public class CollisionNotification
{
    public enum CollisionType
    {
        CollectableItem,
        PowerUpItem,
        HarmfulItem,
        Objective
    }

    public static CollisionType collisionType;
}
