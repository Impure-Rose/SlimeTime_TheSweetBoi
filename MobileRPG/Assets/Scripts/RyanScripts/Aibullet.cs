using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Aibullet : MonoBehaviour
{
    /*
    public NavMeshAgent navMeshAgent;
    private GameObject player;
    public GameObject bulletPrefab;
    private float actionTimer = 1f;
    private float last = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.destination = player.transform.position;
        navMeshAgent.transform.LookAt(player.transform.position);
        if (shootTimer())
        {
            GameObject g = (GameObject)Instantiate(bulletPrefab, transform.position, transform.rotation);
            g.GetComponent<Rigidbody>().AddForce(g.transform.forward * 800);
            Destroy(g, 2f);
        }
    }
    bool shootTimer()
    {
        if(Time.fixedTime - last > actionTimer)
        {
            last = Time.fixedTime;
            return true;
        } else
        {
            return false;
        }
    }
    */
}
