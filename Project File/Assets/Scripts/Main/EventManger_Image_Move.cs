using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManger_Image_Move : MonoBehaviour
{
    public RectTransform targetRectTransform;
    public float transitionDuration = 1f;

    private bool hasChangedSpacebar = false;
    private bool hasChangedArrowUp = false;
    private float elapsedTime = 0f;
    private Vector2 initialPosition;
    private Vector2 targetPosition;
    private Vector2 savedPosition;

    private void Awake()
    {
        initialPosition = targetRectTransform.anchoredPosition;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasChangedSpacebar && !hasChangedArrowUp)
        {
            hasChangedSpacebar = true;
            savedPosition = targetRectTransform.anchoredPosition;
            targetPosition = new Vector2(targetRectTransform.anchoredPosition.x, 999f);
            elapsedTime = 0f;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && !hasChangedSpacebar && !hasChangedArrowUp)
        {
            hasChangedArrowUp = true;
            elapsedTime = 0f;
            savedPosition = targetRectTransform.anchoredPosition;
            targetPosition = new Vector2(targetRectTransform.anchoredPosition.x, -999f);
        }

        if (hasChangedSpacebar || hasChangedArrowUp)
        {
            elapsedTime += Time.deltaTime;

            float t = elapsedTime / transitionDuration;
            t = Mathf.Clamp01(t);

            float posY = Mathf.Lerp(savedPosition.y, targetPosition.y, t);
            Vector2 newPosition = new Vector2(targetRectTransform.anchoredPosition.x, posY);
            targetRectTransform.anchoredPosition = newPosition;

            if (t >= 1f)
            {
                hasChangedSpacebar = false;
                hasChangedArrowUp = false;
                elapsedTime = 0f;
            }
        }
    }
}
/*
public GameObject Story_Panel;
public GameObject Story_Panel_Text;

public RectTransform targetRectTransform;
public float transitionDuration = 1f;

private bool hasChanged = false;
private bool SpacePressed = false;
private float elapsedTime = 0f;
private Vector2 initialPosition;
private Vector2 targetPosition;
private Vector2 targetPosition2;

private float timer;

private void Start()
{
    SpacePressed = false;
    initialPosition = targetRectTransform.anchoredPosition;
    targetPosition = new Vector2(targetRectTransform.anchoredPosition.x, 999);
    targetPosition2 = new Vector2(targetRectTransform.anchoredPosition.x, -999);
}

private void Update()
{
    //timer += Time.deltaTime;
    if (Input.GetKeyDown(KeyCode.Space))
    {
        hasChanged = true;
        SpacePressed = false;
    }

    if (SpacePressed == false && hasChanged == true)
    {
            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp01(elapsedTime / transitionDuration);
            targetRectTransform.anchoredPosition = Vector2.Lerp(initialPosition, targetPosition, t);
            if (t >= 1f)
            {
                hasChanged = false;
                elapsedTime = 0f;
                SpacePressed = true;
            }
    }
    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
        SpacePressed = false;
    }

    if (SpacePressed)
    {
        if (hasChanged)
        {
            elapsedTime += Time.deltaTime;

            float t = Mathf.Clamp01(elapsedTime / transitionDuration);
            targetRectTransform.anchoredPosition = Vector2.Lerp(initialPosition, targetPosition2, t);
            if (t >= 1f)
            {
                hasChanged = false;
                elapsedTime = 0f;
                SpacePressed = false;
            }
        }
    }
}
*/
