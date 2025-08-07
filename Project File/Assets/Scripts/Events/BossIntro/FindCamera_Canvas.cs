using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCamera_Canvas : MonoBehaviour
{
    void Start()
    {
        SetCanvasCameraToMainCamera();
    }

    void SetCanvasCameraToMainCamera()
    {
        Canvas canvas = GetComponent<Canvas>();
        if (canvas != null)
        {
            Camera mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
            if (mainCamera != null)
            {
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.worldCamera = mainCamera;
            }
            else
            {
                Debug.LogWarning("MainCamera 오브젝트를 찾을 수 없습니다.");
            }
        }
        else
        {
            Debug.LogWarning("Canvas 컴포넌트를 찾을 수 없습니다.");
        }
    }
}
