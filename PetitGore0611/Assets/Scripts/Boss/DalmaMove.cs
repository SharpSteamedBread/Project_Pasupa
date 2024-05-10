using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DalmaMove : MonoBehaviour
{
    [Header("공격력")]
    [SerializeField] private int valueDalmaAtk;

    [Header("이동")]
    [SerializeField] private bool isPosLeft = true;
    [SerializeField] private float moveSpeed = 0.0f;

    [Header("이펙트")]
    [SerializeField] private GameObject objDalmaEffect;

    [SerializeField] private GameObject gameoverUIBossPattern4;

    private int valuePlayerHP;
    private int valuePlayerHPAft;

    private void Awake()
    {
        valuePlayerHP = FindObjectOfType<PlayerStatus>().currHP;
    }

    void Update()
    {
        valuePlayerHP = FindObjectOfType<PlayerStatus>().currHP;

        Move();
    }

    private void Move()
    {
        if(isPosLeft == true)
        {
            transform.Translate(new Vector3(moveSpeed, 0, 0) * Time.deltaTime, Space.Self);
        }

        else
        {
            transform.Translate(new Vector3(-moveSpeed, 0, 0) * Time.deltaTime, Space.Self);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BossBoundary"))
        {
            Destroy(gameObject);
        }

        if(collision.CompareTag("GroundForDalma"))
        {
            objDalmaEffect.SetActive(true);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            HitPlayer();

            if (collision.gameObject.CompareTag("Player"))
            {
                HitPlayer();

                if (FindObjectOfType<PlayerStatus>().currHP <= 0)
                {
                    FindObjectOfType<PlayerStatus>().currHP = 0;
                    Time.timeScale = 0;

                    Instantiate(gameoverUIBossPattern4);
                }
            }
        }
    }
    private void HitPlayer()
    {
        valuePlayerHPAft = valuePlayerHP - valueDalmaAtk;
        FindObjectOfType<PlayerStatus>().currHP = valuePlayerHPAft;
    }
}
