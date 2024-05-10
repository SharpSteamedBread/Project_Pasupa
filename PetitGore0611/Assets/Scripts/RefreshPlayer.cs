using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefreshPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlaySFX("Refresh");
            FindObjectOfType<PlayerStatus>().currHP = FindObjectOfType<PlayerStatus>().maxHP;
            Debug.Log("È¸º¹µÊ~");
        }
    }
}
