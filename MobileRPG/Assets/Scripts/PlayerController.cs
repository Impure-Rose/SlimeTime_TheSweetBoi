using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [Header("System")]
    [SerializeField] private bool computerDebug;
    [SerializeField] private Rigidbody self;
    [Header("Gameplay Variables")]
    [Range(0, .75f)]
    [SerializeField] float speed;
    public int pickupsHeld = 0;
    public float playerHealth = 100f;
    [SerializeField] private int maxPickups = 5;
    [SerializeField] private bool canDie = true;

    [Header("UI")]
    public TextMeshProUGUI pickupCounter;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject jsReference;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject deathScreen;

    [Header("Particle System")]
    [SerializeField] private GameObject ps;
    [SerializeField] private GameObject dashParticle;
    // Start is called before the first frame update
    void Start()
    {
        ps.SetActive(false);
        pickupsHeld = 0;
        pickupCounter.text = "Fruit: " + pickupsHeld + "/"+maxPickups;
        Time.timeScale = 1f; 
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = playerHealth/100;
        if (computerDebug == true)
        {
            computerControls();
        }
        if (playerHealth <= 25)
        {
            if (canDie == true)
            {
                jsReference.GetComponent<UpdatedJoystick>().speed = 4;
                ps.SetActive(true);
            }
        }
        if (playerHealth <= 0)
        {
            if (canDie == true)
            {
                Time.timeScale = 0;
                deathScreen.SetActive(true);
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
        jsReference.GetComponent<UpdatedJoystick>().speed = 8;
        if (playerHealth < 100)
        {
            playerHealth += 10;
        }
        if (playerHealth >= 0)
        {
            ps.SetActive(false);
        }
        if (pickupsHeld == 3 || pickupsHeld == 6)
        {
            UI.GetComponent<ButtonScript>().Charges++;
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
        dashParticle.SetActive(true);
        jsReference.GetComponent<UpdatedJoystick>().speed += 2;
        yield return new WaitForSeconds(6f);
        jsReference.GetComponent<UpdatedJoystick>().speed -=2;
        dashParticle.SetActive(false);
    }
}
