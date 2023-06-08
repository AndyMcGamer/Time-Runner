using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    [SerializeField] private GameObject timeTravelVFX;
    [SerializeField] private ParticleSystem timeTravelFX;
    [SerializeField] private GameObject whiteFade;
    [SerializeField] private Collider col;
    [SerializeField] private GameObject[] enviros;
    [SerializeField] private GameObject[] mainRooms;
    [SerializeField] private AudioSource ekkow;
    

    private List<GameObject> heldItems;
    private float cooldown;
    private bool present = true;


    public bool debug = true;

    public void AddHeldItem(GameObject item)
    {
        heldItems.Add(item);
    }

    public void RemoveHeldItem(GameObject item)
    {
        heldItems.Remove(item);
    }

    private void Awake()
    {
        present = true;
        cooldown = 5f;
        heldItems = new();
    }
    public void FixedPortal()
    {
        timeTravelVFX.SetActive(true);
        col.enabled = true;
        gameObject.tag = "Collider";
        cooldown = 5f;
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
        ekkow.Play();
        yield return new WaitForSeconds(1f);
        whiteFade.SetActive(true);
        yield return new WaitForSeconds(3f);

        present = !present;
        if (present)
        {
            enviros[0].SetActive(true);
            transform.parent = mainRooms[0].transform;
            enviros[1].SetActive(false);
            foreach (var item in heldItems)
            {
                item.transform.parent = enviros[0].transform;
            }
        }
        else
        {
            enviros[1].SetActive(true);
            transform.parent = mainRooms[1].transform;
            enviros[0].SetActive(false);
            foreach(var item in heldItems)
            {
                item.transform.parent = enviros[1].transform;
            }
        }
        
        
        yield return new WaitForSeconds(0.1f);
        whiteFade.SetActive(false);

    }
}
