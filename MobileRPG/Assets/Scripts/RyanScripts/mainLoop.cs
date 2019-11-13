using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mainLoop : MonoBehaviour
{
    public GameObject agent;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAtIntervals(5f));
        //InvokeRepeating("spawner", 0, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnAtIntervals(float delay)
    {
        while (true)
        {
            GameObject g = (GameObject)Instantiate(agent, new Vector3(Random.Range(-8, 14), 0.54f, Random.Range(-21, 4)), transform.rotation);
            g.GetComponent<NavMeshAgent>().speed = Random.Range(0.1f, 5.0f);
            yield return new WaitForSeconds(delay);
        }
    }
    void spawner()
    {
        GameObject g = (GameObject)Instantiate(agent, new Vector3(Random.Range(-8, 14), 0.54f, Random.Range(-21, 4)), transform.rotation);
        g.GetComponent<NavMeshAgent>().speed = Random.Range(0.1f, 5.0f);
    }
}
