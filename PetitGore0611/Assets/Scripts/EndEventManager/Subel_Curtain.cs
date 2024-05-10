using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subel_Curtain : MonoBehaviour
{
    public float transitionSpeed = 1.0f;  // �̵� �ӵ�

    private Vector3 initialPosition;  // �ʱ� ��ġ
    private Vector3 targetPosition = Vector3.zero;  // ��ǥ ��ġ (0, 0)

    private bool isTransitioning = false;  // �̵� ������ ����

    private void Start()
    {
        initialPosition = transform.position;
        StartTransition();
    }

    private void Update()
    {
        if (isTransitioning)
        {
            // �̵� �ӵ��� Time.deltaTime�� ���Ͽ� �̵� �Ÿ� ���
            float step = transitionSpeed * Time.deltaTime;

            // ���� ��ġ���� ��ǥ ��ġ�� õõ�� �̵�
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
