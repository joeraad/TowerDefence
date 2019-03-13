using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All the details about the player is stored in this class
public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney=10000;
    public static int Lives;
    public int startLives = 20;

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }
     
}
