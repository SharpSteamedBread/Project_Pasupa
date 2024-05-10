using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager_IntroScene : MonoBehaviour
{
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 36f)
        {
            SceneManager.LoadScene("Openning");
        }

        // Esc Ű�� ������ ���� ������ �Ѿ�ϴ�.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Openning");
        }
    }
}
