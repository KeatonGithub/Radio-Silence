using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) //this makes it so that when the timer hits zero you lose the game, it also counts down the timer
        {
            SceneManager.LoadScene("Gameplay");

        }
    }
}
