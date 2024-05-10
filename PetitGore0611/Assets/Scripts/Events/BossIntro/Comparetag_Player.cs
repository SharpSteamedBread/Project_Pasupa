using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comparetag_Player : MonoBehaviour
{
    [SerializeField]private GameObject EventObj;
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
            Debug.Log("Ãæµ¹Á»..");

            EventObj.SetActive(true);
            EventObj.GetComponent<EventManager_Boss_Intro>().enabled = true;


        }
    }

}
