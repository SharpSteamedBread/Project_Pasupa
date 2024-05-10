using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToward : MonoBehaviour
{
    public GameObject targetObject;  // �̵��� ��� ������Ʈ
    public float speed = 1.0f;  // �̵� �ӵ�

    public bool Left;
    public bool Right;
    //Vector3 newPosition;

    private void Update()
    {
        float step = speed * Time.deltaTime;  // �̵� �Ÿ� ���
        Vector3 currentPosition = targetObject.transform.position;  // ���� ��ġ��

        // ���� ��ġ���� �������� �̵��� ��ġ�� ���
        if(Left)
        {
            Vector3 newPosition = new Vector3(currentPosition.x - step, currentPosition.y, currentPosition.z);
            targetObject.transform.position = newPosition;  // ���ο� ��ġ�� �̵�
        }
        if (Right)
        {
            Vector3 newPosition = new Vector3(currentPosition.x + step, currentPosition.y, currentPosition.z);
            targetObject.transform.position = newPosition;  // ���ο� ��ġ�� �̵�
        }

    }
}