using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDetectionRadius : MonoBehaviour
{
    [SerializeField] private GameObject[] trackers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trackers[0] == null)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        for (int i=0; i <= (trackers.Length - 1); i++)
        {
            trackers[i].SendMessage("Tracking", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        for(int i=0; i<=(trackers.Length-1); i++)
        {
            trackers[i].SendMessage("Tracking", false);
        }
    }
}
