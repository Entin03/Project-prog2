using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.UI;

public class DayTimeController : MonoBehaviour
{
    const float secondsInday = 86400f;

    //Megadjuk az estei és a reggeli színeket, használjuk a unity curveanimját
    [SerializeField] Color nightLightColor;
    [SerializeField] AnimationCurve nightTimeCurve;
    [SerializeField] Color dayLightColor = Color.white;

    float time;
    [SerializeField] float timeScale = 60f;

    [SerializeField] Text text;
    [SerializeField] Light2D globalLight;
    private int days;

    float Hours
    {
        get {return time / 3600f;}
    }

    float Minutes
    {
        get {return time % 3600f / 60f; }
    }


    //Kiírjuk az időt óra:perc formátumban
    private void Update()
    {
        time += Time.deltaTime * timeScale;
        int hh = (int)Hours;
        int mm = (int)Minutes;
        text.text = hh.ToString("00") + ":" + mm.ToString("00");
        float v = nightTimeCurve.Evaluate(Hours);
        Color c = Color.Lerp(dayLightColor, nightLightColor, v);
        globalLight.color = c;

        if (time > secondsInday)
        {
            NextDay();
        }
    }

    //Nullázuk az időt és növeljük a napotS
    private void NextDay()
    {
        time = 0;
        days +=1;
    }
}
