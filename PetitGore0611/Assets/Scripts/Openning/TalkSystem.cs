using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Dialogue2
{
    [TextArea]
    public string Text;
    //public GameObject Targetposition;
    public Sprite cg;
    public bool left;

        public bool Ririca;
        public bool Subel;
        public bool Boss;
        public bool Who;


}

public class TalkSystem : MonoBehaviour
{
    public GameObject CanvasSprite;
    public GameObject Canvas;


    public GameObject EventObj;

    public bool Opening;
    public bool BossIntro;
    public bool BossClear;

    [SerializeField] private GameObject Add_data1;
    [SerializeField] private GameObject Add_data2;
    [SerializeField] private GameObject Add_data3;
    private GameObject Quest_data;
    [SerializeField] private Transform spawnPoint;


    private Vector3 namepos;
    private Vector2 CGpos;
    public GameObject LeftNamepos;
    public GameObject RightNamepos;


    //[SerializeField] private GameObject NamePanel;
    [SerializeField] public Image RiricaImage;
    [SerializeField] public Image SubelImage;
    [SerializeField] public Image BossImage;

    [SerializeField] public GameObject DialogueBox;

    [SerializeField] private TMP_Text txt_Dialogue;

    public GameObject WhoName;
    public GameObject RiricaName;
    public GameObject SubelName;
    public GameObject BossName;

    public GameObject LeftCG;
    public GameObject RightCG;

    //[SerializeField] private SpriteRenderer sprite_StandingCG;


    private bool isDialogue = false;

    [SerializeField]  private int count = 0;

    [SerializeField] private Dialogue2[] dialogue;


    Color grayColor = new Color(0.5f, 0.5f, 0.5f);
    Color whiteColor = new Color(1, 1, 1);

    [Header("BGM")]
    [SerializeField] private GameObject objBGMManager;

    [SerializeField] private AudioClip[] bgmAudioClip;
    private AudioSource bgmAudioSource;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            objBGMManager = GameObject.FindGameObjectWithTag("BGM");
            bgmAudioSource = objBGMManager.GetComponent<AudioSource>();

