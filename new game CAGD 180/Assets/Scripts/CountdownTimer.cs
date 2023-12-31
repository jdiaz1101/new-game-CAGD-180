using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

    float currentTime = 0f;
    float startingTime = 10f;

    [SerializeField] Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        Debug.Log(currentTime);
        countdownText.text = currentTime.ToString();
    }
}
