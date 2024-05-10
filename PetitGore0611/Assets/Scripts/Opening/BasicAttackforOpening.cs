using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackforOpening : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private GameObject SubelObj;

    [SerializeField] private int basicAttack;
    [SerializeField] private float attackMove1;
    [SerializeField] private float attackMove2;


    float lastInputTime = 0;
    [SerializeField] private float maxComboDelay = 1.0f;

    private Rigidbody2D rigid;
    private SpriteRenderer spriteRenderer;

    private bool valueCanMove;


    private void Awake()
    {
        attackMove1 = 1.5f;
        attackMove2 = 2.5f;
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        valueCanMove = GetComponent<PlayerMove>().canMove;
    }

    void Update()
    {
        DoBasicAttack();

        if(basicAttack > 3)
        {
            basicAttack = 3;
        }

        
        if(animator.GetBool("basicAttackCombo1") == false && animator.GetBool("basicAttackCombo2") == false
            && animator.GetBool("basicAttackCombo3") == false)
        {
            //SubelObj.GetComponent<SubelMove>().EndCount++;

            basicAttack = 0;
            SubelObj.GetComponent<SubelMove>().EndCount++;
        }
        
    }

    private void DoBasicAttack()
    {
        if (Time.deltaTime - lastInputTime > maxComboDelay)
        {
            animator.SetBool("basicAttackCombo1", false);
            animator.SetBool("basicAttackCombo2", false);
            animator.SetBool("basicAttackCombo3", false);

            //SubelObj.GetComponent<SubelMove>().EndCount++;
            basicAttack = 0;
            SubelObj.GetComponent<SubelMove>().EndCount++;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            lastInputTime = Time.deltaTime;
            basicAttack++;

            //valueCanMove = false;
            //GetComponent<PlayerMove>().canMove = valueCanMove;

            if (basicAttack == 1)
            {
                animator.SetBool("basicAttackCombo1", true);
                AttackMove1();
            }
            //basicAttack = Mathf.Clamp(basicAttack, 0, 3);
        }
    }

    public void LinkCombo2()
    {
        if(basicAttack >= 2)
        {
            animator.SetBool("basicAttackCombo2", true);
            animator.SetBool("basicAttackCombo1", false);
            AttackMove1();
        }

        else
        {
            animator.SetBool("basicAttackCombo1", false);
            basicAttack = 0;

            SubelObj.GetComponent<SubelMove>().EndCount++;

            //SubelObj.GetComponent<SubelMove>().EndCount++;
            //AttackMove();

            valueCanMove = true;
            GetComponent<PlayerMove>().canMove = valueCanMove;

        }
    }

    public void LinkCombo3()
    {
        if (basicAttack >= 3)
        {
            animator.SetBool("basicAttackCombo3", true);
            animator.SetBool("basicAttackCombo2", false);
            AttackMove2();
        }

        else
        {
            animator.SetBool("basicAttackCombo2", false);
            basicAttack = 0;

            SubelObj.GetComponent<SubelMove>().EndCount++;
            //AttackMove();

            // SubelObj.GetComponent<SubelMove>().EndCount++;
            valueCanMove = true;
            GetComponent<PlayerMove>().canMove = valueCanMove;
        }
    }

    public void LinkComboFinish()
    {
        animator.SetBool("basicAttackCombo1", false);
        animator.SetBool("basicAttackCombo2", false);
        animator.SetBool("basicAttackCombo3", false);
        basicAttack = 0;

        SubelObj.GetComponent<SubelMove>().EndCount++;

        // SubelObj.GetComponent<SubelMove>().EndCount++;

        valueCanMove = true;
        GetComponent<PlayerMove>().canMove = valueCanMove;

    }

    private void AttackMove1()
    {
        if(spriteRenderer.flipX == true)
        {
            rigid.velocity = new Vector2(1 * attackMove1, 0);
        }

        else
        {
            rigid.velocity = new Vector2(1 * attackMove1 * (-1), 0);
        }
    }

    private void AttackMove2()
    {
        if (spriteRenderer.flipX == true)
        {
            rigid.velocity = new Vector2(1 * attackMove2, 0);
        }

        else
        {
            rigid.velocity = new Vector2(1 * attackMove2 * (-1), 0);
        }
    }

    private void LockValueBasicAttack()
    {
        animator.SetBool("basicAttackCombo1", false);
        animator.SetBool("basicAttackCombo2", false);
        animator.SetBool("basicAttackCombo3", false);
        basicAttack = 0;

        SubelObj.GetComponent<SubelMove>().EndCount++;

        SubelObj.GetComponent<SubelMove>().EndCount++;
    }
}
