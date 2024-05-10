using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TanukiMove : MonoBehaviour
{
    [Header("���ݷ�")]
    [SerializeField] private int valueTanukiAtk = 10;

    [Header("�÷��̾� ����")]
    [SerializeField] private GameObject target;
    private Transform targetPos;

    [Header("�̵�")]
    [SerializeField] private float moveSpeed = 2.0f;
    private Rigidbody2D rigid;

    [Header("����Ʈ")]
    [SerializeField] private GameObject objTanukiEffect;

    [Header("���� �ִϸ��̼� ����")]
    [SerializeField] private GameObject objBoss;
    private Animator objBossAnimator;
    [SerializeField] private GameObject gameoverUIBossPattern3;

    private int valuePlayerHP;
    private int valuePlayerHPAft;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        targetPos = target.GetComponent<Transform>();

        objBoss = GameObject.FindGameObjectWithTag("Boss");
        objBossAnimator = objBoss.GetComponent<Animator>();

        valuePlayerHP = FindObjectOfType<PlayerStatus>().currHP;

        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        valuePlayerHP = FindObjectOfType<PlayerStatus>().currHP;

        objBossAnimator = objBoss.GetComponent<Animator>();


        if (objBossAnimator.GetBool("bossPattern3") == false)
        {
            rigid.constraints = RigidbodyConstraints2D.None;
        }

        else
        {
            float dirX = targetPos.position.x - transform.position.x;
            //dirX = (dirX < 0) ? -1 : 1;

            float dirY = targetPos.position.y - transform.position.y + 3f;
            //dirY = (dirY < 0) ? -1 : 1;

            transform.Translate(new Vector2(dirX, dirY) * moveSpeed * Time.deltaTime);

            objTanukiEffect.SetActive(true);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GroundForDalma"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            HitPlayer();

            if (FindObjectOfType<PlayerStatus>().currHP <= 0)
            {
                FindObjectOfType<PlayerStatus>().currHP = 0;
                Time.timeScale = 0;

                Instantiate(gameoverUIBossPattern3);
            }
        }
    }
    private void HitPlayer()
    {
        AudioManager.instance.PlaySFX("Nuguri_hit");

        valuePlayerHPAft = valuePlayerHP - valueTanukiAtk;
        FindObjectOfType<PlayerStatus>().currHP = valuePlayerHPAft;
    }
}
