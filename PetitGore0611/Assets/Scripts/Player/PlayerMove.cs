using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMove : MonoBehaviour
{

  [Header("이동 관련")]
    [SerializeField] private float moveSpeed = 4.0f;
    [SerializeField] private float h, v = 0;
    [SerializeField] private float jumpPower = 5.0f;
    [SerializeField] private float knockbackTime = 1.0f;
    [SerializeField] private float knockbackPower = 2.0f;
    //[SerializeField] private bool isJump = false;
    [SerializeField] private int jumpCount = 2;
    public bool canMove = true;

    private Rigidbody2D rigid;
    public SpriteRenderer playerSpriteRend;

    [Header("애니메이션 관련")]
    private Animator playerAnim;
    [SerializeField] private GameObject objHitEffect;
    [SerializeField] private GameObject objJumpEffect;

    private int randomVoicePlay = 1;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerSpriteRend = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();

        //valueBasicAttack = gameObject.GetComponent<BasicAttack>().basicAttack;

        playerAnim.SetBool("Idle", true);

        StartCoroutine(DontFreeze());
    }

    private void FixedUpdate()
    {
        if(canMove == true)
        {
            Moving();
        }
    }

    private void Update()
    {
        Jump();
        PlayerAhead();


        if ( playerAnim.GetBool("isMoving") == false
            && playerAnim.GetBool("isJumping") == false)
        {
            playerAnim.SetBool("Idle", true);
        }

        else
        {
            playerAnim.SetBool("Idle", false);
        }


        if (playerAnim.GetBool("Idle") == true)
        {
            canMove = true;
            jumpCount = 2;
        }

        
    }

    private void Moving()
    {

        h = Input.GetAxis("Horizontal");        // 가로축

        if(Input.GetButton("Horizontal"))
        {
            playerAnim.SetBool("Idle", false);
            playerAnim.SetBool("isMoving", true);
            transform.position += new Vector3(h, 0, v) * moveSpeed * Time.deltaTime;
        }

        else
        {
            playerAnim.SetBool("isMoving", false);
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetKeyDown(KeyCode.Space))
        {
            playerAnim.SetBool("isMoving", false);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            playerAnim.SetTrigger("Jump");
            playerAnim.SetBool("Idle", false);
            playerAnim.SetBool("isJumping", true);

            rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);

            jumpCount--;

            if(jumpCount == 1)
            {
                AudioManager.instance.PlaySFX("PlayerJumpSound");
            }

            if (jumpCount == 0)
            {
                objJumpEffect.SetActive(true);
                AudioManager.instance.PlaySFX("PlayerJumpVoice");
            }
        }
    }

    private void PlayerAhead()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            playerSpriteRend.flipX = true;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            playerSpriteRend.flipX = false;

        }

    }

    private void OnCollisionEnter2D(Collision2D ground)
    {
        if (ground.gameObject.CompareTag("Ground"))
        {
            playerAnim.SetBool("isJumping", false);
            //isJump = true;
            //jumpCount = 2;
            Debug.Log("땅에 닿았음~");
        }
    }

    private void OnCollisionExit2D(Collision2D ground)
    {
        if(ground.gameObject.CompareTag("Ground") || ground.gameObject.CompareTag("GroundExDalma"))
        {
            playerAnim.SetBool("Idle", false);
            playerAnim.SetBool("isMoving", false);
            playerAnim.SetBool("isJumping", true);
            //isJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MonsterHitbox")
            || collision.gameObject.CompareTag("Dalma"))
        {
            StartCoroutine(Knockback());
        }

        if (collision.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(Knockback());
            objHitEffect.SetActive(true);
        }
    }


    private IEnumerator Knockback()
    {
        randomVoicePlay = Random.Range(1, 3);

        if(randomVoicePlay == 1)
        {
            AudioManager.instance.PlaySFX("PlayerScream1");
        }

        else
        {
            AudioManager.instance.PlaySFX("PlayerScream2");
        }

        canMove = false;
        //isJump = false;
        playerAnim.SetTrigger("isDamaged");

        playerAnim.SetBool("isAttack", false);
        //valueBasicAttack = 0;
        gameObject.GetComponent<BasicAttack>().basicAttack = 0;

        if (playerSpriteRend.flipX == false)
        {
            rigid.AddForce(Vector3.right * knockbackPower, ForceMode2D.Impulse);
        }

        else
        {
            rigid.AddForce(Vector3.left * knockbackPower, ForceMode2D.Impulse);
        }

        yield return new WaitForSeconds(knockbackTime);
    }

    private void ICanMove()
    {
        canMove = true;
        //isJump = true;
        jumpCount = 2;
        objHitEffect.SetActive(false);
    }

    private IEnumerator DontFreeze()
    {
        yield return new WaitForSeconds(2.0f);

        playerAnim.SetBool("isJumping", false);
        //jumpCount = 2;
        playerAnim.SetBool("Idle", true);

        StartCoroutine(DontFreeze());
    }
}
