using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    private bool runningTime = true;
    public void alternatePause()
    {

        if (runningTime)
        {            
            Time.timeScale = 0;
            runningTime = false;
        }
        else
        {
            runningTime = true;
            Time.timeScale = 1;
        }
    }
}
