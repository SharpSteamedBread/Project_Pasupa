using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    private AudioClip audioClip;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        StartCoroutine(PlayBGM());
    }

    private IEnumerator PlayBGM()
    {
        yield return new WaitForSeconds(3.0f);

        audioSource.Play();
    }
}
