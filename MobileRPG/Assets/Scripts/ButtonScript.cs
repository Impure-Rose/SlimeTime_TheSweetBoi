using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject backGround;
    [Header("Dash")]
    private bool dashActive;
    [SerializeField] private TextMeshProUGUI dashUses;
    public int Charges = 3;
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        //dashUses.text = Charges + "x";
    }

    // Update is called once per frame
    void Update()
    {
        dashUses.text = Charges + "x";

    }
    public void Replay()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Play()
    {
        // SceneManager.LoadScene("SampleScene");
        loadingScreen.SetActive(true);
        StartCoroutine(LoadSceneAsync());
        backGround.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    IEnumerator LoadSceneAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");
            yield return null;
        
    }
    public void Dash()
    {
        if (dashActive == false && Charges>0)
        {
            dashActive = true;
            Charges--;
            player.SendMessage("Dash");
            dashActive = false;

        }
    }
}

