    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventManager_Boss_Intro : MonoBehaviour
{
    public string nextSceneName;

    public Rigidbody2D BossRigidbody;
    public GameObject EndFadeOut;

    public GameObject CanvasGlitch;

    public GameObject BossMapBoundary;

    public GameObject BossObj_Stop;
    public GameObject BossObj;
    public GameObject BossObj_UI;


    public GameObject InterfaceObj;

    //public GameObject talkpanel;
    public GameObject SubelObj;       //슈벨 오브젝트
    public GameObject PlayerObj;      
    public GameObject PanelObj;       
    private GameObject EscObj;
    private GameObject CameraObj;


    public GameObject CinematicObj1;
    public GameObject CinematicObj2;

    public GameObject TalkSystem;


    public GameObject objectToSpawn;    //느낌표
    public Vector2 spawnPoint;    //느낌표  소환

    private float timer = 0f;
    private float timer2 = 0f;

    public int animCount = 0;


    public bool isTalking;
    private bool Escpress = false;

    public GameObject CanvasObj;
    public GameObject CanvasSprite;

    [SerializeField] private GameObject objBGMManager;

    [SerializeField] private AudioClip[] bgmAudioClip;
    private AudioSource bgmAudioSource;


    private void Awake()
    {
        objBGMManager = GameObject.FindGameObjectWithTag("BGM");
        bgmAudioSource = objBGMManager.GetComponent<AudioSource>();

    }

    // Start is called before the first frame update
    void Start()
    {
        CanvasSprite.SetActive(true);
        CanvasObj.SetActive(true);

        CanvasGlitch = GameObject.Find("CanvasGlitch");
        InterfaceObj = GameObject.Find("CanvasInterface");
        EscObj = GameObject.Find("Esc");
        CameraObj = GameObject.Find("MainCamera");
        InterfaceObj = GameObject.Find("CanvasInterface");
        TalkSystem = GameObject.Find("TalkSystem");
        SubelObj = GameObject.Find("sb_stand_0");
        PlayerObj = GameObject.Find("Player");
        //spawnPoint = GameObject.Find("Markpos").transform;

        InterfaceObj.SetActive(false);

        //PlayerObj.GetComponent<PlayerMove>().playerSpriteRend.flipX = true;
        PlayerObj.GetComponent<PlayerMove>().enabled = false;
        PlayerObj.GetComponent<BasicAttack>().enabled = false;
        TalkSystem.GetComponent<TalkSystem>().enabled = false;
        animCount = 1;
        //SpawnObject();

        spawnPoint = new Vector2(23.6f, -1);
        BossMapBoundary.SetActive(false);
        BossMapBoundary.GetComponent<TilemapRenderer>().enabled = false;

        CanvasGlitch.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("현재 애니메이션 카운트: " + animCount);
        if (animCount == 1)
        {
            bgmAudioSource.Stop();
            //Bgm 종료
            SubelObj.GetComponent<SubelMove>().Animing = true;
            CinematicObj1.GetComponent<Cinematic_panel>().StartCinematic();
            CinematicObj2.GetComponent<Cinematic_panel>().StartCinematic();
            Debug.Log("애니카운트1 ");
            PlayerObj.GetComponent<PlayerEvents>().BossIntro_Move();
            animCount++;
        }
        if(animCount == 2)
        {
           // PlayerObj.GetComponent<Animator>().SetBool("Idle", true);
           // SpawnObject();
            animCount++;
        }
        if(animCount == 3)
        {

        }
        if(animCount ==4)
        {
            PlayerObj.GetComponent<Animator>().SetBool("isMoving", false); ; ;
            PlayerObj.GetComponent<Animator>().SetBool("Idle", true); ;
            SpawnObject();
            animCount++;
        }
        if (animCount == 5)
        {

        }

        if (animCount == 6)
        {
            timer += Time.deltaTime;

            if (timer >= 2f)
            {
                animCount += 1;
                timer = 0;
            }
            Debug.Log("애니카운트5 ");

        }
        if (animCount == 7)
        {
            bgmAudioSource.clip = bgmAudioClip[0];
            bgmAudioSource.Play();
            //Bgm Creep 시작
            CameraObj.GetComponent<CameraController>().enabled = false;
            CameraObj.GetComponent<CameraController>().Boss_Intro_CameraMove();
            //animCount++;
        }
        if (animCount == 8)
        {
            Talking();
        }
        if (animCount == 9)
        {
            PlayerObj.GetComponent<PlayerEvents>().BossIntro_Move2();
            PlayerObj.GetComponent<Animator>().SetBool("Idle", false); ; ;
            PlayerObj.GetComponent<Animator>().SetBool("isMoving", true);
            animCount++;
        }

        if (animCount == 10)
        {

        }
        if(animCount == 11)
        {
            PlayerObj.GetComponent<Animator>().SetBool("isMoving", false); ;
            PlayerObj.GetComponent<Animator>().SetBool("Idle", true); ;

            timer += Time.deltaTime;

            if (timer >= 2f)
            {
                SubelObj.GetComponent<SpriteRenderer>().flipX = true;
                SubelObj.GetComponent<Animator>().SetBool("Obj_On", false);
                SubelObj.GetComponent<Animator>().SetBool("Obj_Off", true);
                animCount += 1;
                timer = 0;
            }
        }
        if(animCount == 12)
        {
            timer += Time.deltaTime;

            if (timer >= 2f)
            {
                Talking();
                animCount += 1;
                timer = 0;
            }
        }
        if(animCount ==13)
        {

        }
        if (animCount == 14)
        {
            //EscObj.GetComponent<FadeEffect>().FadeOut();

            Debug.Log("시네마틱 종료!");
            //PlayerObj.GetComponent<Animator>().SetBool("Idle", true);
            SubelObj.GetComponent<Animator>().SetBool("Disappear", true);
            SubelObj.GetComponent<Animator>().SetBool("Appear", false);
            timer += Time.deltaTime;

            if (timer >= 4f)
            {
                animCount++;
                timer = 0;
            }
        }
        
        if(animCount == 15)
        {
            CinematicObj1.GetComponent<Cinematic_panel>().EndCinematic();
            CinematicObj2.GetComponent<Cinematic_panel>().EndCinematic();

            PlayerObj.GetComponent<PlayerMove>().enabled = true;
            CameraObj.GetComponent<CameraController>().enabled = true;
            PlayerObj.GetComponent<BasicAttack>().enabled = true;

            InterfaceObj.SetActive(true);
            animCount++;
        }
        if (animCount == 16)
        {
            bgmAudioSource.clip = bgmAudioClip[1];
            bgmAudioSource.Play();
            //Bgm Creep이 작아지고 -> Bgm Thunderclap Bgm 전환 
            BossMapBoundary.SetActive(true);
            BossMapBoundary.GetComponent<TilemapRenderer>().enabled = false;

            BossObj.SetActive(true);
            BossObj_Stop.SetActive(false);
            BossObj_UI.SetActive(true);

            SubelObj.GetComponent<SubelMove>().Animing = false;

            animCount++;
            //objBossMapBoundary.SetActive(true);
            //objBossMapBoundary.GetComponent<TilemapRenderer>().enabled = false;
        }
        if(animCount == 17)
        {

        }


        if (BossObj.GetComponent<BossStatus>().currHP <= 0)
        {
            BossRigidbody  = BossObj.GetComponent<Rigidbody2D>();
            BossRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;

           EndFadeOut.transform.SetAsFirstSibling();

            EndFadeOut.GetComponent<FadeEffect_Main_Illust>().FadeIn();
             timer2 += Time.deltaTime;
            Debug.Log("현재시각"+timer2);
            if (timer2 >= 2f)
            {
                SceneManager.LoadScene("BossClear");
            }
            Debug.Log("애니카운트5 ");
        }
    }



    void SpawnObject()
    {
        Instantiate(objectToSpawn, spawnPoint, Quaternion.identity);
    }

    public void Talking()
    {
        TalkSystem.GetComponent<TalkSystem>().enabled = true;
        TalkSystem.GetComponent<TalkSystem>().ShowDialogue();
    }
}


