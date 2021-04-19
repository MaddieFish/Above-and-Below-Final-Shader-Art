using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseApplication : MonoBehaviour
{
    public bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (!isPaused)
            {
                Time.timeScale = 0;
                isPaused = true;
            }
        }
        else if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;

        }
    }
    
}
