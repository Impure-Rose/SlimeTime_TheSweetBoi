using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pickups : MonoBehaviour
{
    AudioSource pickupNoise;
    //[SerializeField] private GameObject player;
    [SerializeField] private float timeToDespawn;

    // Start is called before the first frame update
    void Start()
    {
        pickupNoise = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            Debug.Log("I'm being picked up!");
            //player.GetComponent<PlayerController>().pickupsHeld++;
            //player.GetComponent<PlayerController>().UpdatePickupUI();
            other.gameObject.SendMessage("UpdatePickupUI");
            pickupNoise.Play();
            Destroy(gameObject, timeToDespawn);
        }
    }
}
