using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyList;
    private int enemySpawnNum;
    [SerializeField] private GameObject objSpawnPoint;



    private void Awake()
    {
        objSpawnPoint.GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpawnEnemys();
            Destroy(this);
        }
    }

    private void SpawnEnemys()
    {
        enemySpawnNum = Random.Range(0, enemyList.Length);
        Instantiate(enemyList[enemySpawnNum], objSpawnPoint.transform);
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1.0f);
    }
}
