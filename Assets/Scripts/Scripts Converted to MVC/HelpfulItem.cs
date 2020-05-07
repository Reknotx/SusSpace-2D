using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HelpfulItem : Object
{
    public abstract void UseItem();

    private void Update()
    {
        transform.Rotate(Vector3.forward * -0.5f);
    }
}
