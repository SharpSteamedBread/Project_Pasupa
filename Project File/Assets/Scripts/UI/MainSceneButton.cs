using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneButton : MonoBehaviour
{
    [Header("���� UI")]
    [SerializeField]
    private GameObject settingUI;
    public GameObject EventObj;
   public string scriptName; // ��Ȱ��ȭ�� ��ũ��Ʈ�� �̸�


    private void Start()
    {
    }

    public void PressSettingButton()
    {
        settingUI.SetActive(true);
    }

    public void ExitSettingUI()
    {
        settingUI.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void GameStart()
    {
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag("Fade_Effect"); // ���ϴ� �±׷� ������Ʈ�� ã���ϴ�.
        foreach (GameObject obj in targetObjects)
        {
            MonoBehaviour targetScript = obj.GetComponent(scriptName) as MonoBehaviour;
            if (targetScript != null)
            {
                targetScript.enabled = false;
                Debug.Log(scriptName + " script disabled on " + obj.name);
            }
            else
            {
                Debug.Log("Script not found on " + obj.name);
            }
        }


        //EventObj.GetComponent<EventManager_Main>().Timer = 0;
    SceneManager.LoadScene("IntroSceneVideo");
    }

}
