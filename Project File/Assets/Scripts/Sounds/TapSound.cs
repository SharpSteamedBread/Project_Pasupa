using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            AudioManager.instance.PlaySFX("Menu_tap2");
        }
    }
}
