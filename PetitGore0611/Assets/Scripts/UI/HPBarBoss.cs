using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPBarBoss : MonoBehaviour
{
    private Slider healthBar;

    [SerializeField] private int currHP;
    [SerializeField] private int maxHP;
    [SerializeField] private GameObject currHPStat;
    [SerializeField] private TextMeshProUGUI hpPercent;
    [SerializeField] private GameObject UIHPfill;

    private void Start()
    {
        healthBar = GetComponent<Slider>();
        maxHP = currHPStat.GetComponent<BossStatus>().maxHP;
    }

    private void Update()
    {
        currHP = currHPStat.GetComponent<BossStatus>().currHP;

        healthBar.maxValue = maxHP;
        healthBar.value = currHP;
        healthBar.minValue = 0;

        if(currHP <= 0)
        {
            currHP = 0;
            UIHPfill.SetActive(false);
        }

        hpPercent.text = ($"{currHP}/{maxHP}");


    }
}
