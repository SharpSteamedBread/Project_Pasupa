using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private bool isCameraShake = false;

    // ex) OnShakeCamera(1f);                >>> 1초간 0.1의 세기로 흔들림
    // ex) OnShakeCamera(0.5f, 1f);          >>> 0.5초간 1의 세기로 흔들림

    /// <param name=" shakeTime">           >>> 카메라 흔들림 지속시간 (기본 1.0f)
    /// <param name="shakeIntensity">       >>> 카메라 흔들림 세기(값이 클수록 세게 흔들림)

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
            Debug.Log("맞았다!");
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
