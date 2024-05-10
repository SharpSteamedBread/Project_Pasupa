using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float smoothing = 0.2f;
    [SerializeField] Vector2 minCameraBoundary;
    [SerializeField] Vector2 maxCameraBoundary;

    private float targetX = 32.5f; // 목표 X 좌표값
    private float moveSpeed = 2f; // 카메라 이동 속도

    public GameObject PlayerObj;


    private void Update()
    {
        PlayerObj = GameObject.Find("Player");
    }


    private void FixedUpdate()
    {
        Vector3 targetPos = new Vector3(player.position.x, player.position.y, this.transform.position.z);

        //targetPos.x = Mathf.Clamp(targetPos.x, minCameraBoundary.x, maxCameraBoundary.x);
        //targetPos.y = Mathf.Clamp(targetPos.y, minCameraBoundary.y, maxCameraBoundary.y);

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
    }

    public void Boss_Intro_CameraMove()
    {
        GameObject EventObj;
        EventObj = GameObject.Find("EventManager_Boss_Intro");
        float currentX = transform.position.x;
        float newX = Mathf.MoveTowards(currentX, targetX, moveSpeed * Time.deltaTime);
        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z);
        transform.position = newPosition;

        // 목표값에 도달하면 카메라 이동 종료
        if (Mathf.Approximately(newX, targetX))
        {
            Debug.Log("카메라 이동 끝났어요!");
            EventObj.GetComponent<EventManager_Boss_Intro>().animCount++;
        }
    }
}
