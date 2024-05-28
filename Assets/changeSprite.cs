using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSprite : MonoBehaviour
{
    static int sprites_ctr = 0;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] List<Sprite> sprites = null;

    // Start is called before the first frame update
    void Start()
    {
        if(null != spriteRenderer)
        {
            if(null != sprites)
            {
                spriteRenderer.sprite = sprites[sprites_ctr % sprites.Count];
            }
            sprites_ctr++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
