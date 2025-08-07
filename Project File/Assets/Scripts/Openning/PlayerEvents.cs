using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents : MonoBehaviour               //�ִϸ��̼��� ����� ���� �� ��ȣ�� �ִ� �ڵ�
{
    private bool isMoving_Boss_Intro = false; // �̵� ������ ���θ� ��Ÿ���� ����
    private float targetX ; // ��ǥ x ��ǥ
    private float targetX2 =31f; // ��ǥ x ��ǥ
    private float moveSpeed = 3f; // �̵� �ӵ�


    [SerializeField]
    public GameObject EventObj;       //�̺�Ʈ���� ������Ʈ

    public Animator animator;
    //public string targetClipName;

    public GameObject eventManager; // EventManager ������Ʈ

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
            // �÷��̾ ���������� �̵���Ŵ
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
            // �÷��̾ ���������� �̵���Ŵ
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


