using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterState : MonoBehaviour
{
    public enum EnemyState { IDLE, CHASE, ATTACK, DAMAGED, DIE, }

    public EnemyState enemyState = EnemyState.IDLE;

    private MonsterIdle objMoveScript;

    private Animator animator;

    [Header("���� ����")]
    [SerializeField] private Vector2 attackArea;
    [SerializeField] private Vector2 chaseArea;
    [SerializeField] private GameObject target;
    [SerializeField] private Transform targetPos;

    [Header("����")]
    [SerializeField] private float attackCooltime = 1.0f;

    [SerializeField] private GameObject objStageController;

    private int valueMonHP;
    private float valueMoveSpeed;
    //private SpriteRenderer monSpriteRenderer;
    private Transform monTransform;

    private bool hasExecuted = false;   //�������� ���� ī��Ʈ �Լ� �� ���� ȣ��

    private void Awake()
    {
        objMoveScript = gameObject.GetComponent<MonsterIdle>();
        animator = GetComponent<Animator>();

        StateChange(EnemyState.IDLE);

        target = GameObject.FindGameObjectWithTag("Player");
        targetPos = target.GetComponent<Transform>();

        valueMonHP = gameObject.GetComponent<MonsterStatus>().monHP;
        valueMoveSpeed = gameObject.GetComponent<MonsterIdle>().moveSpeed;
        //monSpriteRenderer = GetComponent<SpriteRenderer>();
        monTransform = GetComponent<Transform>();

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

        if(gameObject.GetComponent<MonsterIdle>().enabled == false)
        {
            FaceTarget();
        }
    }

    public void StateChange(EnemyState newState)
    {
        /*
         switch (enemyState)
        {
            case EnemyState.IDLE:
                StartCoroutine(IDLE());
                break;
            case EnemyState.ATTACK:
                StartCoroutine(ATTACK());
                break;
            case EnemyState.DAMAGED:
                StartCoroutine(DAMAGED());
                break;
            case EnemyState.DIE:
                StartCoroutine(DIE());
                break;
        }
         */

        StopCoroutine(enemyState.ToString());
        enemyState = newState;
        StartCoroutine(enemyState.ToString());
    }

    private IEnumerator IDLE()
    {
        objMoveScript.enabled = true;
        //Debug.Log("������~");

        yield return null;
    }

    private IEnumerator CHASE()
    {
        //animator.SetBool("isMoving", true);

        float dir = targetPos.position.x - transform.position.x;
        dir = (dir < 0) ? -1 : 1;
        transform.Translate(new Vector2(dir, 0) * valueMoveSpeed * Time.deltaTime);

        yield return null;
    }

    private IEnumerator ATTACK()
    {
        StartCoroutine(StopMove());
        animator.SetTrigger("isAttack");

        yield return null;

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
        Gizmos.DrawWireCube(transform.position, attackArea);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, chaseArea);

        /*
                 Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, targetRange.position);

         */
    }

    private IEnumerator DetectPlayer()
    {
        float distance = Vector2.Distance(targetPos.position, transform.position);

        //Debug.Log($"�÷��̾�-���� �Ÿ�: {distance}, ���� ����: {detectArea.x / 2}");

        if (distance <= attackArea.x / 2)
        {
            //Debug.Log("������!");

            //Debug.Log($"{attackCooltime}�ʰ� ��ٷ�!");
            yield return new WaitForSeconds(attackCooltime);
            //Debug.Log($"����!");
            StateChange(EnemyState.ATTACK);
        }

        else if(distance <= chaseArea.x / 2)
        {
            StateChange(EnemyState.CHASE);
        }

        else
        {
            StateChange(EnemyState.IDLE);
        }

        yield return null;

        StartCoroutine(DetectPlayer());
    }

    private void ReadyToDie()
    {
        valueMonHP = gameObject.GetComponent<MonsterStatus>().monHP;

        if(valueMonHP <= 0)
        {
            StateChange(EnemyState.DIE);
        }
    }

    void FaceTarget()
    {
        if (targetPos.position.x - transform.position.x < 0) // Ÿ���� ���ʿ� ���� ��
        {
            //monSpriteRenderer.flipX = false;
            monTransform.transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        }

        else // Ÿ���� �����ʿ� ���� ��
        {
            //monSpriteRenderer.flipX = true;
            monTransform.transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
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

    private void PlayCakeCatHit()
    {
        AudioManager.instance.PlaySFX("CakeAttackVoice");
    }

    private void PlayYellowJellyBearHit()
    {
        AudioManager.instance.PlaySFX("YellowAttackVoice");
        AudioManager.instance.PlaySFX("YellowAttack");
    }
}
