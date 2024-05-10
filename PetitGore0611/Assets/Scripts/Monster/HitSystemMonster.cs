using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSystemMonster : MonoBehaviour
{
    [SerializeField] private GameObject objMonStat;

    private int valueMonAtk;
    private int valuePlayerHP;

    private int valuePlayerHPAft;

    [SerializeField] private string enemyType;

    [Header("게임 오버 UI")]
    [SerializeField] private GameObject gameoverUICakeCat;
    [SerializeField] private GameObject gameoverUIYellowJellyBear;
    [SerializeField] private GameObject gameoverUIPurpleJellyBear;
    [SerializeField] private GameObject gameoverUIMintBunny;


    private void Awake()
    {
        valueMonAtk = objMonStat.GetComponent<MonsterStatus>().monAtk1;
        valuePlayerHP = FindObjectOfType<PlayerStatus>().currHP;
    }

    private void Update()
    {
        valueMonAtk = objMonStat.GetComponent<MonsterStatus>().monAtk1;
        valuePlayerHP = FindObjectOfType<PlayerStatus>().currHP;

        //Debug.Log($"{valueMonAtk}, {valuePlayerHP}" );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HitPlayer();
        }
    }

    private void HitPlayer()
    {
        valuePlayerHPAft = valuePlayerHP - valueMonAtk;
        FindObjectOfType<PlayerStatus>().currHP = valuePlayerHPAft;

        if(FindObjectOfType<PlayerStatus>().currHP <= 0)
        {
            FindObjectOfType<PlayerStatus>().currHP = 0;
            Time.timeScale = 0;

            switch(enemyType)
            {
                case("CakeCat"):
                    Instantiate(gameoverUICakeCat);
                    break;

                case ("YellowJellyBear"):
                    Instantiate(gameoverUIYellowJellyBear);
                    break;

                case ("PurpleJellyBear"):
                    Instantiate(gameoverUIPurpleJellyBear);
                    break;

                case ("MintBunny"):
                    Instantiate(gameoverUIMintBunny);
                    break;
            }


        }
    }
}
