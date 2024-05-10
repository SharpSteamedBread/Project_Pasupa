using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subel_Openning_Move : MonoBehaviour
{
    public GameObject EventObj;
    public float movementSpeed = 1f; // 이동 속도
    public Transform targetPosition1; // 이동할 목표 위치1
    public bool isMoving = true; // 오브젝트 이동 여부


    [SerializeField]
    private Animator SubelAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            // 현재 위치에서 목표 위치까지 이동
            transform.position = Vector3.MoveTowards(transform.position, targetPosition1.position, movementSpeed * Time.deltaTime);

            // 목표 위치에 도달하면 이동 중지
            if (transform.position == targetPosition1.position)
            {
                isMoving = false;
                // 애니메이션 전환을 위한 함수 호출
                StartAnimation();
                //manager.Action(scanObj);
                EventObj.GetComponent<EventManager>().animCount++;
                isMoving = false;
                GetComponent<Subel_Openning_Move>().enabled = false;
            }
        }
    }
    private void StartAnimation()
    {
        SubelAnim.SetBool("IsMoving", false); // 애니메이션 파라미터 변경 예시
    }
}
