using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mark : MonoBehaviour
{
    //[SerializeField]
    //public GameObject EventObj;      //�̺�Ʈ���� ������Ʈ
    private int animationCount = 0;
    private bool isAnimationFinished = false;

    public bool Opening = false;
    public bool BossIntro = false;
    // �ִϸ��̼��� ����� ������ ȣ��Ǵ� �Լ�

    private void Start()
    {

    }

    public void AnimationFinished()
    {
        animationCount++;
        if (animationCount >= 2)
        {
            // �ִϸ��̼��� 3�� ����� ���, �Լ� �� ����
            isAnimationFinished = true;

        }
    }

    // �Լ� ���� ����Ǿ����� Ȯ���ϱ� ���� ���� �Լ�
    private void Update()
    {
        if (isAnimationFinished)
        {
            string sceneName = SceneManager.GetActiveScene().name;
            if (sceneName == "Openning")
            {
                Opening = true;
            }
            if (sceneName == "BossIntro")
            {
                BossIntro = true;
            }
            if (Opening)
            {
                GameObject.Find("EventManager").GetComponent<EventManager>().animCount++;
                Destroy(gameObject);
            }

            // �Լ� ���� ����Ǿ����Ƿ� �߰� ���� ���� ����
            if (BossIntro)
            {
                GameObject.Find("EventManager_Boss_Intro").GetComponent<EventManager_Boss_Intro>().animCount++;
                Destroy(gameObject);
            }
        }
    }


}
