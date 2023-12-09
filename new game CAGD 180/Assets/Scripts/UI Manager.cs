using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIManager : MonoBehaviour
{
    public PlayerController pController;
    public TMP_Text pointsText;
    public TMP_Text healthText;
    public TMP_Text timerText;

    float currentTime = 0f;
    float startingTime = 60f;



    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = "Points: " + pController.totalPoints;
        healthText.text = "Health: " + pController.health;

        currentTime -= 1 * Time.deltaTime;
        timerText.text = currentTime.ToString();

        if( currentTime <= 0)
        {
            currentTime = 0;

        }

    }
}
