using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFade : MonoBehaviour
{
    [SerializeField]
    private FadeEffectThunder fadeEffect;

    private void Start()
    {
        //���̵� ȿ�� ����� �Ϸ�Ǹ� AfterFadeEffect �޼ҵ尡 ����ȴ�. 
        fadeEffect.OnFade(AfterFadeEffect);
    }

    private void AfterFadeEffect()
    {
        // ���̵� ȿ���� ����ϴ� �̹����� ��Ȱ��ȭ
        fadeEffect.gameObject.SetActive(false);
    }
}
