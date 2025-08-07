using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubelMove : MonoBehaviour
{



    private SpriteRenderer spriteRenderer;

    private bool soundPlayed = false;


    public int EndCount = 0;


    public GameObject EventObj;

    //public Transform targetPosition1; // �̵��� ��ǥ ��ġ1

    public Transform Quest_pos; // �̵��ϴ� ��ǥ ��ġ
    public Transform targetPos2; // �̵��� ��ǥ ��ġ2
    public Transform targetPos3; // �̵��� ��ǥ ��ġ2
    public Transform PlayerPos; // �̵��� ��ǥ ��ġ2

    public float followSpeed = 1f; // ���󰡴� �ӵ�

    private Vector3 velocity = Vector3.zero;


    //public Vector2 ObjPos; // �̵��� ��ǥ ��ġ

    public float movementSpeed = 1f; // �̵� �ӵ�

    [SerializeField]
    private Animator SubelAnim;

    public bool isMoving = true; // ������Ʈ �̵� ����
    public bool Objmode = false; // ������Ʈ �̵� ����
    public bool Opening = true; // ������Ʈ �̵� ����
    public bool Animing = false; // ������Ʈ �̵� ����

    private void Start()
    {
        if(Objmode)
        {
            SubelAnim.SetBool("Obj_On", true);
        }

        //Opening = true;

        Quest_pos.transform.position = targetPos2.transform.position;
        //ObjPos = targetPos2.transform.position;
         //SubelAnim.SetBool("IsMoving", true);
        //GetComponent<Animator>();
    }

    private void Update()
    {
        if (Objmode)
        {
            Vector3 desiredPosition = Quest_pos.position;
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 1f / followSpeed);
            transform.position = smoothedPosition;
            if (Animing==false)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    Quest_pos.transform.position = targetPos3.transform.position;
                }

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    Quest_pos.transform.position = targetPos2.transform.position;
                }
            }

            if (EndCount >= 1)
            {
                if (!Animing)
                {
                    SubelAnim.SetBool("Obj_Off", false);
                    SubelAnim.SetBool("Obj_On", true);
                }
                EndCount = 0;
            }

        }


        GameObject player = GameObject.Find("Player"); // Player ������Ʈ ã��

        if (player != null)
        {
            Animator playerAnimator = player.GetComponent<Animator>(); // Player ������Ʈ�� Animator ������Ʈ ����

            if (playerAnimator != null)
            {
                bool isJumping = playerAnimator.GetBool("isJumping");

                if (isJumping == false& Animing ==false)
                {
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        SubelAnim.SetBool("Obj_Off", true);
                        SubelAnim.SetBool("Obj_On", false);
                        SubelAnim.SetBool("Obj_Chip", false);
                        SubelAnim.SetBool("Appear", false);
                    }

                    // isJumping�� true�� ���� ó��
                    // ...
                }
                //else
                {
                    // isJumping�� false�� ���� ó��
                    // ...
                }
            }
            else
            {
                // Player ������Ʈ�� Animator ������Ʈ�� ���� ���� ó��
                // ...
            }
        }
        else
        {
            // Player ������Ʈ�� ã�� �� ���� ���� ó��
            // ...
        }
    }

    private void StartAnimation()
    {
        SubelAnim.SetBool("IsMoving", false); // �ִϸ��̼� �Ķ���� ���� ����
    }

    private void Obj_On()
    {

        transform.position = Quest_pos.position;
        //transform.position = new Vector2(ObjPos.x, ObjPos.y);
        SubelAnim.SetBool("Obj_On", true);
        SubelAnim.SetBool("Obj_Chip", false);
        SubelAnim.SetBool("Obj_Off", false);
        SubelAnim.SetBool("Appear", false);



    }
    private void Obj_Chip()
    {
        if(Opening==false)
        {
            Objmode = true;
            SubelAnim.SetBool("Obj_Chip", true);
            SubelAnim.SetBool("Disappear", false);
            SubelAnim.SetBool("Obj_On", false);
            SubelAnim.SetBool("Appear", false);

        }
        if(Opening==true)
        {
            Objmode = true;
            SubelAnim.SetBool("Obj_Chip", true);
            SubelAnim.SetBool("Disappear", false);
            SubelAnim.SetBool("Obj_On", false);
            SubelAnim.SetBool("Appear", false);
            EventObj.GetComponent<EventManager>().animCount++;
            Opening = false;
        }
    }

    private void Obj_Off()
    {
        AudioManager.instance.PlaySFX("Subel_Off");
        Debug.Log("����������¼Ҹ�");
        SubelAnim.SetBool("Obj_Off", true);
        SubelAnim.SetBool("Obj_Chip", false);
        SubelAnim.SetBool("Obj_On", false);
        SubelAnim.SetBool("Appear", false);
    }
    void Off_Sound()
    {
        AudioManager.instance.PlaySFX("Subel_Off");
    }
    void On_Sound()
    {
        AudioManager.instance.PlaySFX("Subel_On");
    }
    void Rise_Sound()
    {
        AudioManager.instance.PlaySFX("Subel_Rise");
    }
    void Appear_Sound()
    {
        AudioManager.instance.PlaySFX("Subel_appear");
    }
    void Appear()
    {
        if (Animing)
        {
            SubelAnim.SetBool("Appear", true);
            SubelAnim.SetBool("Obj_Off", false);
            SubelAnim.SetBool("Obj_Chip", false);
            SubelAnim.SetBool("Obj_On", false);

        }
        else
        {

        }
    }
}
