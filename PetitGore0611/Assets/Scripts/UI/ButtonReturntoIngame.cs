using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReturntoIngame : MonoBehaviour
{
    [SerializeField] private GameObject objPauseUI;

    public void ActivePauseUI()
    {
        objPauseUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReturntoIngame()
    {
        Time.timeScale = 1;
        objPauseUI.SetActive(false);
    }
}
