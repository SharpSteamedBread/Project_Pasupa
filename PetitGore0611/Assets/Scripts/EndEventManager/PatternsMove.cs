using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternsMove : MonoBehaviour
{

    public GameObject spotObj;
    public float transitionSpeed = 2.0f;

    private Transform spotTransform;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isTransitioning = false;
    private float transitionProgress = 0.0f;

    private void Start()
    {
        spotTransform = spotObj.transform;
        initialPosition = transform.position;
        targetPosition = spotTransform.position;
        isTransitioning = true;
        transitionProgress = 0.0f;
    }

    private void Update()
    {

        if (isTransitioning)
        {
            transitionProgress += Time.deltaTime * transitionSpeed;
            transitionProgress = Mathf.Clamp01(transitionProgress);

            Vector3 newPosition = Vector3.Lerp(initialPosition, targetPosition, transitionProgress);
            transform.position = newPosition;

            if (transitionProgress >= 1.0f)
            {
                isTransitioning = false;
            }
        }
    }
}
