using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterIdle : MonoBehaviour
{
    private Rigidbody2D rigid;

    [Header("움직임 관련")]
    [SerializeField] private int nextMove;              // 이동 제어 변수. -1: 왼쪽 0: 대기 1: 오른쪽
    [SerializeField] private float randomSecond;
    public float moveSpeed = 1.0f;    //몬스터 별 움직이는 스피드 제어 변수. 배속 개념으로 생각하심 됩니다!


    private Animator animator;
    private SpriteRenderer monSpriteRenderer;
    private Transform monTransform;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        monSpriteRenderer = GetComponent<SpriteRenderer>();
        monTransform = GetComponent<Transform>();
    }

    private void Start()
    {
        StartCoroutine("RandomWay");
    }

    private void FixedUpdate()
    {
        Move();
        //Debug.Log("움직임~");
        FindHole();
    }

    private void Move()
    {
        rigid.velocity = new Vector2(nextMove * moveSpeed, rigid.velocity.y);

        switch(nextMove)
        {
            case -1:
                //monSpriteRenderer.flipX = false;
                monTransform.transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
                animator.SetBool("isMoving", true);
                break;

            case 0:
                //monSpriteRenderer.flipX = false;
                monTransform.transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
                animator.SetBool("isMoving", false);
                break;

            case 1:
                //monSpriteRenderer.flipX = true;
                monTransform.transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
                animator.SetBool("isMoving", true);
                break;
        }
    }

    private void FindHole()
    {
        //Debug.Log($"움직일 방향은 {nextMove}~");

        //플랫폼 체크 
        //몬스터는 앞을 체크해야 
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.5f, rigid.position.y);
        
        //낭떠러지 감지선
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 0, 1));

        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Ground"));


        if (rayHit.collider == null)
        {
           // Debug.Log("낭떠러지!");
            nextMove = nextMove * (-1);
            StopCoroutine("RandomWay");
            StartCoroutine("RandomWay");
        }
    }

    private IEnumerator RandomWay()
    {
        nextMove = Random.Range(-1, 2);
        randomSecond = Random.Range(1.0f, 3.0f);

        //Debug.Log("생각중");
        
        yield return new WaitForSeconds(randomSecond);

        //Debug.Log("행동중");

        StartCoroutine("RandomWay");
    }

}
