using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private bool canOff;

    [Header("Page")]
    [SerializeField] private GameObject invenPage1;
    [SerializeField] private GameObject invenPage2by1;
    [SerializeField] private GameObject invenPage2by2;
    [SerializeField] private GameObject invenPage2Next;
    [SerializeField] private GameObject invenPage2Prev;

    //[SerializeField] private GameObject invenPage3;

    [Header("몬스터 카운트")]
    [SerializeField] private TextMeshProUGUI UITextMonCount;
    private GameObject objStageController;

    private int valueMonCount;


    private void Awake()
    {
        canOff = false;

        objStageController = GameObject.FindGameObjectWithTag("StageController");
        valueMonCount = objStageController.GetComponent<StageController>().monCount;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            canOff = !canOff;

            if(canOff == true)
            {
                ButtonEnableDiary();
            }

            else
            {
                ButtonDisableDiary();
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            canOff = !canOff;

            ButtonDisableDiary();
        }

        objStageController = GameObject.FindGameObjectWithTag("StageController");

        valueMonCount = objStageController.GetComponent<StageController>().monCount;
        if(valueMonCount <= 0)
        {
            valueMonCount = 0;
        }

        UITextMonCount.text = valueMonCount.ToString();

    }


    public void ButtonEnableDiary()
    {
        inventoryUI.SetActive(true);
    }

    public void ButtonDisableDiary()
    {
        inventoryUI.SetActive(false);
    }

    public void ButtonPageOne()
    {
        invenPage2by1.SetActive(false);
        invenPage2by2.SetActive(false);
        invenPage2Next.SetActive(false);
        //invenPage3.SetActive(false);
        invenPage1.SetActive(true);
    }

    public void ButtonPageTwo()
    {
        invenPage1.SetActive(false);
        //invenPage3.SetActive(false);
        invenPage2by1.SetActive(true);
        invenPage2Next.SetActive(true);
    }

    public void ButtonPageTwoNext()
    {
        invenPage2by1.SetActive(false);
        invenPage2Next.SetActive(false);
        invenPage2by2.SetActive(true);
        invenPage2Prev.SetActive(true);

    }

    public void ButtonPageTwoPrev()
    {
        invenPage2by2.SetActive(false);
        invenPage2Prev.SetActive(false);
        invenPage2by1.SetActive(true);
        invenPage2Next.SetActive(true);

    }

    public void ButtonPageThree()
    {
        invenPage1.SetActive(false);
        invenPage2by1.SetActive(false);
        invenPage2by2.SetActive(false);
        //invenPage3.SetActive(true);
    }
}
