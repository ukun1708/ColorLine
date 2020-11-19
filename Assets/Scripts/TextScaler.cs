using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScaler : MonoBehaviour
{
    public float speedScale = 5f;

    public static TextScaler Singleton;
    void Start()
    {
        Singleton = this;
        ScalerText();
    }

    public void ScalerText()
    {
        StartCoroutine(TxtScaler());
    }

    IEnumerator TxtScaler()
    {
        RectTransform rect = GetComponent<RectTransform>();
        Vector3 originalScale = rect.localScale;
        Vector3 scaledScale = new Vector3(0.8f, 0.8f, 0.8f);

        while (true)
        {
            for (float i = 0.01f; i < speedScale; i++)
            {
                rect.localScale = Vector3.Lerp(originalScale, scaledScale, Mathf.Min(1f, i / speedScale));
                yield return null;
            }

            for (float i = 0.01f; i < speedScale; i++)
            {
                rect.localScale = Vector3.Lerp(scaledScale, originalScale, Mathf.Min(1f, i / speedScale));
                yield return null;
            }
        }
    }
}
