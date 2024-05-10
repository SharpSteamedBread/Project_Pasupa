using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToward : MonoBehaviour
{
    public GameObject targetObject;  // 이동할 대상 오브젝트
    public float speed = 1.0f;  // 이동 속도

    public bool Left;
    public bool Right;
    //Vector3 newPosition;

    private void Update()
    {
        float step = speed * Time.deltaTime;  // 이동 거리 계산
        Vector3 currentPosition = targetObject.transform.position;  // 현재 위치값

        // 현재 위치에서 왼쪽으로 이동할 위치값 계산
        if(Left)
        {
            Vector3 newPosition = new Vector3(currentPosition.x - step, currentPosition.y, currentPosition.z);
            targetObject.transform.position = newPosition;  // 새로운 위치로 이동
        }
        if (Right)
        {
            Vector3 newPosition = new Vector3(currentPosition.x + step, currentPosition.y, currentPosition.z);
            targetObject.transform.position = newPosition;  // 새로운 위치로 이동
        }

    }
}