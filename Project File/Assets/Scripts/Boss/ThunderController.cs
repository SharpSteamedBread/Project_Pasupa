using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderController : MonoBehaviour
{
    [SerializeField] private GameObject gameoverUIBossPattern5;

    [Header("공격력")]
    [SerializeField] private int valueThunderAtk = 10;

    [Header("플레이어 감지")]
    [SerializeField] private GameObject target;

    private int valuePlayerHP;
    private int valuePlayerHPAft;


    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        valuePlayerHP = FindObjectOfType<PlayerStatus>().currHP;

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        valuePlayerHP = FindObjectOfType<PlayerStatus>().currHP;
    }

    private void DisableThunder()
    {
        Destroy(transform.parent.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HitPlayer();

            if (FindObjectOfType<PlayerStatus>().currHP <= 0)
            {
                FindObjectOfType<PlayerStatus>().currHP = 0;
                Time.timeScale = 0;

                Instantiate(gameoverUIBossPattern5);
            }
        }
    }
    private void HitPlayer()
    {
        AudioManager.instance.PlaySFX("Electric_Hit_1");

        valuePlayerHPAft = valuePlayerHP - valueThunderAtk;
        FindObjectOfType<PlayerStatus>().currHP = valuePlayerHPAft;
    }
}
