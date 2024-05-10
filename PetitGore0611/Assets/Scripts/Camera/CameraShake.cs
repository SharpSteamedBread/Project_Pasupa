using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private bool isCameraShake = false;

    // ex) OnShakeCamera(1f);                >>> 1�ʰ� 0.1�� ����� ��鸲
    // ex) OnShakeCamera(0.5f, 1f);          >>> 0.5�ʰ� 1�� ����� ��鸲

    /// <param name=" shakeTime">           >>> ī�޶� ��鸲 ���ӽð� (�⺻ 1.0f)
    /// <param name="shakeIntensity">       >>> ī�޶� ��鸲 ����(���� Ŭ���� ���� ��鸲)

    [SerializeField] private GameObject objPlayerLife;
    [SerializeField] private int playerLifeValue;
    [SerializeField] private bool letsShakeCamValue;

    private void Awake()
    {
        //playerLifeValue = objPlayerLife.GetComponent<PlayerHit>().playerLife;
        //letsShakeCamValue = objPlayerLife.GetComponent<PlayerHit>().letsShakeCam;
    }

    private void Update()
    {
        //playerLifeValue = objPlayerLife.GetComponent<PlayerHit>().playerLife;
        //letsShakeCamValue = objPlayerLife.GetComponent<PlayerHit>().letsShakeCam;

        if (playerLifeValue == 2 && letsShakeCamValue == true || playerLifeValue == 1 && letsShakeCamValue == true)
        {
            Debug.Log("�¾Ҵ�!");
            OnShakeCamera(0.5f, 0.2f);
        }
    }

    public void OnShakeCamera(float shakeTime = 1.0f, float shakeIntensity = 0.1f)
    {
        if (isCameraShake == true) return;

        StartCoroutine(ShakeByPosition(shakeTime, shakeIntensity));

    }

    private IEnumerator ShakeByPosition(float shakeTime = 1.0f, float shakeIntensity = 0.1f)
    {
        Vector3 startPosition = transform.position;

            isCameraShake = true;

        while (shakeTime > 0.0f)
        {
            transform.position = startPosition + Random.insideUnitSphere * shakeIntensity;

            shakeTime -= Time.deltaTime;

            yield return null;
        }

        transform.position = startPosition;
        isCameraShake = false;
    }

}
