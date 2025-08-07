using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttack : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnLeft;
    [SerializeField] private Transform bulletSpawnRight;
    private SpriteRenderer flip;

    [SerializeField] private int bulletQuan;
    [SerializeField] private float bulletSpeed;


    private void Awake()
    {
        flip = gameObject.GetComponent<SpriteRenderer>();
        bulletSpeed = 1f;
        bulletQuan = 8;
    }

    private void Update()
    {

    }

    private void FireBullet()
    {
        if (flip.flipX == true)
        {
            bulletPrefab.GetComponent<SpriteRenderer>().flipX = true;
            Instantiate(bulletPrefab, bulletSpawnRight.transform);
        }

        else
        {
            bulletPrefab.GetComponent<SpriteRenderer>().flipX = false;
            Instantiate(bulletPrefab, bulletSpawnLeft.transform);
        }
        AudioManager.instance.PlaySFX("PurpleAttackVoice");
    }

    private IEnumerator MakeCircleBullet()
    {
        float angle = 360 / bulletQuan;

        do
        {
            for (int i = 0; i < bulletQuan; i++)
            {
                GameObject obj;
                obj = (GameObject)Instantiate(bulletPrefab, gameObject.transform.position, Quaternion.identity);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(bulletSpeed * Mathf.Cos(Mathf.PI * 2 * i / bulletQuan), bulletSpeed * Mathf.Sin(Mathf.PI * i * 2 / bulletQuan)));

                obj.transform.Rotate(new Vector3(0f, 0f, 360 * i / bulletQuan - 90));
            }
            yield return new WaitForSeconds(100f);
        }
        while (true);
    }

    private void MakeCircleBullet2()
    {
        AudioManager.instance.PlaySFX("MintAttackVoice");

        //360번 반복
        for (int i = 0; i < 360; i += 45)
        {
            //총알 생성
            GameObject temp = Instantiate(bulletPrefab, gameObject.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);

            //총알 생성 위치를 (0,0) 좌표로 한다.
           // temp.transform.position = Vector2.zero;

            //Z에 값이 변해야 회전이 이루어지므로, Z에 i를 대입한다.
            temp.transform.rotation = Quaternion.Euler(0, 0, i);

            //yield return new WaitForSeconds(100f);
        }
    }
}
