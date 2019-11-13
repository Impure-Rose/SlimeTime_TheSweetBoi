using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{

    [Header("System")]
    [SerializeField] private bool computerDebug;
    [SerializeField] private Rigidbody self;
    [Header("Gameplay Variables")]
    [Range(0, .75f)]
    [SerializeField] float speed;
    public int pickupsHeld = 0;
    public int playerHealth = 100;
    [SerializeField] private int maxPickups = 5;
    [SerializeField] private bool canDie = true;

    [Header("UI")]
    public TextMeshProUGUI pickupCounter;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private RectTransform healthStat;
    [SerializeField] private GameObject jsReference;
    [SerializeField] private GameObject victoryScreen;

    [Header("Particle System")]
    [SerializeField] private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps.Stop();
        pickupsHeld = 0;
        pickupCounter.text = "Fruit: " + pickupsHeld + "/"+maxPickups;
    }

    // Update is called once per frame
    void Update()
    {
        healthStat.sizeDelta = new Vector2(playerHealth * 2, 100);
        if (computerDebug == true)
        {
            computerControls();
        }
        if (playerHealth <= 0)
        {
            if (canDie == true)
            {
                jsReference.GetComponent<JoystickControls>().speed = 4;
                ps.Play();
            }
        }
        
        if (pickupsHeld == maxPickups)
        {

            canDie = false;
            playerHealth = 100;
            victoryScreen.SetActive(true);
        }
    }
    void computerControls()
    {
        if (Input.GetButton("Horizontal"))
        {
            self.MovePosition(transform.position + transform.right * (speed* Input.GetAxisRaw("Horizontal")));
        }
        if (Input.GetButton("Vertical"))
        {
            self.MovePosition(transform.position + transform.forward * (speed * Input.GetAxisRaw("Vertical")));
        }
    }
    public void UpdatePickupUI()
    {
        pickupsHeld++;
        pickupCounter.text = "Fruit: " + pickupsHeld + "/"+maxPickups;
        jsReference.GetComponent<JoystickControls>().speed = 8;
        if (playerHealth < 100)
        {
            playerHealth += 10;
        }
        if (playerHealth >= 0)
        {
            ps.Stop();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (canDie == false)
        {
            if (collision.gameObject.layer == 10 || collision.gameObject.layer == 11)
            {
                Destroy(collision.gameObject, 0f);
            }
        }
    }
    public IEnumerator Dash()
    {
        jsReference.GetComponent<JoystickControls>().speed += 2;
        yield return new WaitForSeconds(6f);
        jsReference.GetComponent<JoystickControls>().speed -=2;
    }
}
