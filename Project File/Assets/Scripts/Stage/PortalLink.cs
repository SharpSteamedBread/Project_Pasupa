using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalLink : MonoBehaviour
{
    [SerializeField] private GameObject objStageController;
    private int valueMonCount;
    [SerializeField] private GameObject objWarpAnim;
    private SpriteRenderer spritePortal;
    private AudioSource audioPortalOn;

    private void Awake()
    {
        objStageController = GameObject.FindGameObjectWithTag("StageController");
        valueMonCount = objStageController.GetComponent<StageController>().monCount;
        spritePortal = gameObject.GetComponent<SpriteRenderer>();
        audioPortalOn = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        valueMonCount = objStageController.GetComponent<StageController>().monCount;

        if (valueMonCount <= 0)
        {
            audioPortalOn.enabled = true;
            spritePortal.enabled = true;
        }

        else
        {
            spritePortal.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") 
         /* && Input.GetKey(KeyCode.UpArrow) */
            && valueMonCount <= 0)
        {
           PortalScreenAnimation();
        }
    }

    private void PortalScreenAnimation()
    {
        objWarpAnim.SetActive(true);
    }

    private void Warp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
