using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class OpenBossStage : MonoBehaviour
{
    [SerializeField] GameObject objBossMapBoundary;
    [SerializeField] GameObject objBossUI;
    [SerializeField] GameObject objBoss;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.CompareTag("OpenBossStage") && collision.CompareTag("Player"))
        {
            objBossMapBoundary.SetActive(false);
            objBossUI.SetActive(true);
            objBoss.SetActive(true);
        }

        if (gameObject.CompareTag("CloseBossStage") && collision.CompareTag("Player"))
        {
            objBossMapBoundary.SetActive(true);
            objBossMapBoundary.GetComponent<TilemapRenderer>().enabled = false;
        }
    }
}
