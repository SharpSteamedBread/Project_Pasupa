using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private Vector2 pos;
    [SerializeField]
    private GameObject StartPosObject;
    [SerializeField]
    private GameObject EndPosObject;
    private Vector2 startpos;
    private Vector2 endpos;
    //private Vector2 (14 ,2.09)
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed*Time.deltaTime);
        pos = this.gameObject.transform.position;
        startpos = StartPosObject.transform.position;
        endpos = EndPosObject.transform.position;

        if (transform.position.x <= endpos.x)
        {
            transform.position = new Vector2(startpos.x, pos.y);
        }
        /*
        if(transform.position.x <= -14)
        {
            transform.position = new Vector2(21, pos.y);
        }
        */

        //if(transform.position.x <= (pos2-7))
        //Debug.Log(pos.y);
    }
}
