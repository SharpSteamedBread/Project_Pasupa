using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxReverse : MonoBehaviour
{
    [SerializeField] private GameObject objParent;

    private SpriteRenderer objSpriteRenderer;
    private Transform hitboxTransform;

    private void Awake()
    {
        objSpriteRenderer = objParent.GetComponent<SpriteRenderer>();
        hitboxTransform = gameObject.GetComponent<Transform>();
    }

    private void Update()
    {
        Reverse();
    }

    private void Reverse()
    {
        if (objSpriteRenderer.flipX == true)
        {
            hitboxTransform.transform.localScale = new Vector3(transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
        }

        else
        {
            hitboxTransform.transform.localScale = new Vector3(transform.localScale.x * (-1), transform.localScale.y, transform.localScale.z);
        }
    }
}
