using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeGame : MonoBehaviour
{
    public void CloseGame()
    {
        Application.Quit();
        Debug.Log("Cerrar");
    }
}
