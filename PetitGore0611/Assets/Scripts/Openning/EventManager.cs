using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EventManager : MonoBehaviour                   //PlayerEvents���� ��ȣ�� �ް� ���� ���� Ȱ��ȭ �����ִ� �ڵ�
{
    public GameObject Canvas;       //���� ������Ʈ
    public GameObject Canvas2;

    public GameObject InterfaceObj;

    //public GameObject talkpanel;
    public GameObject SubelObj;       //���� ������Ʈ
    public GameObject PlayerObj;       //���� ������Ʈ
    public GameObject PanelObj;       //���� ������Ʈ
    public GameObject EscObj;
    private GameObject CameraObj;

    public GameObject CinematicObj1;
    public GameObject CinematicObj2;

    private Animator animator;
    public GameObject objectToSpawn;
    public GameObject objectToSpawn2;
    public Transform spawnPoint;

    private float timer = 0f;

    public int animCount = 0;
    public int animCountMark = 0;

    public bool isTalking;
    private bool Escpress = false;

    // Start is called before the first frame update
    void Start()
    {
        Canvas2.SetActive(true);
        Canvas.SetActive(true);

        GetComponent<TalkSystem>().Opening = true;
        EscObj = GameObject.Find("Esc");
        CameraObj = GameObject.Find("MainCamera");
        InterfaceObj = GameObject.Find("CanvasInterface");

        InterfaceObj.SetActive(false);

        PlayerObj.GetComponent<PlayerMove>().playerSpriteRend.flipX = true;
        PlayerObj.GetComponent<PlayerMove>().enabled = false;
        PlayerObj.GetComponent<BasicAttack>().enabled = false;
        //PlayerObj.GetComponent<Animator>().SetBool("Idle", false);
        PlayerObj.GetComponent<Animator>().SetBool("WakeUP0", true);
        //talkpanel.gameObject.SetActive(false);
        GetComponent<TalkSystem>().enabled = false;
        animCount = 1;
        //SpawnObject();

    }


    void Update()
    {
        if (animCount == 1)           //idle���� �ʱ�ȭ
        {
            CinematicObj1.GetComponent<Cinematic_panel>().StartCinematic();
            CinematicObj2.GetComponent<Cinematic_panel>().StartCinematic();
            Debug.Log("�ִ�ī��Ʈ1 ");
            SpawnObject();
            animCount++;
        }
        if (animCount == 2)           //idle���� �ʱ�ȭ
        {
            //Debug.Log("�ִ�ī��Ʈ2 ");
        }


        if (animCount == 3)           //�޻��޻� 3���� �Ϸ� ������ ������ ����ǥ ������Ʈ ����
        {
            Debug.Log("�ִ�ī��Ʈ3 ");
            PlayerObj.GetComponent<Animator>().SetBool("WakeUP1", true);
        }

        if (animCount == 4)            //����ǥ ������Ʈ ���� ���
        {
            EscObj.GetComponent<FadeEffect>().FadeIn();
            Debug.Log("�ִ�ī��Ʈ4 ");
            Talking();
        }

        if (animCount == 5)
        {
            timer += Time.deltaTime;

            if (timer >= 3f)
            {
                animCount += 1;
                timer = 0;
            }
            Debug.Log("�ִ�ī��Ʈ5 ");

        }

        if (animCount == 6)
        {
            Debug.Log("�ִ�ī��Ʈ6 ");
            Talking();

        }

        if (animCount == 7)
        {
            //TalkStop();
            Debug.Log("�ִ�ī��Ʈ7 ");
            SubelObj.GetComponent<Subel_Openning_Move>().enabled = true;
        }

        if (animCount == 8)
        {
            Debug.Log("�ִ�ī��Ʈ8 ");
            Talking();
        }

        if (animCount == 9)//?������ ����
        {
            SpawnObject2();
            animCount++;
        }
        if (animCount == 10)//?������ ����
        {
        }
        if (animCount == 11)
        {
            Talking();
        }
        if (animCount == 12)
        {
            SubelObj.GetComponent<SubelMove>().enabled = true;
            SubelObj.GetComponent<Animator>().SetBool("Disappear", true);
        }
        if (animCount == 13)
        {
            EscObj.GetComponent<FadeEffect>().FadeOut();

            Debug.Log("���� ����!");
            PlayerObj.GetComponent<Animator>().SetBool("WakeUP0", false);
            PlayerObj.GetComponent<Animator>().SetBool("WakeUP2", false);
            //PlayerObj.GetComponent<Animator>().SetBool("Idle", true);
            PlayerObj.GetComponent<PlayerMove>().enabled = true;
            CameraObj.GetComponent<CameraController>().enabled = true;
            PlayerObj.GetComponent<BasicAttack>().enabled = true;

            InterfaceObj.SetActive(true);

            CinematicObj1.GetComponent<Cinematic_panel>().EndCinematic();
            CinematicObj2.GetComponent<Cinematic_panel>().EndCinematic();

            SubelObj.GetComponent<SubelMove>().Animing = false;

            animCount++;
        }


        if (Escpress)
        {
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                EndEvents();
                Escpress = false;
            }
        }
        if (animCount >= 4 && animCount < 13)
        {
            Escpress = true;
        }

    }
    void SpawnObject()
    {
        Instantiate(objectToSpawn, spawnPoint.position, Quaternion.identity);
    }

    void SpawnObject2()
    {
        Instantiate(objectToSpawn2, spawnPoint.position, Quaternion.identity);
    }

    public void Talking()
    {
        GetComponent<TalkSystem>().enabled = true;
        GetComponent<TalkSystem>().ShowDialogue();
    }
    void EndEvents()
    {
        //EscObj.GetComponent<FadeEffect>().FadeOut();
        GetComponent<TalkSystem>().DestroyQuestData();
        SubelObj.GetComponent<Subel_Openning_Move>().enabled = false;
        SubelObj.GetComponent<SubelMove>().enabled = true;

        GetComponent<TalkSystem>().OnOff(false);
        GetComponent<TalkSystem>().enabled = false;
        CameraObj.GetComponent<CameraController>().enabled = true;
        animCount = 12;
    }
}

