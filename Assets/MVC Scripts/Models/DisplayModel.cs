using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayModel : Element
{
    private float _startTime;

    //public float Minutes { get { return _minutes; } set { _minutes = value; } } 
    //public float Seconds { get { return _seconds; } set { _seconds = value; } } 
    public float StartTime { get { return _startTime; } }

    //public GameObject menuPanel, endPanel;

    private void Awake()
    {
        _startTime = Time.time;
    }

    //private void Start()
    //{
    //    if (menuPanel.activeSelf) menuPanel.SetActive(false);
    //    if (endPanel.activeSelf) endPanel.SetActive(false);
    //}
}
