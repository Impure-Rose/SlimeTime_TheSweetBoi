using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickControls : MonoBehaviour
{
    [SerializeField] private Image joystick;
    [SerializeField] private bool joystickPressed=false;
    [SerializeField] private Vector3 targetPos;//, camDistance = new Vector3(0f, 13f, -14f);
    [SerializeField] private GameObject player;
    public float speed = 8f;

    //[SerializeField] private Camera cam;
    
    //private float cameraSmoothSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
       // camDistance = new Vector3(0f, 9f,-14f);
    }

    // Update is called once per frame
    void Update()
    {
        if(joystickPressed == true)
         {

            targetPos = new Vector3(joystick.rectTransform.localPosition.x, player.transform.position.y, joystick.rectTransform.localPosition.y);
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetPos, speed * Time.deltaTime);

            //player.transform.LookAt(targetPos);
        }
        //Vector3 distance = player.transform.position - camDistance*2;

        //cam.transform.position = Vector3.Lerp(cam.transform.position, distance, cameraSmoothSpeed * Time.deltaTime);

        //cam.transform.LookAt(player.transform.position);
    }
    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        joystickPressed = true;
    }
    private void OnMouseUp()
    {
        joystickPressed = false;
    }
}
