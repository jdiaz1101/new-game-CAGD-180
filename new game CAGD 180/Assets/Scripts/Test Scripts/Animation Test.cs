using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// put this in the player controller
/// </summary>
public class AnimationTest : MonoBehaviour
{

    public Animation hammerAnimation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            hammerAnimation.Play("HammerSwing"); 
        }
    }
}
