using UnityEngine;
using System.Collections;

public class ClockGame : MonoBehaviour {

	//-- set start time 00:00
    public int minutes, hours;
	
    public GameObject pointerMinutes;
    public GameObject pointerHours;

    public GameObject key;
    public GameObject keyHint;

    public AudioSource minTickSound;
    public AudioSource hrTickSound;
    
    public bool button1, button2; // TODO
    public int x,y; // TODO

    public float minTickRate = 1f;
    public float hrTickRate = 1f;
    private float minCooldown, hrCooldown;

    private bool solved = false;
    float rotationMinutes, rotationHours;

    public void SetMin(bool active)
    {
        button1 = active;
    }

    public void SetHr(bool active)
    {
        button2 = active;
    }

    void Update() 
    {
        if(!solved)
        {
            if(minCooldown > 0) minCooldown -= Time.deltaTime;
            if(hrCooldown > 0) hrCooldown -= Time.deltaTime;
            if(button1 && minCooldown <= 0) // TODO
            {
                minutes += 5;
                minTickSound.PlayOneShot(minTickSound.clip);
                if(minutes >= 60)
                {
                    minutes = 0;
                    hours++;
                    hrTickSound.PlayOneShot(hrTickSound.clip);
                    if(hours >= 12) hours = 1;
                }
                minCooldown = minTickRate;
            }

            if(button2 && hrCooldown <= 0) // TODO
            {
                hours++;
                hrTickSound.PlayOneShot(hrTickSound.clip);
                if (hours >= 12) hours = 1;
                hrCooldown = hrTickRate;
            }

             //-- calculate pointer angles
            rotationMinutes = (360.0f / 60.0f)  * minutes;
            rotationHours   = ((360.0f / 12.0f) * hours) + ((360.0f / (60.0f * 12.0f)) * minutes);

            //-- draw pointers
            pointerMinutes.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationMinutes);
            pointerHours.transform.localEulerAngles = new Vector3(0.0f, 0.0f, rotationHours);

        }



    }

    public void CheckTime()
    {
        if(x == minutes && y == hours)
        {
            solved = true;
            key.SetActive(true);
            keyHint.SetActive(true);
            AudioManager.instance.Play("solved");
        }
    }

}
