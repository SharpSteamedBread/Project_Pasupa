using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subel_Curtain : MonoBehaviour
{
    public float transitionSpeed = 1.0f;  // 이동 속도

    private Vector3 initialPosition;  // 초기 위치
    private Vector3 targetPosition = Vector3.zero;  // 목표 위치 (0, 0)

    private bool isTransitioning = false;  // 이동 중인지 여부

    private void Start()
    {
        initialPosition = transform.position;
        StartTransition();
    }

    private void Update()
    {
        if (isTransitioning)
        {
            // 이동 속도와 Time.deltaTime을 곱하여 이동 거리 계산
            float step = transitionSpeed * Time.deltaTime;

            // 현재 위치에서 목표 위치로 천천히 이동
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (transform.position == targetPosition)
            {
                isTransitioning = false;
            }
        }
    }

    public void StartTransition()
    {
        isTransitioning = true;
    }
}
