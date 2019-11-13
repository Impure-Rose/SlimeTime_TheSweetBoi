using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wiggle : MonoBehaviour
{
    private float rotation = 0;

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, rotation, 0);
        rotation--;
    }
}
