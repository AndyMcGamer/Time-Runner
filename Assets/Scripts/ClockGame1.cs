using UnityEngine;
using System.Collections;

public class ClockGame1 : MonoBehaviour {

	//-- set start time 00:00
    public int minutes, hours;
	
    public GameObject pointerMinutes;
    public GameObject pointerHours;

    public AudioClip minClip, hrClip, solvedClip;
    public float volume=0.5f; // ff to change

    public GameObject clock;
    
    bool button1, button2; // TODO
    int x,y; // TODO

    private bool solved = false;

    void Start() 
    {
        
    }

    void Awake()
    {
        AudioSource audio = gameObject.AddComponent<AudioSource>() as AudioSource;

    }

    void Update() 
    {
        if(!solved)
        {
            if(button1) // TODO
            {
                minutes += 5;
                if(minutes >= 60)
                {
                    minutes = 0;
                    hours ++;
                    if(hours >= 24) hours = 0;
                }
                GetComponent<AudioSource>().PlayOneShot(minClip, volume);
            }

            if(button2) // TODO
            {
                hours++;
                if(hours >= 24) hours = 0;
                GetComponent<AudioSource>().PlayOneShot(hrClip, volume);
            }
            
            if(minutes == x && hours == y) // TODO
            {
                solved = true;
                GetComponent<AudioSource>().PlayOneShot(solvedClip, volume);
                // TODO
            }

             //-- calculate pointer angles
            float rotationMinutes = (360.0f / 60.0f)  * minutes;
            float rotationHours   = ((360.0f / 12.0f) * hours) + ((360.0f / (60.0f * 12.0f)) * minutes);

            //-- draw pointers
            pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
            pointerHours.transform.localEulerAngles   = new Vector3(0.0f, 0.0f, rotationHours);
        }

    }
}
