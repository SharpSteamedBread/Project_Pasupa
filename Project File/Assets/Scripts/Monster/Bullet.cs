using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("투사체 정보")]
    private Rigidbody2D rigid;
    [SerializeField] private float bulletSpeed;
    private SpriteRenderer flip;


    private void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        bulletSpeed = 5.0f;

        flip = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        BulletStatus();
    }

    private void BulletStatus()
    {

        if (flip.flipX == true)
        {
            //rigid.AddForce(Vector2.right * bulletSpeed * Time.deltaTime, ForceMode2D.Impulse);
            //rigid.velocity = bulletSpeed * transform.right;
            transform.Translate(Vector2.right * (bulletSpeed * Time.deltaTime), Space.Self);
            Destroy(gameObject, 1);
        }

        else
        {
            //rigid.AddForce(Vector2.left * bulletSpeed * Time.deltaTime, ForceMode2D.Impulse);
            //rigid.velocity = bulletSpeed * transform.right;
            transform.Translate(Vector2.left * (bulletSpeed * Time.deltaTime), Space.Self);
            Destroy(gameObject, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(bulletSpeed == 10)
            {
                AudioManager.instance.PlaySFX("Purple_Spitted");
            }

            if(bulletSpeed == 5)
            {
                AudioManager.instance.PlaySFX("MintCreamAttacked");
            }

            Destroy(gameObject);


        }
    }
}
