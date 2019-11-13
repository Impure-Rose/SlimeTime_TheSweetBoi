using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] NavMeshAgent agent;
    [Header("Tracking system lol")]
    [SerializeField] private bool tracking;
    [SerializeField] private int damageCaused = 10;


    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (tracking == true)
        {
            agent.destination = player.transform.position;
            transform.LookAt(player.transform);
        }

    }
    void Tracking(bool active)
    {
        if (active==true)
        {
            tracking = true;
        }
        else
        {
            tracking = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<PlayerController>().playerHealth -= damageCaused;
        }
    }
}
