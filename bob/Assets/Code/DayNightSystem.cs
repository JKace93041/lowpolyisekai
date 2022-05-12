using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayNightSystem : MonoBehaviour
{
    AudioSource attachedAudioSource1;
    AudioSource attachedAudioSource2;
    public float currentTime;
    public float dayLengthMinutes;
    public TextMeshProUGUI timeText;
    public Material Stars;
    public GameObject Rain;
    public GameObject happymusic;
    public GameObject witchmusic;

    public Light lux;
    private float rotationspeed;
    float midday;
    float translateTime;
    string AMPM = "AM";

    // Start is called before the first frame update
    void Start()
    {

        attachedAudioSource1 = happymusic.GetComponent<AudioSource>();
        attachedAudioSource2 = witchmusic.GetComponent<AudioSource>();

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
                Rain.SetActive(true);
                witchmusic.SetActive(false);
                attachedAudioSource1.Play();
                attachedAudioSource2.Stop();
                happymusic.SetActive(true);


                lux.intensity -= lux.intensity *  Time.deltaTime * 100;
                if (lux.intensity <= 0)
                {
                   
                    lux.intensity = 10;

                }
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
                Rain.SetActive(false);
                witchmusic.SetActive(true);
                happymusic.SetActive(true);
                attachedAudioSource1.Stop();
                attachedAudioSource2.Play();

                //lux.intensity = 1000;
                lux.intensity += lux.intensity * Time.deltaTime * 10;
                if (lux.intensity >= 1000)
                {
                    lux.intensity = 1000;

                }
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
