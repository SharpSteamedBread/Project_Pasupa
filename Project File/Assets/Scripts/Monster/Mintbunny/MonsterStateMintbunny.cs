using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStateMintbunny : MonoBehaviour
{
    public enum EnemyState { SLEEP, WAKEUP, IDLE, ATTACK, DAMAGED, DIE, }

    public EnemyState enemyState = EnemyState.SLEEP;

    private MonsterIdleMintbunny objMoveScript;

    private Animator animator;

    [Header("감지 범위")]
    [SerializeField] private Vector2 detectArea;
    [SerializeField] private GameObject target;
    [SerializeField] private Transform targetRange;

    [Header("공격")]
    [SerializeField] private float attackCooltime = 3.0f;

    [Header("상태 관리")]
    public int iWokeup = 0;   // 공격모드 고정 변수

    [SerializeField] private GameObject objStageController;

    private int valueMonHP;
    private SpriteRenderer monSpriteRenderer;

    private bool hasExecuted = false;   //스테이지 몬스터 카운트 함수 한 번만 호출


    private void Awake()
    {
        objMoveScript = gameObject.GetComponent<MonsterIdleMintbunny>();
        animator = GetComponent<Animator>();

        StateChange(EnemyState.SLEEP);

        target = GameObject.FindGameObjectWithTag("Player");
        targetRange = target.GetComponent<Transform>();

        valueMonHP = gameObject.GetComponent<MonsterStatus>().monHP;
        monSpriteRenderer = GetComponent<SpriteRenderer>();

        objStageController = GameObject.FindGameObjectWithTag("StageController");
        objStageController.GetComponent<StageController>();
    }

    private void Start()
    {
        StartCoroutine(DetectPlayer());
    }

    private void Update()
    {
        ReadyToDie();
        //Debug.Log(enemyState);
        //Debug.Log(iWokeup);
        
        if (iWokeup >= 1)
        {
            FaceTarget();
        }
    }

    public void StateChange(EnemyState newState)
    {
        StopCoroutine(enemyState.ToString());
        enemyState = newState;
        StartCoroutine(enemyState.ToString());
    }

    private IEnumerator SLEEP()
    {
        yield return null;
    }

    private IEnumerator WAKEUP()
    {
        //Debug.Log("일어나~");
        iWokeup++;
        animator.SetTrigger("isDetected");

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Mintbunny_idle"))
        {
            //Debug.Log("움직인다~");

            //StateChange(EnemyState.IDLE);
        }
        yield return null;
    }

    private IEnumerator IDLE()
    {
        objMoveScript.enabled = true;
        //Debug.Log("움직임~");

        yield return null;
    }

    private IEnumerator ATTACK()
    {
        StartCoroutine(StopMove());
        animator.SetTrigger("isAttack");

        yield return null;

        //StateChange(EnemyState.ATTACK);
    }

    private IEnumerator DAMAGED()
    {
        StartCoroutine(StopMove());
        animator.SetTrigger("isDamaged");

        yield return null;
    }

    private IEnumerator DIE()
    {
        StartCoroutine(StopMove());
        animator.SetBool("isDie", true);

        yield return null;
    }

    private IEnumerator StopMove()
    {
        StopCoroutine(IDLE());
        StopCoroutine(DetectPlayer());
        objMoveScript.enabled = false;
        animator.SetBool("isMoving", false);

        yield return null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, detectArea);
    }

    private IEnumerator DetectPlayer()
    {
        float distance = Vector2.Distance(targetRange.position, transform.position);

        //Debug.Log($"플레이어-몬스터 거리: {distance}, 감지 범위: {detectArea.x / 2}");

        if (distance <= detectArea.x / 2 && iWokeup == 0)
        {
            StateChange(EnemyState.WAKEUP);
        }

        if (distance <= detectArea.x / 2 && iWokeup >= 1)
        {
            //Debug.Log($"{attackCooltime}초간 기다려!");
            yield return new WaitForSeconds(attackCooltime);
            //Debug.Log($"{attackCooltime}초 끝!");

            StateChange(EnemyState.ATTACK);
        }

        else
        {
            if(iWokeup == 0)
            {
                StateChange(EnemyState.SLEEP);
            }

            if (iWokeup == 1)
            {
                StateChange(EnemyState.IDLE);
            }
        }

        yield return null;

        StartCoroutine(DetectPlayer());
    }

    private void ReadyToDie()
    {
        valueMonHP = gameObject.GetComponent<MonsterStatus>().monHP;

        if (valueMonHP <= 0)
        {
            StateChange(EnemyState.DIE);
        }
    }

    void FaceTarget()
    {
        if (targetRange.position.x - transform.position.x < 0) // 타겟이 왼쪽에 있을 때
        {
            monSpriteRenderer.flipX = false;
        }

        else // 타겟이 오른쪽에 있을 때
        {
            monSpriteRenderer.flipX = true;
        }
    }

    private void StageAffect()
    {
        if (!hasExecuted)
        {
            objStageController.GetComponent<StageController>().GettingWeird();

            hasExecuted = true;
        }
    }
}
