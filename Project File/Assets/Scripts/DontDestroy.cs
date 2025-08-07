using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // 현재 Scene의 이름 가져오기

    }


    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0 ||
            SceneManager.GetActiveScene().buildIndex == 9 ||
            SceneManager.GetActiveScene().buildIndex == 10)
        {
            Debug.Log("삭제!!");
            Destroy(gameObject);
        }


        // 현재 Scene의 이름 가져오기
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Scene 이름이 "BossClear"인 경우 해당 오브젝트 삭제
        if (currentSceneName == "BossClear" &&  gameObject.CompareTag("AudioManager") == false)
        {
            Debug.Log("삭제!!");
            Destroy(gameObject);
        }

    }
}
