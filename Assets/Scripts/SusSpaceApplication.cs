using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public SusSpaceApplication app { get { return SusSpaceApplication.Instance; } }
}

public class SusSpaceApplication : MonoBehaviour
{
    public static SusSpaceApplication Instance;

    public SusSpaceModel model;
    public SusSpaceView view;
    public SusSpaceController controller;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }
}
