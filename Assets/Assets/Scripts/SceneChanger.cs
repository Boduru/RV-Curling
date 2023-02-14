using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    private string[] levels = { "Lobby", "Plain", "Blades", "ElevatorEarly"};

    private int index;
    
    public void change(int i)
    {
        SceneManager.LoadScene(levels[i]);
    }

}
