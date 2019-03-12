using UnityEngine.UI;
using UnityEngine;

public class MoneyUI : MonoBehaviour {

    public Text moneyText;

    //Setting the Money to its value from PlayerStats
    void Update () {
        moneyText.text = "$" + PlayerStats.Money;
	}
}
