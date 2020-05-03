using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldItems
{
    private List<GameObject> heldItems = new List<GameObject>();

    public HeldItems()
    {
        heldItems = new List<GameObject>();
    }

    public void AddItem(GameObject obj)
    {
        if (obj.GetComponent<CollectableItem>() is MultiUseItems)
        {
            obj.GetComponent<MultiUseItems>().UpdateRemainingUsesSprite();
        }
        heldItems.Add(obj);
    }

    public float GetCurrentItem()
    {
        if (!HasItems()) return 0f;

        CollectableItem temp = heldItems[0].GetComponent<CollectableItem>();
        return temp.GetMoveDistance();
    }

    public void UseCurrentItem()
    {
        if (!HasItems()) return;
        CollectableItem temp = heldItems[0].GetComponent<CollectableItem>();
        temp.UseItem();
    }

    public void RemoveItem()
    {
        heldItems.RemoveAt(0);
        heldItems.TrimExcess();
    }

    public void RemoveOneRandomItem()
    {
        if (!HasItems()) return;
        int index = Random.Range(0, heldItems.Count);
        heldItems.RemoveAt(index);
        heldItems.TrimExcess();
    }

    public List<Sprite> GetItemSprites()
    {
        List<Sprite> sprites = new List<Sprite>();

        foreach (var item in heldItems)
        {
            sprites.Add(item.GetComponent<SpriteRenderer>().sprite);
        }

        return sprites;
    }

    public bool HasItems()
    {
        if (heldItems.Count == 0) return false;
        else return true;
    }
}
