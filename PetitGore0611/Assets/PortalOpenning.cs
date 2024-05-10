using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalOpenning : MonoBehaviour
{

    [SerializeField] private GameObject objWarpAnim;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
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
