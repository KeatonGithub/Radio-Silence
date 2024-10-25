using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour //defining all the public variables to use with the gamemanage
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //public Transform Spawnpoint;
    //public int LivesCounter = 3;
    public float TimeCounter = 300;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI ghostsExorcised;
    public int ghostsKilled;
    //public TextMeshProUGUI Money;
    //public TextMeshProUGUI Lives;
	//public TextMeshProUGUI Speed;
	//public GameObject Player;
    //public bool winning;
    //public int Collected = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
       // if (SceneManager.GetActiveScene().name == "Loss")
        //{
        //    ghostsExorcised = GameObject.Find("FinalScore#").GetComponent<TextMeshProUGUI>();
        //}
        //if (Input.GetKeyDown(KeyCode.R))//forces player respawn if you get stuck when you press r
        //{
        //   RespawnP1();
        // }

        if (TimeCounter > 0) //this makes it so that when the timer hits zero you lose the game, it also counts down the timer
        {
            TimeCounter -= Time.deltaTime;

        }
        else if (TimeCounter < 0)
        {
            SceneManager.LoadScene("Loss");
            //LivesCounter -= 1;
        }
        if (Timer != null)
        { 
        Timer.text = "" + TimeCounter.ToString("F0");//these strings are whats outputted to the UI elements
                                                     // Money.text = "$" + Collected.ToString();//they are the money timer and lives tmp UI text
        ghostsExorcised.text = "" + ghostsKilled.ToString();
    }
    }
    public void Collect() //adds 100 dollars when you collect a stack of cash
    {
       // Collected += 100;
    }
    public void RespawnP1() //this class causes the player to go to the loss scene when they are out of lives it also the respawns the player if they still have lives left
    {
       // LivesCounter -= 1;
        //Player.transform.position=Spawnpoint.transform.position;
       //transform.rotation = Quaternion.Euler(0, 0, 0);

       // if (LivesCounter < 0 == false)
        //{
           // SceneManager.LoadScene("Loss");
       // }
    }
}
