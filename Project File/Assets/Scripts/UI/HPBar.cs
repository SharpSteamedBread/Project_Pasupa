using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPBar : MonoBehaviour
{
    private Slider healthBar;

    [SerializeField] private int currHP;
    [SerializeField] private int maxHP;
    [SerializeField] private GameObject currHPStat;
    [SerializeField] private TextMeshProUGUI hpPercent;

    private void Start()
    {
        healthBar = GetComponent<Slider>();
        maxHP = currHPStat.GetComponent<PlayerStatus>().maxHP;
    }

    private void Update()
    {
        currHP = currHPStat.GetComponent<PlayerStatus>().currHP;

        healthBar.maxValue = maxHP;
        healthBar.value = currHP;
        healthBar.minValue = 0;

        hpPercent.text = ($"{currHP}/{maxHP}");
    }
}
