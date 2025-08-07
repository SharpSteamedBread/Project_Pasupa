using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MonsterIdle : MonoBehaviour
{
    private Rigidbody2D rigid;

    [Header("������ ����")]
    [SerializeField] private int nextMove;              // �̵� ���� ����. -1: ���� 0: ��� 1: ������
    [SerializeField] private float randomSecond;
    public float moveSpeed = 1.0f;    //���� �� �����̴� ���ǵ� ���� ����. ��� �������� �����Ͻ� �˴ϴ�!


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
        //Debug.Log("������~");
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
        //Debug.Log($"������ ������ {nextMove}~");

        //�÷��� üũ 
        //���ʹ� ���� üũ�ؾ� 
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 0.5f, rigid.position.y);
        
        //�������� ������
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 0, 1));

        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("Ground"));


        if (rayHit.collider == null)
        {
           // Debug.Log("��������!");
            nextMove = nextMove * (-1);
            StopCoroutine("RandomWay");
            StartCoroutine("RandomWay");
        }
    }

    private IEnumerator RandomWay()
    {
        nextMove = Random.Range(-1, 2);
        randomSecond = Random.Range(1.0f, 3.0f);

        //Debug.Log("������");
        
        yield return new WaitForSeconds(randomSecond);

        //Debug.Log("�ൿ��");

        StartCoroutine("RandomWay");
    }

}
