using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class activateWinState : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision) //pretty self explanitory, this code sends anything taked as player on collision to the win screen
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene("Win");
        }

    }
}
