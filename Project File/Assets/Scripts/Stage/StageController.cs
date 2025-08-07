using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    [Header("��Ż")]
    public int monCount;

    [Header("�� ����")]
    public bool isSpecialStage = false;

    [Header("����")]
    [SerializeField] private GameObject objAudioBGM;
    [SerializeField] private AudioSource asBGM;
    [SerializeField] private float valuePitch;

    [Header("������")]
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
            //Debug.Log($"��Ż ��������� {monCount}����!");


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
                //Debug.Log("�̻��� ���̴�! ��¥��!");
                asBGM.pitch = asBGM.pitch - valuePitch;
                objGlitch.GetComponent<GlitchController>().doGlitch++;
            }
        }
    }
}
