using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class activateLoseState : MonoBehaviour
{
    public GameManager Manager;
    private void OnTriggerEnter(Collider collision) //When the player collides with the tagged object with collisions respawn the player. (If the player has respawned a defined amount of times they lose)
    {
        if (collision.tag == "Player")
        {
            Manager.RespawnP1();
        }

    }
}