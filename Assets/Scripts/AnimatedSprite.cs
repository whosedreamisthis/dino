using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    public Sprite[] sprites;
    int frame;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        frame = 0;
    }

    void OnEnable()
    {
        Invoke(nameof(Animate), 0f);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
    void Animate()
    {
        frame++;
        if (frame >= sprites.Length)
        {
            frame = 0;
        }
        if (frame >= 0 && frame < sprites.Length)
        {
            spriteRenderer.sprite = sprites[frame];
        }

        Invoke(nameof(Animate), 1 / GameManager.Instance.gameSpeed);
    }
}
