using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManagerCredit : MonoBehaviour
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
        if (timer >= 60f)
        {
            SceneManager.LoadScene("Main2");
        }

        // Esc 키를 누르면 다음 씬으로 넘어갑니다.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main2");
        }
    }
}
