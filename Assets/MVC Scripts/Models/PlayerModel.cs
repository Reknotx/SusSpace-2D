﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : Element
{
    public bool Moving { get; set; }

    public float SpeedModifer { get; set; } = 1f;

    public float TimeStart { get; set; }

    public float easingMod;

    public HeldItems heldItems = new HeldItems();

    [SerializeField]
    private float _timeDuration;

    public float TimeDuration { get { return _timeDuration; } }

    [SerializeField]
    private float _initialPushOffDistance;

    public float InitialPushOffDistance { get { return _initialPushOffDistance; } }

    public bool initialPushOff = true;

    public Vector3 posAtStartOfMove, destination;

    public Transform arrowRotationPoint, arrowScale;

    private void Start()
    {
        if (arrowRotationPoint == null)
        {
            arrowRotationPoint = GameObject.Find("Arrow Rotation Point").transform;
        }

        if (arrowScale == null)
        {
            arrowScale = GameObject.Find("Arrow").transform;
        }
    }
}
