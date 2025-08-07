using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GraphicRaycasterTest : MonoBehaviour
{
    private GraphicRaycaster graphicRaycaster;

    private void Awake()
    {
        graphicRaycaster = GetComponent<GraphicRaycaster>();
    }

    private void Update()
    {
        var ped = new PointerEventData(null);

        ped.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        graphicRaycaster.Raycast(ped, results);

        if(results.Count <= 0)
        {
            return;
        }

        Debug.Log("<color=blue>Hit: </color>" + results[0].gameObject.name);
    }
}
