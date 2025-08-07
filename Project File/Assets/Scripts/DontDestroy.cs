using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        // ���� Scene�� �̸� ��������

    }


    private void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0 ||
            SceneManager.GetActiveScene().buildIndex == 9 ||
            SceneManager.GetActiveScene().buildIndex == 10)
        {
            Debug.Log("����!!");
            Destroy(gameObject);
        }


        // ���� Scene�� �̸� ��������
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Scene �̸��� "BossClear"�� ��� �ش� ������Ʈ ����
        if (currentSceneName == "BossClear" &&  gameObject.CompareTag("AudioManager") == false)
        {
            Debug.Log("����!!");
            Destroy(gameObject);
        }

    }
}
