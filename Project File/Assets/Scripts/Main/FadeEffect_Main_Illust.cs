using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeEffect_Main_Illust : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime;

    private TextMeshProUGUI textMeshPro;
    private Image image;

    private bool isFading = false;  // Coroutine ���� ���θ� ��Ÿ���� ����

    private void Awake()
    {
        //transform.SetAsFirstSibling();
        //FadeIn();
    }

    private void Update()
    {
    }

    public void FadeIn()
    {
        if (!isFading)
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
            image = GetComponent<Image>();

            fadeTime = 2;

            if (textMeshPro != null)
            {
                StartCoroutine(FadeInTextMeshPro(0, 1));
            }
            else if (image != null)
            {
                StartCoroutine(FadeInImage(0, 1));
            }
        }
    }

    public void FadeOut()
    {
        if (!isFading)
        {
            textMeshPro = GetComponent<TextMeshProUGUI>();
            image = GetComponent<Image>();

            fadeTime = 1;

            if (textMeshPro != null)
            {
                StartCoroutine(FadeOutTextMeshPro(1, 0));
            }
            else if (image != null)
            {
                StartCoroutine(FadeOutImage(1, 0));
            }
        }
    }

    private IEnumerator FadeInTextMeshPro(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;
        Color originalTextColor = textMeshPro.color;
        Color targetTextColor = new Color(originalTextColor.r, originalTextColor.g, originalTextColor.b, end);

        isFading = true;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color textColor = Color.Lerp(originalTextColor, targetTextColor, percent);
            textMeshPro.color = textColor;

            yield return null;
        }

        Debug.Log("FadeIn Complete");
        isFading = false;
    }

    private IEnumerator FadeOutTextMeshPro(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        Color originalTextColor = textMeshPro.color;
        Color targetTextColor = new Color(originalTextColor.r, originalTextColor.g, originalTextColor.b, end);

        isFading = true;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color textColor = Color.Lerp(originalTextColor, targetTextColor, percent);
            textMeshPro.color = textColor;

            yield return null;
        }

        isFading = false;
        // FadeOut�� ������ ����Ǿ��� �� ���� ������ �����մϴ�.
        // �� ���� ���ϴ� ������ �߰��ϸ� �˴ϴ�.
        Debug.Log("FadeOut Complete");
    }

    private IEnumerator FadeInImage(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;
        Color originalImageColor = image.color;
        Color targetImageColor = new Color(originalImageColor.r, originalImageColor.g, originalImageColor.b, end);

        isFading = true;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color imageColor = Color.Lerp(originalImageColor, targetImageColor, percent);
            image.color = imageColor;

            yield return null;
        }

        Debug.Log("FadeIn Complete");
        isFading = false;
    }

    private IEnumerator FadeOutImage(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        Color originalImageColor = image.color;
        Color targetImageColor = new Color(originalImageColor.r, originalImageColor.g, originalImageColor.b, end);

        isFading = true;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color imageColor = Color.Lerp(originalImageColor, targetImageColor, percent);
            image.color = imageColor;

            yield return null;
        }

        isFading = false;
        // FadeOut�� ������ ����Ǿ��� �� ���� ������ �����մϴ�.
        // �� ���� ���ϴ� ������ �߰��ϸ� �˴ϴ�.
        Debug.Log("FadeOut Complete");
    }
}

    /*
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime;
    private Image image;


    private bool isFading = false;  // Coroutine ���� ���θ� ��Ÿ���� ����

    private void Awake()
    {
        //FadeIn();
    }
    private void Update()
    {
    }

    public void FadeIn()
    {
        if (!isFading)
        {
            image = GetComponent<Image>();
            fadeTime = 2;

            StartCoroutine(FadeIn(0, 1));

        }
    }
    public void FadeOut()
    {
        if (!isFading)
        {
            image = GetComponent<Image>();
            fadeTime = 1;

            StartCoroutine(FadeOutCoroutine(1,0));
        }
    }

    private IEnumerator FadeIn(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;
        Color originalImageColor = image.color;
        Color targetImageColor = new Color(originalImageColor.r, originalImageColor.g, originalImageColor.b, end);
  

        isFading = true;
        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color imageColor = Color.Lerp(originalImageColor, targetImageColor, percent);
            image.color = imageColor;

          

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

        isFading = true;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color imageColor = Color.Lerp(originalImageColor, targetImageColor, percent);
            image.color = imageColor;


            yield return null;
        }
        isFading = false;   
        // FadeOut�� ������ ����Ǿ��� �� ���� ������ �����մϴ�.
        // �� ���� ���ϴ� ������ �߰��ϸ� �˴ϴ�.
        Debug.Log("FadeOut Complete");
    }
    */
