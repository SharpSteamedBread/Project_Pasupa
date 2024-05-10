using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematic_panel : MonoBehaviour
{
    public RectTransform panelRectTransform;
    public float startOffset = -100f; // ���� ��ġ
    public float endOffset = -44f; // ��ǥ ��ġ
    public float transitionTime = 1f; // ��ȭ�� �ɸ��� �ð�

    private float currentOffset; // ���� ��ġ
    private float timer; // �ð� ������ Ÿ�̸�

    private bool isTransitioning = false; // ��ȭ ������ ����

    private void Start()
    {
        // ���� �� �г��� �ʱ� ��ġ�� ����
        currentOffset = startOffset;
        panelRectTransform.anchoredPosition = new Vector2(0f, currentOffset);
    }

    private void Update()
    {
        if (isTransitioning)
        {
            // �ð� ������Ʈ
            timer += Time.deltaTime;

            // ���� ��ġ�� ��ǥ ��ġ�� �����Ͽ� �г� �̵�
            float t = Mathf.Clamp01(timer / transitionTime);
            currentOffset = Mathf.Lerp(startOffset, endOffset, t);
            panelRectTransform.anchoredPosition = new Vector2(0f, currentOffset);

            // ��ȭ �Ϸ� üũ
            if (t >= 1f)
            {
                isTransitioning = false;
            }
        }
    }

    public void StartCinematic()
    {
        // �ó׸�ƽ �г� ��ȭ ����
        isTransitioning = true;
        timer = 0f;
    }

    public void EndCinematic()
    {
        // �ó׸�ƽ �г� ������ ��ȭ ����
        isTransitioning = true;
        timer = 0f;
        currentOffset = endOffset;
        endOffset = startOffset;
        startOffset = currentOffset;
    }
}
