using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCurtain : MonoBehaviour
{
    public RectTransform targetRectTransform;
    public GameObject posObj;
    public float transitionSpeed = 2.0f;

    private RectTransform currentRectTransform;
    private Vector2 initialPosition;
    private Vector2 targetPosition;
    private bool isTransitioning = false;
    private float transitionProgress = 0.0f;

    private void Start()
    {
        currentRectTransform = GetComponent<RectTransform>();
        initialPosition = currentRectTransform.anchoredPosition;
        targetPosition = posObj.GetComponent<RectTransform>().anchoredPosition;

        isTransitioning = true;
        transitionProgress = 0.0f;
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isTransitioning = true;
            transitionProgress = 0.0f;
        }
        */

        if (isTransitioning)
        {
            transitionProgress += Time.deltaTime * transitionSpeed;
            transitionProgress = Mathf.Clamp01(transitionProgress);

            Vector2 newPosition = Vector2.Lerp(initialPosition, targetPosition, transitionProgress);
            currentRectTransform.anchoredPosition = newPosition;

            if (transitionProgress >= 1.0f)
            {
                isTransitioning = false;
            }
        }
    }
}
