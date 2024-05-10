using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mark : MonoBehaviour
{
    //[SerializeField]
    //public GameObject EventObj;      //이벤트관리 오브젝트
    private int animationCount = 0;
    private bool isAnimationFinished = false;

    public bool Opening = false;
    public bool BossIntro = false;
    // 애니메이션이 재생될 때마다 호출되는 함수

    private void Start()
    {

    }

    public void AnimationFinished()
    {
        animationCount++;
        if (animationCount >= 2)
        {
            // 애니메이션이 3번 재생된 경우, 함수 값 변경
            isAnimationFinished = true;

        }
    }

    // 함수 값이 변경되었는지 확인하기 위한 예시 함수
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

            // 함수 값이 변경되었으므로 추가 동작 수행 가능
            if (BossIntro)
            {
                GameObject.Find("EventManager_Boss_Intro").GetComponent<EventManager_Boss_Intro>().animCount++;
                Destroy(gameObject);
            }
        }
    }


}
