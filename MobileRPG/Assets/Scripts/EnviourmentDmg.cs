using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviourmentDmg : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private int damage = 5;
    private bool detected = false;
    private bool attacking = false; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (detected == true)
        {
            if (attacking == true)
            {
                StartCoroutine(OnHit());
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            detected = true;
            attacking = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 8)
        {
            detected = false;
            attacking = false;
        }
    }
    IEnumerator OnHit()
    {
        if (attacking == true)
        {
            Debug.Log("Hit");
            attacking = false;
            player.GetComponent<PlayerController>().playerHealth -=damage;
            yield return new WaitForSeconds(1f);
            attacking = true;
        }

    }
}
