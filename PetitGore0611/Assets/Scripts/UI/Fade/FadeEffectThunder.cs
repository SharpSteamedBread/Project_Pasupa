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
        // Fade in 하기 위해 처음 알파값을 최대로 설정
        Color color = image.color;
        color.a = 1;    // 코드에서 rgba값은 0~1 사이로 통제
        image.color = color;


        // Fade out 하기 위해 처음 알파값을 0으로 설정
        Color color = image.color;
        color.a = 0;    // 코드에서 rgba값은 0~1 사이로 통제
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
        // image의 color는 프로퍼티로 a만 따로 설정이 불가하기에 변수에 저장해서 활용
        Color color = image.color;

        // 알파랎이 0보다 크면 알파값 감소
        if (color.a > 0)
        {
            color.a -= Time.deltaTime / fadeTime;
        }

        // 바뀐 색상 정보를 image color에 저장
        image.color = color;
    }

    private void FadeOut()
    {
        // image의 color는 프로퍼티로 a만 따로 설정이 불가하기에 변수에 저장해서 활용
        Color color = image.color;

        // 알파랎이 1보다 작으면 알파값 증가
        if (color.a < 1)
        {
            color.a += Time.deltaTime / fadeTime;
        }

        // 바뀐 색상 정보를 image color에 저장
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
            // 등록된 이벤트 메소드를 실행
            fadeEffectEvent.Invoke();
            // 등록된 이벤트 메소드를 모두 제거
            fadeEffectEvent.RemoveAllListeners();
        }
    }

    public void OnFade(UnityAction action)
    {
        //action 메소드를 이벤트 메소드로 등록
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
            //코루틴 내부에서 yield return으로 코루틴 메소드를 호출하면 해당 코루틴이 종료되어야 다음 코드 실행
            yield return StartCoroutine(Fade(1, 0));
            yield return StartCoroutine(Fade(0, 1));

            //FadeOnce는 1회만 반복하기 때문에 yield break;로 코루틴 종료
            if(fadeState == FadeState.FadeOnce)
            {
                // 등록된 이벤트 메소드를 실행
                fadeEffectEvent.Invoke();
                //등록된 이벤트 메소드를 모두 제거
                fadeEffectEvent.RemoveAllListeners();

                yield break;
            }    
        }
    }
}
