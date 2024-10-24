using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeMng : MonoBehaviour //defining all the public variables to use with the gamemanage
{   
    public int LivesCounter = 3;
    public float TimeCounter = 300;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI Lives;
    //public TextMeshProUGUI Speed;
    public GameObject Player;
    public bool winning;
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))//forces player respawn if you get stuck when you press r
        {
            RespawnP1();
        }

        if (TimeCounter > 0 && winning == false) //this makes it so that when the timer hits zero you lose the game, it also counts down the timer
        {
            TimeCounter -= Time.deltaTime;
        }
        else if (TimeCounter < 0)
        {
            SceneManager.LoadScene("Loss");
        }

        Timer.text = "" + TimeCounter.ToString("F0");//these strings are whats outputted to the UI elements
        
        Lives.text = "" + LivesCounter.ToString();
    }
   
    public void RespawnP1() //this class causes the player to go to the loss scene when they are out of lives it also the respawns the player if they still have lives left
    {
        LivesCounter -= 1;        
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (LivesCounter < 0 && winning == false)
        {
            SceneManager.LoadScene("Loss");
        }
    }
}

