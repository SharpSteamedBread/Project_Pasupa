using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchController : MonoBehaviour
{
    public int doGlitch;

    [SerializeField] private GameObject objGlitch1;
    [SerializeField] private GameObject objGlitch2;
    [SerializeField] private GameObject objGlitch3;
    [SerializeField] private GameObject objGlitch4;
    [SerializeField] private GameObject objGlitch5;
    [SerializeField] private GameObject objGlitch6;


    private void Awake()
    {
        doGlitch = 0;
    }

    private void Update()
    {

        switch(doGlitch)
        {
            case 0:
                objGlitch1.SetActive(false);
                objGlitch2.SetActive(false);
                objGlitch3.SetActive(false);
                objGlitch4.SetActive(false);
                objGlitch5.SetActive(false);
                objGlitch6.SetActive(false);
                break;


            case 1:
                objGlitch1.SetActive(true);
                break;

            case 2:
                objGlitch2.SetActive(true);
                break;

            case 3:
                objGlitch3.SetActive(true);
                break;

            case 4:
                objGlitch4.SetActive(true);
                break;

            case 5:
                objGlitch5.SetActive(true);
                break;

            case 6:
                objGlitch6.SetActive(true);
                break;
        }
    }
}
