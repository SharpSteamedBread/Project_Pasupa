using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public enum FadeState { FadeIn = 0, FadeOut, FadeOnce, FadeLoop }

public class FadeEffectThunder : MonoBehaviour
{
    [SerializeField]
    private float fadeTime = 2;
    private SpriteRenderer image;
    [SerializeField]
    private AnimationCurve fadeCurve;
    [SerializeField]
    private FadeState fadeState;

    [System.Serializable]
    private class FadeEffectEvent : UnityEvent { }
    private FadeEffectEvent fadeEffectEvent = new FadeEffectEvent();

    private void Awake()
    {
        image = GetComponent<SpriteRenderer>();

        /*
        // Fade in �ϱ� ���� ó�� ���İ��� �ִ�� ����
        Color color = image.color;
        color.a = 1;    // �ڵ忡�� rgba���� 0~1 ���̷� ����
        image.color = color;


        // Fade out �ϱ� ���� ó�� ���İ��� 0���� ����
        Color color = image.color;
        color.a = 0;    // �ڵ忡�� rgba���� 0~1 ���̷� ����
        image.color = color;
        */

        //StartCoroutine(Fade(1, 0));
        
        //OnFade();
    }

    private void Update()
    {
        //FadeIn();
        //FadeOut();
    }

    private void FadeIn()
    {
        // image�� color�� ������Ƽ�� a�� ���� ������ �Ұ��ϱ⿡ ������ �����ؼ� Ȱ��
        Color color = image.color;

        // ���č��� 0���� ũ�� ���İ� ����
        if (color.a > 0)
        {
            color.a -= Time.deltaTime / fadeTime;
        }

        // �ٲ� ���� ������ image color�� ����
        image.color = color;
    }

    private void FadeOut()
    {
        // image�� color�� ������Ƽ�� a�� ���� ������ �Ұ��ϱ⿡ ������ �����ؼ� Ȱ��
        Color color = image.color;

        // ���č��� 1���� ������ ���İ� ����
        if (color.a < 1)
        {
            color.a += Time.deltaTime / fadeTime;
        }

        // �ٲ� ���� ������ image color�� ����
        image.color = color;
    }

    private IEnumerator Fade(float start, float end)
    {
        float current = 0;
        float percent = 0;

        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / fadeTime;

            Color color = image.color;
            //color.a = Mathf.Lerp(start, end, percent);
            color.a = Mathf.Lerp(start, end, fadeCurve.Evaluate(percent));

            image.color = color;
        }

        yield return null;

        if(fadeState == FadeState.FadeIn || fadeState == FadeState.FadeOut)
        {
            // ��ϵ� �̺�Ʈ �޼ҵ带 ����
            fadeEffectEvent.Invoke();
            // ��ϵ� �̺�Ʈ �޼ҵ带 ��� ����
            fadeEffectEvent.RemoveAllListeners();
        }
    }

    public void OnFade(UnityAction action)
    {
        //action �޼ҵ带 �̺�Ʈ �޼ҵ�� ���
        fadeEffectEvent.AddListener(action);

        switch(fadeState)
        {
            case FadeState.FadeIn:
                StartCoroutine(Fade(1, 0));
                break;
            case FadeState.FadeOut:
                StartCoroutine(Fade(0, 1));
                break;
            case FadeState.FadeOnce:
            case FadeState.FadeLoop:
                StartCoroutine(FadeInOut());
                break;
        }
    }

    private IEnumerator FadeInOut()
    {
        while(true)
        {
            //�ڷ�ƾ ���ο��� yield return���� �ڷ�ƾ �޼ҵ带 ȣ���ϸ� �ش� �ڷ�ƾ�� ����Ǿ�� ���� �ڵ� ����
            yield return StartCoroutine(Fade(1, 0));
            yield return StartCoroutine(Fade(0, 1));

            //FadeOnce�� 1ȸ�� �ݺ��ϱ� ������ yield break;�� �ڷ�ƾ ����
            if(fadeState == FadeState.FadeOnce)
            {
                // ��ϵ� �̺�Ʈ �޼ҵ带 ����
                fadeEffectEvent.Invoke();
                //��ϵ� �̺�Ʈ �޼ҵ带 ��� ����
                fadeEffectEvent.RemoveAllListeners();

                yield break;
            }    
        }
    }
}
