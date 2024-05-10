using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class FadeEffect_Main_Text : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime;
    private TMP_Text textMeshPro1;


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
            textMeshPro1 = GetComponent<TMP_Text>();
            fadeTime = 2;

            StartCoroutine(FadeIn(0, 1));

        }
    }
    public void FadeOut()
    {
        if (!isFading)
        {
            textMeshPro1 = GetComponent<TMP_Text>();
            fadeTime = 1;

            StartCoroutine(FadeOutCoroutine(1,0));
        }
    }

    private IEnumerator FadeIn(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;
        Color originalTextColor1 = textMeshPro1.color;
        Color targetTextColor1 = new Color(originalTextColor1.r, originalTextColor1.g, originalTextColor1.b, end);


        isFading = true;
        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color textColor1 = Color.Lerp(originalTextColor1, targetTextColor1, percent);
            textMeshPro1.color = textColor1;



            yield return null;
        }
        Debug.Log("FadeIn Complete");
        isFading = false;
    }
    private IEnumerator FadeOutCoroutine(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        Color originalTextColor1 = textMeshPro1.color;
        Color targetTextColor1 = new Color(originalTextColor1.r, originalTextColor1.g, originalTextColor1.b, end);

        isFading = true;

        while (percent < 1)
        {
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            Color textColor1 = Color.Lerp(originalTextColor1, targetTextColor1, percent);
            textMeshPro1.color = textColor1;


            yield return null;
        }
        isFading = false;   
        // FadeOut�� ������ ����Ǿ��� �� ���� ������ �����մϴ�.
        // �� ���� ���ϴ� ������ �߰��ϸ� �˴ϴ�.
        Debug.Log("FadeOut Complete");
    }
    private void OnEnable()
    {
        //FadeIn();
    }
    private void OnDisable()
    {
        FadeOut();
    }
}
