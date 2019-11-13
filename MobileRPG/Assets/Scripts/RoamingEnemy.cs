using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoamingEnemy : MonoBehaviour
{
    [Header("Points to Visit")]
    [SerializeField] private Transform[] points;
    [Header("Controller")]
    [SerializeField] private NavMeshAgent navMesh;
    [SerializeField] private int nodeToVisit;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Redirect());
    }

    // Update is called once per frame
    void Update()
    {
        if (navMesh.velocity == new Vector3(0, 0, 0))
        {
            StartCoroutine(Redirect());
        }
        navMesh.destination = points[nodeToVisit].transform.position;
    }
    IEnumerator Redirect()
    {
            nodeToVisit = Random.Range(0, (points.Length - 1));
        yield return new WaitForSeconds(2f);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<PlayerController>().playerHealth -= 10;
        }
    }
}
