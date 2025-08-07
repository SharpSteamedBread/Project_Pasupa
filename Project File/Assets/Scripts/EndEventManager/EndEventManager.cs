using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndEventManager : MonoBehaviour
{
    public GameObject Canvas3;
    public GameObject Fadein;

    public GameObject Boss_Dead1;
    public GameObject Boss_Dead2;
    public GameObject Boss_Dead3;
    public GameObject Boss_Dead4;

    public float targetCameraSize = 3.7f;
    public float targetCameraY = 20f;
    public float transitionSpeed = 0.5f;
    public float smoothSpeed = 5f;

    public Camera mainCamera;
    private Transform cameraTransform;

    private float initialCameraSize;
    private float initialCameraY;

    private bool isTransitioning = false;
    private float transitionProgress = 0.0f;

    private Vector3 velocity = Vector3.zero;

    public GameObject BossCanvas;

    public GameObject Blood;
    public GameObject BossHeart;
    public GameObject BossObj;

    public GameObject CurtainL;
    public GameObject CurtainR;

    public GameObject Patterns;
    public GameObject Subel_Curtain;
    public GameObject Subel_Curtain2;

    public GameObject Curtain1;
    public GameObject Curtain2;


    public GameObject SubelObj;
    public GameObject playerObj;
    public GameObject TalkSystem;

    public int animcout = 0;

    private float timer= 0 ;


    public GameObject CanvasObj;
    public GameObject CanvasSprite;

    [Header("BGM")]
    [SerializeField] private GameObject objBGMManager;
    private AudioSource bgmAudioSource;

    [Header("Sound")]
    private AudioSource effectAudioSource;
    [SerializeField] private AudioClip[] sfxAudioClip;


    // Start is called before the first frame update
    private void Awake()
    {
        CanvasSprite.SetActive(true);
        CanvasObj.SetActive(true);

        //SubelObj = GameObject.Find("sb_stand_0");
        //playerObj = GameObject.Find("Player");
        //TalkSystem = GameObject.Find("TalkSystem");
        TalkSystem.GetComponent<TalkSystem>().BossClear = true;

        //mainCamera = GetComponent<Camera>();
        cameraTransform = mainCamera.transform;

        initialCameraSize = mainCamera.orthographicSize;
        initialCameraY = cameraTransform.position.y;

        animcout++;

        transitionProgress = 0.0f;

        objBGMManager = GameObject.FindGameObjectWithTag("BGM");
        bgmAudioSource = objBGMManager.GetComponent<AudioSource>();
        effectAudioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("현재 animCount 수 " + animcout);
        if(animcout == 1)
        {
            SubelObj.GetComponent<SubelMove>().Animing = true;
            SubelObj.GetComponent<Animator>().SetBool("Obj_Off", true);
            timer += Time.deltaTime;

            if (timer >= 3f)
            {
                animcout++;
                timer = 0;
            }
        }

        if (animcout == 2)
        {
            Talking();
        }

        if (animcout ==3)
        {
            SubelObj.GetComponent<SpriteRenderer>().flipX = false;
            SubelObj.GetComponent<Subel_EndMove>().enabled = true;
            SubelObj.GetComponent<SubelMove>().enabled = false;

            Curtain2.SetActive(true);
            Curtain1.SetActive(true);

            timer += Time.deltaTime;

            if (timer >= 0.8f)
            {
                Patterns.SetActive(true);
                timer = 0;

                mainCamera.GetComponent<CameraController>().enabled = false;
                animcout++;
            }
            isTransitioning = true;
        }
        if (isTransitioning)
        {
            transitionProgress += Time.deltaTime * transitionSpeed;
            transitionProgress = Mathf.Clamp01(transitionProgress);

            float newSize = Mathf.Lerp(initialCameraSize, targetCameraSize, transitionProgress);
            mainCamera.orthographicSize = newSize;

            float newY = Mathf.Lerp(initialCameraY, targetCameraY, transitionProgress);
            Vector3 newPosition = new Vector3(cameraTransform.position.x, newY, cameraTransform.position.z);
            cameraTransform.position = Vector3.SmoothDamp(cameraTransform.position, newPosition, ref velocity, smoothSpeed);

            if (transitionProgress >= 1.0f)
            {
                isTransitioning = false;
            }
        }

        if (animcout == 4)
        {
            timer += Time.deltaTime;
            if (timer >= 4f)
            {
                //Curtain1효과음
                Subel_Curtain.SetActive(true);
                animcout++;
            }
        }

        if (animcout== 5)
        {
            timer += Time.deltaTime;
            if (timer >= 9f)
            {
                Subel_Curtain2.SetActive(true);
                Curtain1.SetActive(false);
            }
            if (timer >= 12f)
            {
                Talking();
                timer = 0;
                animcout++;
            }
        }
        if(animcout==6)
        {
            BossCanvas.SetActive(false);
        }
        if(animcout == 7)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                //SpotLightOn 효과음
                effectAudioSource.clip = sfxAudioClip[0];
                effectAudioSource.Play();
                Boss_Dead1.SetActive(true);
            }
            if (timer >= 2f)
            {
                //스위치_Off 효과음
                effectAudioSource.clip = sfxAudioClip[1];
                effectAudioSource.Play();
                Boss_Dead1.SetActive(false);
            }
            if (timer >= 3f)
            {
                //스위치Next효과음
                //보스_Blooding1
                Boss_Dead2.SetActive(true);
            }
            if (timer >= 4f)
            {
                //스위치_Off 효과음
                effectAudioSource.clip = sfxAudioClip[1];
                effectAudioSource.Play();
                Boss_Dead2.SetActive(false);
            }
            if (timer >= 5f)
            {
                //스위치 On효과음
                //스위치Next효과음
                //보스_Blooding2
                Boss_Dead3.SetActive(true);
            }
            if (timer >= 6f)
            {
                //스위치_Off 효과음
                effectAudioSource.clip = sfxAudioClip[1];
                effectAudioSource.Play();
                Boss_Dead3.SetActive(false);
            }
            if (timer >= 7f)
            {
                //스위치 On효과음
                //스위치Next효과음
                //보스_Blooding3
                Boss_Dead4.SetActive(true);
            }
            if (timer >= 8f)
            {
                //스위치_Off 효과음
                effectAudioSource.clip = sfxAudioClip[1];
                effectAudioSource.Play();
                Boss_Dead4.SetActive(false);
            }
            if (timer >= 10f)           //불 키기
            {
                //SpootLight_On_the_Stage 효과음
                effectAudioSource.clip = sfxAudioClip[0];
                effectAudioSource.Play();
                Subel_Curtain2.SetActive(false);
                Curtain2.SetActive(false);
                Curtain1.SetActive(true);


                SubelObj.GetComponent<SpriteRenderer>().flipX = true;
                SubelObj.GetComponent<SubelMove>().enabled = true;

                Patterns.SetActive(false);

                Blood.SetActive(true);
                BossObj.SetActive(false);
                BossObj.SetActive(false);
                BossHeart.SetActive(true);
            }
            if (timer >= 11f)
            {

                animcout++;
            }
        }
        if(animcout== 8)
        {
            CurtainL.GetComponent<MoveToward>().enabled = true;
            CurtainR.GetComponent<MoveToward>().enabled = true;
            animcout++;
        }
        if(animcout==9)
        {
            targetCameraSize = 2.5f;
            targetCameraY = -100f;
            transitionProgress = 0.0f;
            transitionSpeed = 1f;

            timer += Time.deltaTime;
            if (timer>= 10f)
            {
                isTransitioning = true;
                timer = 0f;
                animcout++;

            }

        }
        if(animcout==10)
        {
            timer += Time.deltaTime;
            if (timer >= 2f)
            {
                SubelObj.GetComponent<SubelMove>().enabled = false;
                SubelObj.GetComponent<Subel_EndMove>().curtaining = true;
                timer = 0;
                animcout++;
            }
        }
        if(animcout==11)
        {
            timer = 0;
        }
        if (animcout == 12)
        {
            SubelObj.GetComponent<Subel_EndMove>().enabled = false;
            Talking();
            BossCanvas.SetActive(false);
            BossHeart.SetActive(false);
        }
        if(animcout==13)
        {
            bgmAudioSource.Stop();
            //여기 Carnival Bgm종료
            SubelObj.GetComponent<SpriteRenderer>().flipX = false;
            SubelObj.GetComponent<Animator>().SetBool("Dancing", false);
            Talking();
            BossCanvas.SetActive(false);
        }
        if (animcout == 14)
        {
            BossCanvas.SetActive(false);
            SubelObj.GetComponent<SpriteRenderer>().flipX = true;
            SubelObj.GetComponent<Subel_EndMove>().enabled = true;
            SubelObj.GetComponent<Subel_EndMove>().curtaining = false;
            SubelObj.GetComponent<Subel_EndMove>().curtaining2 = true;
            timer += Time.deltaTime;
            if (timer >= 5f)
            {
                playerObj.GetComponent<Animator>().SetBool("Idle", false);
                playerObj.GetComponent<Animator>().SetBool("isMoving", true);
                playerObj.GetComponent<Ririca_right>().enabled = true;
            }
            if(timer >= 10f)
            {
                Talking();
                BossCanvas.SetActive(false);
                animcout++;
            }
        }
        if(animcout==15)
        {
            timer = 0;
        }
        if(animcout==16)
        {
            timer += Time.deltaTime;
            if (timer >= 1f)
            {
                Canvas3.SetActive(true);
                Fadein.SetActive(true);
                Fadein.GetComponent<FadeEffect_Main_Illust>().FadeIn();
            }
            if (timer >= 7f)
            {
                animcout++;
            }
        }

        if(animcout == 17)
        {
            SceneManager.LoadScene("CreditVideo");
        }

        if (animcout == 18)
        {
            //SceneManager.LoadScene("CreditVideo");
        }

    }

public void Talking()
    {
        TalkSystem.GetComponent<TalkSystem>().enabled = true;
        TalkSystem.GetComponent<TalkSystem>().ShowDialogue();
    }
}
