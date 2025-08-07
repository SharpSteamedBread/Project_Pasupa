using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager_Main : MonoBehaviour
{
    public GameObject Logo;
    public GameObject MainImage;
    public GameObject Exit;
    public GameObject Setting;
    public GameObject pressText;
    public GameObject StoryPanel;
    public GameObject StoryPanel_Text;
    public GameObject StoryPanel_Button;
    public GameObject StoryPanel_Button_Text;



    public GameObject VideoPlayer_if;


    public float delay = 8f;

    private float timer = 0f;
    private int timerint = 0;
    [SerializeField]private bool SpacePressed = false;
    [SerializeField]private bool EscPressed = false;
    [SerializeField]private bool Introing;
    float timer2;



    public RectTransform targetRectTransform;
    public float transitionDuration = 1f;

    private bool hasChangedSpacebar = false;
    private bool hasChangedArrowUp = false;
    private float elapsedTime = 0f;
    private Vector2 initialPosition;
    private Vector2 targetPosition;
    private Vector2 savedPosition;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Start()
    {
        timer = 0f;
        timer2 = 0f;
        timerint = 0;
        Introing = true;
        initialPosition = targetRectTransform.anchoredPosition;
        Debug.Log("현재 타임:" + timer);
    }

    private void Update()
    {
        if (Introing)       //일반 시작
        {
            Debug.Log("현재 타임:" + timer);
            timer += Time.deltaTime;
            //timer = timerint;
            if (timer >= 38f)
            {
                Debug.Log("작동해라~~!" + timer);
                MainImage.SetActive(true);
                MainImage.GetComponent<FadeEffect_Main_Illust>().FadeIn();
            }

            if (timer >= 40f)
            {
                Logo.SetActive(true);
                Logo.GetComponent<FadeEffect_Main_Illust>().FadeIn();
            }
            if (timer >= 41f)
            {
                Exit.SetActive(true);
                Setting.SetActive(true);
                pressText.SetActive(true);
                Exit.GetComponent<FadeEffect_Main_Illust>().FadeIn();
                Setting.GetComponent<FadeEffect_Main_Illust>().FadeIn();
                pressText.GetComponent<FadeEffect_Main_Illust>().FadeIn();
            }
            if (timer >= 42f)
            {
                Introing = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))                   //만약 Esc키를 누르면
        {
            EscPressed = true;
            timer = 0;
        }
        if(EscPressed)              //영상을 띄우고 이미지들 뜨고 Introing을 false
        {
            VideoPlayer_if.SetActive(true);
            timer += Time.deltaTime;
            //timer = timerint;
            if (timer >= 3)
            {
                //Debug.Log("작동해라~~!" + timer);
                MainImage.SetActive(true);
                MainImage.GetComponent<FadeEffect_Main_Illust>().FadeIn();
            }

            if (timer >= 5f)
            {
                Logo.SetActive(true);
                Logo.GetComponent<FadeEffect_Main_Illust>().FadeIn();
            }
            if (timer >= 6f)
            {
                Exit.SetActive(true);
                Setting.SetActive(true);
                pressText.SetActive(true);
                Exit.GetComponent<FadeEffect_Main_Illust>().FadeIn();
                Setting.GetComponent<FadeEffect_Main_Illust>().FadeIn();
                pressText.GetComponent<FadeEffect_Main_Illust>().FadeIn();
            }
            if(timer >= 7f)
            {
                Introing = false;
                timer = 0f;
            }
        }


        if (Introing == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !hasChangedSpacebar && !hasChangedArrowUp)
            {
                hasChangedSpacebar = true;
                savedPosition = targetRectTransform.anchoredPosition;
                targetPosition = new Vector2(targetRectTransform.anchoredPosition.x, 999f);
                elapsedTime = 0f;
                SpacePressed = true;
                timer2 = 0;
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) && !hasChangedSpacebar && !hasChangedArrowUp)
            {
                hasChangedArrowUp = true;
                elapsedTime = 0f;
                savedPosition = targetRectTransform.anchoredPosition;
                targetPosition = new Vector2(targetRectTransform.anchoredPosition.x, -999f);
                SpacePressed = false;
                                timer2 = 0;
            }

            if (hasChangedSpacebar || hasChangedArrowUp)
            {
                elapsedTime += Time.deltaTime;

                float t = elapsedTime / transitionDuration;
                t = Mathf.Clamp01(t);

                float posY = Mathf.Lerp(savedPosition.y, targetPosition.y, t);
                Vector2 newPosition = new Vector2(targetRectTransform.anchoredPosition.x, posY);
                targetRectTransform.anchoredPosition = newPosition;

                if (t >= 1f)
                {
                    hasChangedSpacebar = false;
                    hasChangedArrowUp = false;
                    elapsedTime = 0f;
                }
            }
            if (SpacePressed)
            {
                pressText.GetComponent<FadeEffect_Main_Illust>().FadeOut();
                timer2 += Time.deltaTime;
                if (timer2 >= 2f)
                {
                    StoryPanel.SetActive(true);
                    StoryPanel.GetComponent<FadeEffect_Main_Illust>().FadeIn();
                }
                if (timer2 >= 3f)
                {
                    StoryPanel.GetComponent<FadeEffect_Main_Illust>().FadeOut();
                    StoryPanel_Text.GetComponent<FadeEffect_Main_Illust>().FadeIn();
                    StoryPanel_Button.GetComponent<FadeEffect_Main_Illust>().FadeIn();
                    StoryPanel_Button_Text.GetComponent<FadeEffect_Main_Illust>().FadeIn();
                }

            }
            if (!SpacePressed)
            {
                timer2 += Time.deltaTime;
                if (timer2 >= 2f)
                {
                    pressText.GetComponent<FadeEffect_Main_Illust>().FadeIn();
                }
                Debug.Log("FadeOut하세욧");
                StoryPanel.GetComponent<FadeEffect_Main_Illust>().FadeOut();
                StoryPanel_Text.GetComponent<FadeEffect_Main_Illust>().FadeOut();
                StoryPanel_Button.GetComponent<FadeEffect_Main_Illust>().FadeOut();
                StoryPanel_Button_Text.GetComponent<FadeEffect_Main_Illust>().FadeOut();

            }
        }
    }
    

}
