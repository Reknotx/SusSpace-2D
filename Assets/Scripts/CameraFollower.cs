using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * <summary>Allows camera to follow player while keeping camera from looking
 * out of bounds.</summary>
 */
public class CameraFollower : Element
{
    public Transform player;
    public float smoothing;

    private float maxX = 0f, maxY = 0f, minX = 0f, minY = 0f;

    private void Start()
    {
        Camera mainCamera = Camera.main;
        player = app.view.player.gameObject.transform;

        maxX = WorldBorder.Instance.maxX;
        maxX -= mainCamera.ViewportToWorldPoint(Vector3.one).x;

        minX = WorldBorder.Instance.minX;
        minX += Mathf.Abs(mainCamera.ViewportToWorldPoint(Vector3.zero).x);

        maxY = WorldBorder.Instance.maxY;
        maxY -= mainCamera.ViewportToWorldPoint(Vector3.one).y;

        minY = WorldBorder.Instance.minY;
        minY += Mathf.Abs(mainCamera.ViewportToWorldPoint(Vector3.zero).y);

    }

    private void Update()
    {
        if (player == null) return;

        Vector3 newPos = new Vector3(player.position.x, 
                                     player.position.y, 
                                     transform.position.z);

        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);

        transform.position = newPos;

    }
}
