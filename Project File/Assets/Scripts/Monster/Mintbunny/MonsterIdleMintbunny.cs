using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterIdleMintbunny : MonoBehaviour
{
    private Rigidbody2D rigid;

    [Header("움직임 관련")]
    [SerializeField] private int nextMove;              // 이동 제어 변수. -1: 왼쪽 0: 대기 1: 오른쪽
    [SerializeField] private float randomSecond;
    [SerializeField] private float moveSpeed = 1.0f;    //몬스터 별 움직이는 스피드 제어 변수. 배속 개념으로 생각하심 됩니다!

    [SerializeField] private GameObject target;
    private Transform targetPos;

    private Animator animator;
    private SpriteRenderer monSpriteRenderer;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        monSpriteRenderer = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player");
        targetPos = target.GetComponent<Transform>();
    }

    private void Update()
    {
        Move();
        //Debug.Log("움직임~");
    }

    private void Move()
    {
        //rigid.velocity = new Vector2(nextMove * moveSpeed, rigid.velocity.y);

        /*
                 switch (nextMove)
        {
            case -1:
                monSpriteRenderer.flipX = false;
                animator.SetBool("isMoving", true);
                break;

            case 0:
                monSpriteRenderer.flipX = false;
                animator.SetBool("isMoving", false);
                break;

            case 1:
                monSpriteRenderer.flipX = true;
                animator.SetBool("isMoving", true);
                break;
        }
         */

        animator.SetBool("isMoving", true);

        float dir = targetPos.position.x - transform.position.x;
        dir = (dir < 0) ? -1 : 1;
        transform.Translate(new Vector2(dir, 0) * moveSpeed * Time.deltaTime);

    }

}
