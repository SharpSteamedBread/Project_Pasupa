using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FadeEffect : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime;
    private Image image;
    private TMP_Text textMeshPro1;
    private TMP_Text textMeshPro2;

    private bool isFading = false;  // Coroutine 실행 여부를 나타내는 변수

    private void Awake()
    {
        /*
        image = GetComponentInChildren<Image>();
        textMeshPro = GetComponentInChildren<TMP_Text>();

        StartCoroutine(Fade(0, 1));
        */
        // Fade In: (0, 1)
        // Fade Out: (1, 0)
    }

    public void FadeIn()
    {
        if (!isFading)
        {
            image = GetComponentInChildren<Image>();
            textMeshPro1 = transform.GetChild(1).GetComponentInChildren<TMP_Text>();
            textMeshPro2 = transform.GetChild(2).GetComponentInChildren<TMP_Text>();

            StartCoroutine(FadeIn(0, 1));

        }
    }
    public void FadeOut()
    {
        if (!isFading)
        {
            image = GetComponentInChildren<Image>();
            textMeshPro1 = transform.GetChild(1).GetComponentInChildren<TMP_Text>();
            textMeshPro2 = transform.GetChild(2).GetComponentInChildren<TMP_Text>();

            StartCoroutine(FadeOutCoroutine(1,0));
        }
    }

    private IEnumerator FadeIn(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;
        Color originalImageColor = image.color;
        Color targetImageColor = new Color(originalImageColor.r, originalImageColor.g, originalImageColor.b, end);
        Color originalTextColor1 = textMeshPro1.color;
        Color targetTextColor1 = new Color(originalTextColor1.r, originalTextColor1.g, originalTextColor1.b, end);
        Color originalTextColor2 = textMeshPro2.color;
        Color targetTextColor2 = new Color(originalTextColor2.r, originalTextColor2.g, originalTextColor2.b, end);

        isFading = true;
        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color imageColor = Color.Lerp(originalImageColor, targetImageColor, percent);
            image.color = imageColor;

            Color textColor1 = Color.Lerp(originalTextColor1, targetTextColor1, percent);
            textMeshPro1.color = textColor1;

            Color textColor2 = Color.Lerp(originalTextColor2, targetTextColor2, percent);
            textMeshPro2.color = textColor2;

            yield return null;
        }
        Debug.Log("FadeIn Complete");
        isFading = false;
    }
    private IEnumerator FadeOutCoroutine(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        Color originalImageColor = image.color;
        Color targetImageColor = new Color(originalImageColor.r, originalImageColor.g, originalImageColor.b, end);
        Color originalTextColor1 = textMeshPro1.color;
        Color targetTextColor1 = new Color(originalTextColor1.r, originalTextColor1.g, originalTextColor1.b, end);
        Color originalTextColor2 = textMeshPro2.color;
        Color targetTextColor2 = new Color(originalTextColor2.r, originalTextColor2.g, originalTextColor2.b, end);

        isFading = true;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color imageColor = Color.Lerp(originalImageColor, targetImageColor, percent);
            image.color = imageColor;

            Color textColor1 = Color.Lerp(originalTextColor1, targetTextColor1, percent);
            textMeshPro1.color = textColor1;

            Color textColor2 = Color.Lerp(originalTextColor2, targetTextColor2, percent);
            textMeshPro2.color = textColor2;

            yield return null;
        }
        isFading = false;   
        // FadeOut이 완전히 종료되었을 때 다음 동작을 수행합니다.
        // 이 곳에 원하는 동작을 추가하면 됩니다.
        Debug.Log("FadeOut Complete");
    }
}
