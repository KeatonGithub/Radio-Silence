using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class activateNextLevel : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision) //This code specifically send the player to the next level before the win screan on collision
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("Level2");
        }

    }
}
