using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipButton : MonoBehaviour
{
    private Outline outLine;

    [SerializeField]
    private GameObject equipDeleteButton;

    private void Awake()
    {
        outLine = gameObject.GetComponent<Outline>();
    }

    public void RightClickEquip()
    {
        if (Input.GetMouseButtonUp(1))
        {
            outLine.enabled = true;
            equipDeleteButton.SetActive(true);
        }
    }

    public void DeleteEquipButton()
    {
        gameObject.SetActive(false);
    }
}
