using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    private GameObject objPlayer;
    private Transform objPlayerPos;
    private Transform spawnPos;

    [SerializeField] private GameObject objAudioBGM;
    [SerializeField] private AudioSource asBGM;
    [SerializeField] private GameObject objSpecialStage;
    [SerializeField] private int percent;

    [Header("≥Î¿Ã¡Ó")]
    [SerializeField] private GameObject objGlitch;


    private bool valueisSpecialStage;

    private void Awake()
    {
        spawnPos = gameObject.GetComponent<Transform>();

        objAudioBGM = GameObject.FindGameObjectWithTag("BGM");
        asBGM = objAudioBGM.GetComponent<AudioSource>();
        valueisSpecialStage = objSpecialStage.GetComponent<StageController>().isSpecialStage;

        objGlitch = GameObject.FindGameObjectWithTag("Glitch");
        objGlitch.GetComponent<GlitchController>();
        objGlitch.GetComponent<GlitchController>().doGlitch = 0;

    percent = 5;

        FindPlayer();
        SetBGM();
        DecideSpecialStage();

    }

    private void FindPlayer()
    {
        objPlayer = GameObject.FindWithTag("Player");
        objPlayer.transform.position = spawnPos.position;
    }

    private void SetBGM()
    {
        asBGM.pitch = 1f;
    }

    private void DecideSpecialStage()
    {
        int value = Random.Range(1, 101);
        if (percent >= value)
        {
            objSpecialStage.GetComponent<StageController>().isSpecialStage = true;
            Debug.Log("¿ÃªÛ«— ∏ ¿Ã¥Ÿ!");
        }

        else
        {
            Debug.Log("ªΩ¿Ã¡ˆ∑’~");
        }
    }
}
