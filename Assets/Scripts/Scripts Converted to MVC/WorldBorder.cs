using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBorder : Element
{
    [Header("List the number of repeated background sprites", order = 0)]
    [Header("in both directions not including center. So if", order = 1)]
    [Header("there are three background tiles on both sides", order = 2)]
    [Header("of center one, put 3 in x not 4. Make background", order = 3)]
    [Header("symmetrical as well", order = 4)]
    public int tilesInX;
    public int tilesInY;
    [Space(20)]
    public Sprite backgroundSprite;
    public static WorldBorder Instance;

    [SerializeField]
    public float maxX = 0f, maxY = 0f, minX = 0f, minY = 0f;

    /*
     * Current max x where the background ends is +- 28.8
     * which is (sprite.width / 2) * 3
     * OR
     * (sprite.width / 2) + (9.6 * (tilesInX * 2))
     * For max y and min y it's the same formula with tilesInY
     */

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;

            float spriteX = backgroundSprite.rect.width / 100f;
            float spriteY = backgroundSprite.rect.height / 100f;

            int tileMultiplyerX = 0;
            int tileMultiplyerY = 0;

            if (tilesInX > 0) tileMultiplyerX = tilesInX + 1;
            if (tilesInY > 0) tileMultiplyerY = tilesInY + 1;

            gameObject.GetComponent<BoxCollider2D>().size = new Vector2(spriteX + (spriteX * tileMultiplyerX),
                                                                        spriteY + (spriteY * tileMultiplyerY));

            maxX = (spriteX / 2f) + ((spriteX / 2f) * (tilesInX * 2));
            minX = -maxX;

            maxY = (spriteY / 2) + ((spriteY / 2f) * (tilesInY * 2));
            minY = -maxY;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Element temp = collision.gameObject.GetComponent<Element>();

        if (temp is PlayerView)
        {
            Destroy(collision.gameObject);
        }
    }
}