            bgmAudioSource.clip = bgmAudioClip[0];
            bgmAudioSource.Play();
        }
    }

    public void ShowDialogue()
    {
        CanvasSprite.SetActive(true);
        Canvas.SetActive(true);
        OnOff(true);
        LeftorRight();
        ChooseCharactor();
        txt_Dialogue.text = dialogue[count].Text;
        //count = 1;
        //NextDialogue();
    }

    public void OnOff(bool _flag)
    {
        RiricaImage.gameObject.SetActive(_flag);
        SubelImage.gameObject.SetActive(_flag);
        BossImage.gameObject.SetActive(_flag);

        BossName.gameObject.SetActive(_flag);
        SubelName.gameObject.SetActive(_flag);
        RiricaName.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        DialogueBox.gameObject.SetActive(_flag);
        WhoName.gameObject.SetActive(_flag);

        isDialogue = _flag;
    }

    private void NextDialogue()
    {
        //dialogue[count].namepanel.SetActive(true);
        //NamePanel = dialogue[count].namepanel;
        LeftorRight();
        ChooseCharactor();
        txt_Dialogue.text = dialogue[count].Text;
        //sprite_StandingCG.sprite = dialogue[count].cg;
        count++;
    }

    private void LeftorRight()
    {
        if(dialogue[count].left==true)
        {
            txt_Dialogue.alignment = TMPro.TextAlignmentOptions.TopLeft;
            namepos = LeftNamepos.transform.position;
            CGpos = LeftCG.transform.position;
            //sprite_StandingCG.transform.position = new Vector2(CGpos.x, CGpos.y);
            //NamePanel.transform.position = new Vector2(namepos.x, namepos.y);
            //dialogue[count].namepanel.transform.position = new Vector2(namepos.x, namepos.y);

        }

        else
        {

            txt_Dialogue.alignment = TMPro.TextAlignmentOptions.TopRight;
            namepos = RightNamepos.transform.position;
            CGpos = RightCG.transform.position;
            //sprite_StandingCG.transform.position = new Vector2(CGpos.x, CGpos.y);

        }
    }


    
    private void ChooseCharactor()
    {
        if(dialogue[count].Ririca ==true)
        {
            RiricaImage.color = whiteColor;
            BossImage.color = grayColor;
            SubelImage.color = grayColor;

            RiricaImage.transform.position = new Vector2(CGpos.x, CGpos.y);
            RiricaImage.sprite = dialogue[count].cg;
            RiricaImage.gameObject.SetActive(true);
            RiricaName.transform.position = new Vector2(namepos.x, namepos.y);

            RiricaName.gameObject.SetActive(true);
            SubelName.gameObject.SetActive(false);
            BossName.gameObject.SetActive(false);
            WhoName.gameObject.SetActive(false);
        }
        if(dialogue[count].Subel == true)
        {
            SubelImage.color = whiteColor;
            BossImage.color = grayColor;
            RiricaImage.color = grayColor;


            SubelImage.transform.position = new Vector2(CGpos.x, CGpos.y);
            SubelImage.sprite = dialogue[count].cg;
            SubelImage.gameObject.SetActive(true);
            SubelName.transform.position = new Vector2(namepos.x, namepos.y);


            SubelName.gameObject.SetActive(true);
            RiricaName.gameObject.SetActive(false);
            BossName.gameObject.SetActive(false);
            WhoName.gameObject.SetActive(false);

        }
        if(dialogue[count].Boss == true)
        {
            BossImage.color = whiteColor;
            SubelImage.color = grayColor;
            RiricaImage.color = grayColor;

            BossImage.transform.position = new Vector2(CGpos.x, CGpos.y);
            BossImage.sprite = dialogue[count].cg;
            BossImage.gameObject.SetActive(true);
            BossName.transform.position = new Vector2(namepos.x, namepos.y);

            BossName.gameObject.SetActive(true);
            SubelName.gameObject.SetActive(false);
            RiricaName.gameObject.SetActive(false);
            WhoName.gameObject.SetActive(false);
        }
        if (dialogue[count].Who == true)
        {

            RiricaImage.gameObject.SetActive(false);
            SubelImage.gameObject.SetActive(false);
            WhoName.transform.position = new Vector2(namepos.x, namepos.y);

            WhoName.gameObject.SetActive(true);
            BossName.gameObject.SetActive(false);
            SubelName.gameObject.SetActive(false);
            RiricaName.gameObject.SetActive(false);
        }
    }
    

    private void Start()
    {
        isDialogue = true;
        count = 0;
        ShowDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if(BossIntro)
        {
            EventObj= GameObject.Find("EventManager_Boss_Intro");
        }

        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "Openning")
        {
            Opening = true;
        }
        if (sceneName == "BossIntro")
        {
            BossIntro = true;
        }

        if (isDialogue)
        {
            if(Input.GetKeyUp(KeyCode.Space))
            {
                Debug.Log("현재 count 수: " + count);
                if(Opening)
                {
                    Opening_Dialogaue();
                }
                if (BossIntro)
                {
                    if (count < dialogue.Length)
                    {
                        NextDialogue();
                        if (count == 2)
                        {
                            StopDialogue();
                        }

                    }
                        if (count == dialogue.Length)
                    {
                        Destroy(Quest_data);
                        StopDialogue();
                    }
                }
                if(BossClear)
                {
                    if (count < dialogue.Length)
                    {
                        NextDialogue();

                    }
                    if (count == 9)
                    {
                        if (SceneManager.GetActiveScene().buildIndex == 8)
                        {
                            bgmAudioSource.Stop();
                            //여기 Bgm 종료 이벤트
                        }
                    }

                    if (count == 11)
                    {
                        if (SceneManager.GetActiveScene().buildIndex == 8)
                        {
                            bgmAudioSource.clip = bgmAudioClip[1];
                            bgmAudioSource.Play();
                            //Bgm  Carnival 변환
                        }

                        StopDialogue();
                    }
                    if (count == 12)
                    {
                        StopDialogue();
                    }
                    if (count == 15)
                    {
                        StopDialogue();
                    }
                    if (count == 16)
                    {
                        StopDialogue();
                    }
                    if (count == dialogue.Length)
                    {
                        StopDialogue();
                    }
                }
            }
        }
    }

    private void StopDialogue()
    {
        if (Opening)
        { GetComponent<EventManager>().animCount++; }
        if (BossIntro)
        { EventObj.GetComponent<EventManager_Boss_Intro>().animCount++; }
        if (BossClear)
        { EventObj.GetComponent<EndEventManager>().animcout++; }
        OnOff(false);
        Canvas.SetActive(false);
        CanvasSprite.SetActive(false);
        GetComponent<TalkSystem>().enabled = false;
    }
    void SpawnObject1()
    {
        Quest_data = Instantiate(Add_data1, spawnPoint.position, Quaternion.identity);
    }
    void SpawnObject2()
    {
        Quest_data = Instantiate(Add_data2, spawnPoint.position, Quaternion.identity);
    }
    void SpawnObject3()
    {
        Quest_data = Instantiate(Add_data3, spawnPoint.position, Quaternion.identity);
    }
    public void DestroyQuestData()
    {
        Destroy(Quest_data);
    }



    void Opening_Dialogaue()
    {
        if (count < dialogue.Length)
        {
            NextDialogue();
            if (count == 1)
            {
                StopDialogue();
            }

            if (count == 2)
            {
                StopDialogue();
            }

            if (count == 5)
            {
                StopDialogue();
            }
            if (count == 12)
            {
                SpawnObject1();
            }
            if (count == 18)
            {
                Destroy(Quest_data);
            }
            if (count == 23)
            {
                SpawnObject2();
            }

            if (count == 24)
            {
                Destroy(Quest_data);
                SpawnObject3();
            }


            else if (count == dialogue.Length)
            {
                Destroy(Quest_data);
                StopDialogue();
            }
        }
    }
}
