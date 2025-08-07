using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Header("Stat")]
    public int maxHP;
    public int currHP;
    public int playerAtkMin;
    public int playerAtkMax;
    public int playerCrit;


    public void Awake()
    {
        maxHP = 300;
        currHP = maxHP;
        playerAtkMin = 10;
        playerAtkMax = 20;
        playerCrit = 50;
    }
}
