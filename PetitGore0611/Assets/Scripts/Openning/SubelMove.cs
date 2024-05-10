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

    //public Transform targetPosition1; // 이동할 목표 위치1

    public Transform Quest_pos; // 이동하는 목표 위치
    public Transform targetPos2; // 이동할 목표 위치2
    public Transform targetPos3; // 이동할 목표 위치2
    public Transform PlayerPos; // 이동할 목표 위치2

    public float followSpeed = 1f; // 따라가는 속도

    private Vector3 velocity = Vector3.zero;


    //public Vector2 ObjPos; // 이동할 목표 위치

    public float movementSpeed = 1f; // 이동 속도

    [SerializeField]
    private Animator SubelAnim;

    public bool isMoving = true; // 오브젝트 이동 여부
    public bool Objmode = false; // 오브젝트 이동 여부
    public bool Opening = true; // 오브젝트 이동 여부
    public bool Animing = false; // 오브젝트 이동 여부

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


        GameObject player = GameObject.Find("Player"); // Player 오브젝트 찾기

        if (player != null)
        {
            Animator playerAnimator = player.GetComponent<Animator>(); // Player 오브젝트의 Animator 컴포넌트 참조

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

                    // isJumping이 true일 때의 처리
                    // ...
                }
                //else
                {
                    // isJumping이 false일 때의 처리
                    // ...
                }
            }
            else
            {
                // Player 오브젝트에 Animator 컴포넌트가 없을 때의 처리
                // ...
            }
        }
        else
        {
            // Player 오브젝트를 찾을 수 없을 때의 처리
            // ...
        }
    }

    private void StartAnimation()
    {
        SubelAnim.SetBool("IsMoving", false); // 애니메이션 파라미터 변경 예시
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
        Debug.Log("슈벨사라지는소리");
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
