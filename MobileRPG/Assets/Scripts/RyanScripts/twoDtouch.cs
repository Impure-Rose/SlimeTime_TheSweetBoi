using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twoDtouch : MonoBehaviour
{
    public GameObject mySprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0; i<Input.touchCount; i++)
        {
            Vector3 spritePosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            Debug.DrawLine(Vector3.zero, spritePosition, Color.green);
            spritePosition.z = 0f;

            GameObject o = Instantiate(mySprite, spritePosition, Quaternion.identity);
            Destroy(o, 0.5f);
        }
    }
}
