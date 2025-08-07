using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subel_EndMove : MonoBehaviour
{
    public GameObject EventObj;

    public Vector2 endpos;
    public Transform spotTransform;
    public float transitionSpeed = 2.0f;
    public float maxHeight = 5.0f;
    public float curveIntensity = 1.0f;

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isTransitioning = false;
    private float transitionProgress = 0.0f;
    private float speed = 1f;

   public Animator SubelAnim;

    public bool curtaining = false;
    public bool curtaining2 = false;

    private void Start()
    {
        initialPosition = transform.position;
        MoveToSpotPosition();
    }

    private void Update()
    {
        if (isTransitioning)
        {
            transitionProgress += Time.deltaTime * transitionSpeed;
            transitionProgress = Mathf.Clamp01(transitionProgress);

            float curveValue = Mathf.Sin(transitionProgress * Mathf.PI);
            float height = curveValue * maxHeight;
            Vector3 newPosition = Vector3.Lerp(initialPosition, targetPosition, transitionProgress);
            newPosition.y += height * curveIntensity;
            transform.position = newPosition;

            if (transitionProgress >= 1.0f)
            {
                isTransitioning = false;
            }
        }

        if(curtaining)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            if (transform.position.x >= endpos.x)
            {
                EventObj.GetComponent<EndEventManager>().animcout++;    
                SubelAnim.SetBool("Dancing", true);
            }
        }
        if(curtaining2)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

    }

    public void MoveToSpotPosition()
    {
        targetPosition = spotTransform.position;
        isTransitioning = true;
        transitionProgress = 0.0f;
    }

    
}
