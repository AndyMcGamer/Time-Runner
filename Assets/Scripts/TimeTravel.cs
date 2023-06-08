using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    [SerializeField] private ParticleSystem timeTravelContinuous;
    [SerializeField] private ParticleSystem timeTravelFX;
    [SerializeField] private GameObject whiteFade;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject[] enviros;
    [SerializeField] private GameObject[] mainRooms;
    private float cooldown;
    private bool present = true;


    public bool debug = true;

    private void Awake()
    {
        present = true;
        cooldown = 5f;
    }
    public void FixedPortal()
    {
        timeTravelContinuous.Play();
        col.enabled = true;
        gameObject.tag = "Collider";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && cooldown <= 0f)
        {
            StartCoroutine(ChangeEnviro());
            cooldown = 5f;
        }
    }

    private void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space) && debug)
        {
            FixedPortal();
        }
    }

    private IEnumerator ChangeEnviro()
    {
        timeTravelFX.Play();
        yield return new WaitForSeconds(1f);
        whiteFade.SetActive(true);
        yield return new WaitForSeconds(3f);

        present = !present;
        if (present)
        {
            enviros[0].SetActive(true);
            transform.parent = mainRooms[0].transform;
            enviros[1].SetActive(false);
        }
        else
        {
            enviros[1].SetActive(true);
            transform.parent = mainRooms[1].transform;
            enviros[0].SetActive(false);
        }
        
        
       
        
        yield return new WaitForSeconds(0.1f);
        whiteFade.SetActive(false);

    }
}
