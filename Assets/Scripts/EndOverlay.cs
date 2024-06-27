using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOverlay : MonoBehaviour
{
    [SerializeField]
    private RectTransform rectTransform;

    [SerializeField]
    private float targetHeight = 600f;

    [SerializeField]
    private float duration = 20f;

    public void RollCredits()
    {
        StartCoroutine(RollCreditsCoroutine());
    }

    private IEnumerator RollCreditsCoroutine()
    {
        float elapsedTime = 0f;
        float startHeight = rectTransform.sizeDelta.y;

        while (elapsedTime < duration)
        {
            float height = Mathf.Lerp(startHeight, targetHeight, elapsedTime / duration);
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, height);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, targetHeight);
    }
}
