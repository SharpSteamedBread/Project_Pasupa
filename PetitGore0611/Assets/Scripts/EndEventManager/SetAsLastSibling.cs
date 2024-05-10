using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAsLastSibling : MonoBehaviour
{
    public GameObject Image;
    public GameObject Box;
    public GameObject Name;
    public GameObject Text;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Image.transform.SetAsLastSibling();
        Box.transform.SetAsLastSibling();
        Name.transform.SetAsLastSibling();
        Text.transform.SetAsLastSibling();
    }
}
