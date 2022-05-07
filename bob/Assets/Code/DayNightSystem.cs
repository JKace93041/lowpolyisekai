using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayNightSystem : MonoBehaviour
{
    
    public float currentTime;
    public float dayLengthMinutes;
    public TextMeshProUGUI timeText;

    private float rotationspeed;
    float midday;
    float translateTime;

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
        timeText.text = hours.ToString();
        transform.Rotate(new Vector3(1, 0, 0) * rotationspeed * Time.deltaTime);
        
    }
}
