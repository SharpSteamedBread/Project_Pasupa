using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SkillToolTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject skillToolTipUI;

    public void OnPointerEnter(PointerEventData eventData)
    {
        skillToolTipUI.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        skillToolTipUI.SetActive(false);
        Debug.Log("ºüÁ³¼õ~");
    }
}
