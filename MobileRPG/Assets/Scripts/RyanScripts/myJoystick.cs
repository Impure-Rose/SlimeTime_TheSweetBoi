using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myJoystick : MonoBehaviour
{
    public Camera cam;
    public Image joystick;
    private bool joystickPressed;
    public Vector3 targetPos, camdistance = new Vector3(0f, 13f, 14f);
    public GameObject character;
    private float cameraSmoothSpeed = 1f;
    public float speed = 8f;
    public GameObject particles;
    //private ParticleSystem ps;

    void Start()
    {
        camdistance = new Vector3(0f, 9f, -14f);
      //  ps = particles.GetComponent<ParticleSystem>();
       // particles.SetActive(false);
        //ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(joystickPressed == true)
        {
            targetPos = new Vector3(joystick.rectTransform.localPosition.x, character.transform.position.y, joystick.rectTransform.localPosition.y);
            character.transform.position = Vector3.MoveTowards(character.transform.position, targetPos, speed * Time.deltaTime);

            character.transform.LookAt(targetPos);
        }
        Vector3 distance = character.transform.position + camdistance;
        cam.transform.position = Vector3.Lerp(cam.transform.position, distance, cameraSmoothSpeed * Time.deltaTime);
        cam.transform.LookAt(character.transform.position);
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        joystickPressed = true;
        particles.SetActive(true);
      //  ps.Play();
    }
    private void OnMouseUp()
    {
        joystickPressed = false;
        //particles.SetActive(false);
     //   ps.Stop();
    }
}
