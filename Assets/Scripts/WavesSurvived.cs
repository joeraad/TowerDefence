using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class WavesSurvived : MonoBehaviour
{
    public Text roundsText;


    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundsText.text = "0";
        int round = 0;
        yield return new WaitForSeconds(.7f);
        while (round < PlayerStats.Waves)
        {
            round++;
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(.05f);
        }

    }
}
