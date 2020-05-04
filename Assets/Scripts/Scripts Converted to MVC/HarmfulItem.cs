using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HinderanceToPlayer
{
    slow,
    loseItem,
    kill,
    stop
}

public class HarmfulItem : Object
{
    [SerializeField]
    private HinderanceToPlayer hinderanceType;

    public delegate void HinderPlayer();

    public HinderPlayer hinder;

    private void Awake()
    {
        switch (hinderanceType)
        {
            case HinderanceToPlayer.slow:
                hinder = SlowPlayer;
                break;

            case HinderanceToPlayer.loseItem:
                hinder = RemoveItem;
                break;

            case HinderanceToPlayer.kill:
                hinder = KillPlayer;
                break;

            case HinderanceToPlayer.stop:
                hinder = StopPlayer;
                break;

            default:
                break;
        }
    }

    public void ActivateHarmingEffect()
    {
        if (hinder != null) hinder();
    }

    public void SlowPlayer()
    {
        app.controller.player.AdjustSpeedModifier(0.5f);
        Destroy(this.gameObject);
    }

    public void RemoveItem()
    {
        app.model.player.heldItems.RemoveOneRandomItem();
        app.controller.display.UpdateHotbar();
        Destroy(this.gameObject);
    }

    public void KillPlayer()
    {
        Destroy(app.view.player.gameObject);
    }

    public void StopPlayer()
    {
        app.controller.player.EndMove();
        Destroy(this.gameObject);
    }
}
