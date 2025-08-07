using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour               //애니메이션이 재생이 끝날 때 신호를 주는 코드
{
    private bool isMoving_Boss_Intro = false; // 이동 중인지 여부를 나타내는 변수
    private float targetX ; // 목표 x 좌표
    private float targetX2 =31f; // 목표 x 좌표
    private float moveSpeed = 3f; // 이동 속도


    [SerializeField]
    public GameObject EventObj;       //이벤트관리 오브젝트

    public Animator animator;
    //public string targetClipName;

    public GameObject eventManager; // EventManager 오브젝트

    public bool BossIntro;

    private void Start()
    {
        targetX = 23f;
    }

    private void Update()
    {
    }

    public void BossIntro_Move()
    {
        StartCoroutine(MovePlayer());
    }
    public void BossIntro_Move2()
    {
        StartCoroutine(MovePlayer2());
    }

    private System.Collections.IEnumerator MovePlayer()
    {
        isMoving_Boss_Intro = true;

        while (transform.position.x < targetX)
        {
            // 플레이어를 오른쪽으로 이동시킴
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            yield return null;
        }

        isMoving_Boss_Intro = false;
        EventObj = GameObject.Find("EventManager_Boss_Intro");
        EventObj.GetComponent<EventManager_Boss_Intro>().animCount++;
        Debug.Log("Player movement completed.");
    }
    private System.Collections.IEnumerator MovePlayer2()
    {
        isMoving_Boss_Intro = true;

        while (transform.position.x < targetX2)
        {
            // 플레이어를 오른쪽으로 이동시킴
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

            yield return null;
        }

        isMoving_Boss_Intro = false;
        EventObj = GameObject.Find("EventManager_Boss_Intro");
        EventObj.GetComponent<EventManager_Boss_Intro>().animCount++;
        Debug.Log("Player movement completed.");
    }



    public void timelineEvent()
    {
        GetComponent<Animator>().SetBool("WakeUP2", true);
    }
    public void timelineEvent2()
    {
        GetComponent<Animator>().SetBool("WakeUP2", false);
        GetComponent<Animator>().SetBool("WakeUP0", false);
        EventObj.GetComponent<EventManager>().animCount++;
    }
}


