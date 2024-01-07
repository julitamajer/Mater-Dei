using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FadeSpriteOut : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(FadeSprite());
    }

    IEnumerator FadeSprite()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        Color color = spriteRenderer.color;

        while (color.a > 0)
        {
            color.a -= Time.deltaTime;
            spriteRenderer.color = color;

            yield return null;
        }

        Destroy(gameObject);
    }
}
