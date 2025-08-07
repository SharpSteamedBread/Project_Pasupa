using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    [Header("포탈")]
    public int monCount;

    [Header("맵 변형")]
    public bool isSpecialStage = false;

    [Header("사운드")]
    [SerializeField] private GameObject objAudioBGM;
    [SerializeField] private AudioSource asBGM;
    [SerializeField] private float valuePitch;

    [Header("노이즈")]
    [SerializeField] private GameObject objGlitch;

    [SerializeField] private int percent;


    private void Awake()
    {
        objAudioBGM = GameObject.FindGameObjectWithTag("BGM");
        asBGM = objAudioBGM.GetComponent<AudioSource>();

        if (SceneManager.GetActiveScene().buildIndex != 8)
        {
            objGlitch = GameObject.FindGameObjectWithTag("Glitch");
            objGlitch.GetComponent<GlitchController>();
        }



        valuePitch = 0.15f;
        percent = 5;
    }

    public void GettingWeird()
    {

        if (SceneManager.GetActiveScene().buildIndex != 7 || SceneManager.GetActiveScene().buildIndex != 8)
        {
            monCount -= 1;
            //Debug.Log($"포탈 열리기까지 {monCount}마리!");


            if (isSpecialStage == false)
            {
                int value = Random.Range(1, 101);
                if (percent >= value)
                {
                    //Debug.Log(value);
                    asBGM.pitch = asBGM.pitch - valuePitch;
                    objGlitch.GetComponent<GlitchController>().doGlitch++;
                }
            }

            else
            {
                //Debug.Log("이상한 맵이다! 진짜임!");
                asBGM.pitch = asBGM.pitch - valuePitch;
                objGlitch.GetComponent<GlitchController>().doGlitch++;
            }
        }
    }
}
