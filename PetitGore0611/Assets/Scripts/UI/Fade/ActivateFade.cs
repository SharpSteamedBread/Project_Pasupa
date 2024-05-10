using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFade : MonoBehaviour
{
    [SerializeField]
    private FadeEffectThunder fadeEffect;

    private void Start()
    {
        //페이드 효과 재생이 완료되면 AfterFadeEffect 메소드가 실행된다. 
        fadeEffect.OnFade(AfterFadeEffect);
    }

    private void AfterFadeEffect()
    {
        // 페이드 효과를 재생하는 이미지를 비활성화
        fadeEffect.gameObject.SetActive(false);
    }
}
