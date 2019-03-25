using UnityEngine;
using UnityEngine.UI;

public class CompleteLevel : MonoBehaviour
{
    public SceneFader sceneFader;

    public string menuSceneName="MainMenu";

    public string nextlevel = "level02";
    public int levelToUnlock = 2;

    public void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextlevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}
