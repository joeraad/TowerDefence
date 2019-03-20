﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve fadecurve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float t = 1f;
        while (t>0)
        {
            t -= Time.deltaTime;
            float a = fadecurve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            //this skips to the next frame
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;
        while (t<1f)
        {
            t += Time.deltaTime;
            float a = fadecurve.Evaluate(t);
            img.color = new Color(0f, 0f, 0f, a);
            //this skips to the next frame
            yield return 0;
        }
        SceneManager.LoadScene(scene);
    }
}
