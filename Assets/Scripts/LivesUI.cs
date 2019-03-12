using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour {

    public Text livesText;
	
    //Setting the lives text to its value from PlayerStats
	void Update () {
        livesText.text = PlayerStats.Lives.ToString() + " LIVES";	
	}
}
