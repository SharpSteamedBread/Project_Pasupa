using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitSystem : MonoBehaviour
{
    [SerializeField] private GameObject objBossStat;
    [SerializeField] private GameObject gameoverUIBossPattern1;

    private int valueBossAtk;
   
    private int valuePlayerHP;
    private int valuePlayerHPAft;


    private void Awake()
    {
        valueBossAtk = objBossStat.GetComponent<BossStatus>().bossAtk1;
        valuePlayerHP = FindObjectOfType<PlayerStatus>().currHP;
    }

    private void Update()
    {
        valueBossAtk = objBossStat.GetComponent<BossStatus>().bossAtk1;
        valuePlayerHP = FindObjectOfType<PlayerStatus>().currHP;

        //Debug.Log($"{valueMonAtk}, {valuePlayerHP}" );
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

                Instantiate(gameoverUIBossPattern1);
            }
        }
    }

    private void HitPlayer()
    {
        valuePlayerHPAft = valuePlayerHP - valueBossAtk;
        FindObjectOfType<PlayerStatus>().currHP = valuePlayerHPAft;
        AudioManager.instance.PlaySFX("Boss_Attacked_sound");
    }
}
