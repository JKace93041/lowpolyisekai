using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayNightSystem : MonoBehaviour
{
    
    public float currentTime;
    public float dayLengthMinutes;
    public TextMeshProUGUI timeText;
    public Material Stars;
    private float rotationspeed;
    float midday;
    float translateTime;
    string AMPM = "AM";

    // Start is called before the first frame update
    void Start()
    {
        rotationspeed = 360 / dayLengthMinutes / 60;
        midday = dayLengthMinutes * 60 / 2;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += 1 * Time.deltaTime;
        translateTime = (currentTime / (midday * 2));
        
        


        float t = translateTime * 24f;
        float hours = Mathf.Floor(t);
        string displayhours = hours.ToString();
        if(hours == 0)
        {
            displayhours = "12";


        }
        if (hours > 12)
        {
            displayhours = (hours - 12).ToString();
        }
        if (currentTime >= midday / 2 && currentTime <= midday * 1.5f)
        {
            if (Stars.GetFloat("_Cutoff") < 1)
            {
                float alpha = Stars.GetFloat("_Cutoff") * 100f;
                alpha += 100 * rotationspeed * Time.deltaTime;
                alpha = alpha * .01f;
                Stars.SetFloat("_Cutoff", alpha);
            }
        }
        else
        {
            if (Stars.GetFloat("_Cutoff") > .2f)
            {
                float alpha = Stars.GetFloat("_Cutoff") * 100f;
                alpha -= 3 *  rotationspeed * Time.deltaTime;
                alpha = alpha * .01f;
                Stars.SetFloat("_Cutoff", alpha);
            }
        }
        if (currentTime >= midday )
        {
            if (AMPM != "PM")
            {
                AMPM = "PM";
                
            }
        }
        if (currentTime >= midday *2)
        {
            if (AMPM != "AM")
            {
                AMPM = "AM";
               
            }
            currentTime = 0;
        }


        t *= 60;
        float minutes = Mathf.Floor(t % 60);
        string displayMinutes = minutes.ToString();
        if (minutes < 10)
        {
            displayMinutes = "0" + minutes.ToString();
        }

         
        string displayTime = displayhours +":" + displayMinutes +" " + AMPM;
        timeText.text = displayTime;
        transform.Rotate(new Vector3(1, 0, 0) * rotationspeed * Time.deltaTime);
        
    }
}
