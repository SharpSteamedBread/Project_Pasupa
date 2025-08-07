using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitSystemPlayer : MonoBehaviour
{
    private int valuePlayerAtk;

    private int valuePlayerAtkMin;
    private int valuePlayerAtkMax;
    private int valuePlayerCrit;

    private int valueMonHP;
    private int valueBossHP;

    private int basicAttackValue;

    [SerializeField] private GameObject hudTextPrefab;
    [SerializeField] private Transform parentTransform;


    private void Awake()
    {
        valuePlayerAtkMin = FindObjectOfType<PlayerStatus>().playerAtkMin;
        valuePlayerAtkMax = FindObjectOfType<PlayerStatus>().playerAtkMax;
        valuePlayerCrit = FindObjectOfType<PlayerStatus>().playerCrit;

        basicAttackValue = 1;
    }

    private void Update()
    {
        valuePlayerAtkMin = FindObjectOfType<PlayerStatus>().playerAtkMin;
        valuePlayerAtkMax = FindObjectOfType<PlayerStatus>().playerAtkMax;
        valuePlayerCrit = FindObjectOfType<PlayerStatus>().playerCrit;

        basicAttackValue = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("때렸다!");

        if (collision.gameObject.CompareTag("DamageBox"))
        {
            //Debug.Log("몬스터다!");

            int randomCrit = Random.Range(1, 101);
            valuePlayerAtk = Random.Range(valuePlayerAtkMin, valuePlayerAtkMax + 1);

            if(randomCrit <= valuePlayerCrit)
            {
                int hitDamage = valuePlayerAtk * basicAttackValue * 2;
                //Debug.Log("크리티컬 데미지: " + hitDamage);

                if(collision.transform.parent.gameObject.CompareTag("Boss"))
                {
                    Debug.Log("보스다~");
                    valueBossHP = collision.transform.GetComponentInParent<BossStatus>().currHP;
                    collision.transform.GetComponentInParent<BossStatus>().currHP = valueBossHP - valuePlayerAtk;
                }

                if (collision.transform.parent.gameObject.CompareTag("Enemy"))
                {
                    valueMonHP = collision.transform.GetComponentInParent<MonsterStatus>().monHP;
                    collision.transform.GetComponentInParent<MonsterStatus>().monHP = valueMonHP - valuePlayerAtk;
                }

                string text = hitDamage.ToString();
                Color color = Color.white;
                Vector2 floatPos = collision.transform.position;
                floatPos.y += 1;

                GameObject clone = Instantiate(hudTextPrefab, floatPos, Quaternion.identity);
                clone.transform.SetParent(parentTransform);
                Bounds bounds = collision.GetComponent<Collider2D>().bounds;
                clone.GetComponent<UIHUDText>().Play(text, color, bounds);

            }

            else
            {
                int hitDamage = valuePlayerAtk * basicAttackValue;
                //Debug.Log("데미지: " + hitDamage);

                if (collision.transform.parent.gameObject.CompareTag("Boss"))
                {
                    Debug.Log("보스다~");
                    valueBossHP = collision.transform.GetComponentInParent<BossStatus>().currHP;
                    collision.transform.GetComponentInParent<BossStatus>().currHP = valueBossHP - valuePlayerAtk;
                }

                if (collision.transform.parent.gameObject.CompareTag("Enemy"))
                {
                    valueMonHP = collision.transform.GetComponentInParent<MonsterStatus>().monHP;
                    collision.transform.GetComponentInParent<MonsterStatus>().monHP = valueMonHP - valuePlayerAtk;
                }

                string text = hitDamage.ToString();
                Color color = Color.yellow;
                Vector2 floatPos = collision.transform.position;
                floatPos.y += 1;

                GameObject clone = Instantiate(hudTextPrefab, floatPos, Quaternion.identity);
                clone.transform.SetParent(parentTransform);
                Bounds bounds = collision.GetComponent<Collider2D>().bounds;
                clone.GetComponent<UIHUDText>().Play(text, color, bounds);

            }
        }
    }

    private void SpawnHUDText(string text)
    {

    }
}
