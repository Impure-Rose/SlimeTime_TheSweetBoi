using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdatedJoystick : MonoBehaviour
{
    public Camera cam;
    public Image joystick;
    private bool joystickPressed;
    public Vector3 targetPos;
    public GameObject character;
    public float cameraSmoothSpeed = 5f;
    public float speed = 8f;

    //my shit
    public GameObject camPositionHolder;
    private Quaternion targetRotation;

    // Update is called once per frame
    void Update()
    {
        //may cause issues with touching the screen anwhere else, but in my tests the OnClick was not working. We can return to that if it does work here.
        if (Input.GetMouseButtonDown(0))
        {
            print("down");
            joystickPressed = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            print("up");
            joystickPressed = false;
        }


        if (joystickPressed)
        {
            //movement update---- ­­­­­­­­­ target position is clamped so that the player can't move backwards as much
            targetPos = character.transform.position + (character.transform.forward * Mathf.Abs(joystick.rectTransform.localPosition.y / 20));
            character.transform.position = Vector3.MoveTowards(character.transform.position, targetPos, speed * Mathf.Clamp(joystick.rectTransform.localPosition.y / 30, -2f, 10) * Time.deltaTime);

            //rotation update for character
            targetRotation = character.transform.rotation;
            targetRotation *= Quaternion.AngleAxis(joystick.rectTransform.localPosition.x / 30, Vector3.up);
        }
        
        //rotation completed out here for smoother rotation...?
        character.transform.rotation = Quaternion.Lerp(character.transform.rotation, targetRotation, speed * 12 * Time.deltaTime);

        //camera
        cam.transform.position = Vector3.Lerp(cam.transform.position, camPositionHolder.transform.position, cameraSmoothSpeed * Time.deltaTime);
        cam.transform.LookAt(character.transform.position);
    }
}
