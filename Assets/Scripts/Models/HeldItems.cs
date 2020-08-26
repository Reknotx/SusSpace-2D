using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>Holds references to the player's held items.</summary>
 */
public class HeldItems
{
    private List<GameObject> heldItems = new List<GameObject>();

    /**
     * <summary>Default constructor, initializes a list of game objects.</summary>
     */
    public HeldItems()
    {
        heldItems = new List<GameObject>();
    }

    /**
     * <summary>Adds a gameobject to the list of items.</summary>
     * 
     * <param name="obj">The game object to add.</param>
     */
    public void AddItem(GameObject obj)
    {
        if (obj.GetComponent<CollectableItem>() is MultiUseItems)
        {
            obj.GetComponent<MultiUseItems>().UpdateRemainingUsesSprite();
        }
        heldItems.Add(obj);
    }

    /**
     * <summary>Get's the distance value of the current item.</summary>
     * 
     * <returns>A float representing the item's move distance.</returns>
     */
    public float GetCurrentItem()
    {
        if (!HasItems()) return 0f;

        CollectableItem temp = heldItems[0].GetComponent<CollectableItem>();
        return temp.GetMoveDistance();
    }

    /**
     * <summary>Removes the item at the front of the list and uses it.</summary>
     */
    public void UseCurrentItem()
    {
        if (!HasItems()) return;
        CollectableItem temp = heldItems[0].GetComponent<CollectableItem>();
        temp.UseItem();
    }

    /**
     * <summary>Removes the item at the front of the list. Useful for harmful items that remove an item from player.</summary>
     */
    public void RemoveItem()
    {
        heldItems.RemoveAt(0);
        heldItems.TrimExcess();
    }

    /**
     * <summary>Removes one random item from the player's inventory.</summary>
     */
    public void RemoveOneRandomItem()
    {
        if (!HasItems()) return;
        int index = Random.Range(0, heldItems.Count);
        heldItems.RemoveAt(index);
        heldItems.TrimExcess();
    }

    /**
     * <summary>Gets a reference to the player's held items.</summary>
     * 
     * <returns>A list of sprites representing the player's items.</returns>
     */
    public List<Sprite> GetItemSprites()
    {
        List<Sprite> sprites = new List<Sprite>();

        foreach (var item in heldItems)
        {
            sprites.Add(item.GetComponent<SpriteRenderer>().sprite);
        }

        return sprites;
    }

    /**
     * <summary>Checks to see if the player has any items in their inventory.</summary>
     * 
     * <returns>True if player has items, false otherwise.</returns>
     */
    public bool HasItems()
    {
        if (heldItems.Count == 0) return false;
        else return true;
    }
}
