using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneButton : MonoBehaviour
{
    [Header("설정 UI")]
    [SerializeField]
    private GameObject settingUI;
    public GameObject EventObj;
   public string scriptName; // 비활성화할 스크립트의 이름


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
        GameObject[] targetObjects = GameObject.FindGameObjectsWithTag("Fade_Effect"); // 원하는 태그로 오브젝트를 찾습니다.
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
