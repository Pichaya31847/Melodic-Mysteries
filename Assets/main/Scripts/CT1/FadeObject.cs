using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer map1;
    [SerializeField] private SpriteRenderer map2;
    private Coroutine currentFadeCoroutine;
    public float fadeDuration = 0.5f; // Adjust the duration as needed

    private void Start()
    {
        Color currentColorMap2 = map2.color;
        currentColorMap2.a = 255f;
        map2.color = currentColorMap2;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (currentFadeCoroutine != null)
            {
                StopCoroutine(currentFadeCoroutine);
            }
            currentFadeCoroutine = StartCoroutine(FadeIn());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (currentFadeCoroutine != null)
            {
                StopCoroutine(currentFadeCoroutine);
            }
            currentFadeCoroutine = StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeIn()
    {
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alphaValueMap1 = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            float alphaValueMap2 = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            Color newColorMap1 = map1.color;
            Color newColorMap2 = map1.color;
            newColorMap1.a = alphaValueMap1;
            newColorMap2.a = alphaValueMap2;
            map1.color = newColorMap1;
            map2.color = newColorMap2;
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alphaValueMap1 = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            float alphaValueMap2 = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            Color newColorMap1 = map1.color;
            Color newColorMap2 = map1.color;
            newColorMap1.a = alphaValueMap1;
            newColorMap2.a = alphaValueMap2;
            map1.color = newColorMap1;
            map2.color = newColorMap2;
            yield return null;
        }
    }
}
