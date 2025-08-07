using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematic_panel : MonoBehaviour
{
    public RectTransform panelRectTransform;
    public float startOffset = -100f; // 시작 위치
    public float endOffset = -44f; // 목표 위치
    public float transitionTime = 1f; // 변화에 걸리는 시간

    private float currentOffset; // 현재 위치
    private float timer; // 시간 측정용 타이머

    private bool isTransitioning = false; // 변화 중인지 여부

    private void Start()
    {
        // 시작 시 패널을 초기 위치로 설정
        currentOffset = startOffset;
        panelRectTransform.anchoredPosition = new Vector2(0f, currentOffset);
    }

    private void Update()
    {
        if (isTransitioning)
        {
            // 시간 업데이트
            timer += Time.deltaTime;

            // 현재 위치를 목표 위치로 보간하여 패널 이동
            float t = Mathf.Clamp01(timer / transitionTime);
            currentOffset = Mathf.Lerp(startOffset, endOffset, t);
            panelRectTransform.anchoredPosition = new Vector2(0f, currentOffset);

            // 변화 완료 체크
            if (t >= 1f)
            {
                isTransitioning = false;
            }
        }
    }

    public void StartCinematic()
    {
        // 시네마틱 패널 변화 시작
        isTransitioning = true;
        timer = 0f;
    }

    public void EndCinematic()
    {
        // 시네마틱 패널 역방향 변화 시작
        isTransitioning = true;
        timer = 0f;
        currentOffset = endOffset;
        endOffset = startOffset;
        startOffset = currentOffset;
    }
}
