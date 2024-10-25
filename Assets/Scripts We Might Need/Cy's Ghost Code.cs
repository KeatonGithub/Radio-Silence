using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using JetBrains.Annotations;

public class NewBehaviourScript : MonoBehaviour
{
    GameManager gameManager;
    public int ghostRandom;
    public int ghostsKilled;
    public int frequencyRandom;
    public bool callGhost;
    public bool callFrequency;

    public bool switch0;
    public bool switch1;
    public bool switch2;
    public bool switch3;
    public bool switchAMFM;

    public bool switch0Target;
    public bool switch1Target;
    public bool switch2Target;
    public bool switch3Target;

    public bool rightChannel;
    public bool ghostCorrect;
    public int frequencyCurrent;
    public int staticStrength;
    public int switch0Buffer, switch1Buffer, switch2Buffer, switch3Buffer, switch4Buffer;

    public GameObject[] ghostsVisualizers;
    public GameObject staticRef;

    public System.Random rnd = new System.Random();


    // Start is called before the first frame update
    void Start()
    {
        callGhost = true;
        callFrequency = true;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //set to false so we're not still saying we win from the last ghost
        ghostCorrect = false;
        //check if the current switch position matches the target position, and if so call a new ghost and frequency
        if (switch0 == switch0Target && switch1 == switch1Target && switch2 == switch2Target && switch3 == switch3Target && switchAMFM == true)
        {
            ghostCorrect = true;
            callGhost = true;
            callFrequency = true;
            ghostsKilled++;
        }

        gameManager.ghostsKilled = ghostsKilled;
        //randomly select ghost and find the target switch combination for that ghost
        if (callGhost == true)
        {
            callGhost = false;
            ghostRandom = rnd.Next(0, 6);


            if (ghostRandom == 0)
            {
                //wisps
                switch0Target = false;
                switch1Target = false;
                switch2Target = true;
                switch3Target = false;

                foreach (GameObject ghost in ghostsVisualizers)
                {
                    ghost.SetActive(false);
                }

                ghostsVisualizers[ghostRandom].SetActive(true);
            }
            if (ghostRandom == 1)
            {
                //shadow
                switch0Target = false;
                switch1Target = true;
                switch2Target = false;
                switch3Target = true;
                foreach (GameObject ghost in ghostsVisualizers)
                {
                    ghost.SetActive(false);
                }

                ghostsVisualizers[ghostRandom].SetActive(true);
            }
            if (ghostRandom == 2)
            {
                //poltergeist
                switch0Target = true;
                switch1Target = false;
                switch2Target = false;
                switch3Target = false;
                foreach (GameObject ghost in ghostsVisualizers)
                {
                    ghost.SetActive(false);
                }

                ghostsVisualizers[ghostRandom].SetActive(true);
            }
            if (ghostRandom == 3)
            {
                //wraith
                switch0Target = false;
                switch1Target = true;
                switch2Target = true;
                switch3Target = true;
                foreach (GameObject ghost in ghostsVisualizers)
                {
                    ghost.SetActive(false);
                }

                ghostsVisualizers[ghostRandom].SetActive(true);
            }
            if (ghostRandom == 4)
            {
                //oni
                switch0Target = true;
                switch1Target = true;
                switch2Target = false;
                switch3Target = true; foreach (GameObject ghost in ghostsVisualizers)
                {
                    ghost.SetActive(false);
                }

                ghostsVisualizers[ghostRandom].SetActive(true);
            }
            if (ghostRandom == 5)
            {
                //banshee
                switch0Target = false;
                switch1Target = true;
                switch2Target = true;
                switch3Target = false; foreach (GameObject ghost in ghostsVisualizers)
                {
                    ghost.SetActive(false);
                }

                ghostsVisualizers[ghostRandom].SetActive(true);
            }
            if (ghostRandom == 6)
            {
                //covenant
                switch0Target = false;
                switch1Target = false;
                switch2Target = true;
                switch3Target = true; foreach (GameObject ghost in ghostsVisualizers)
                {
                    ghost.SetActive(false);
                }

                ghostsVisualizers[ghostRandom].SetActive(true);
            }
        }
        //randomly select a number for the ghost's frequency
        if (callFrequency == true && switchAMFM == false)
        {
            callFrequency = false;

            // what frequency the player needs to target 

            frequencyRandom = rnd.Next(0, 50);
        }

        //based on the current frequency, find how strong the static should be.
        //if youre on the right channel, say you're on the right channel.
        if (frequencyCurrent == frequencyRandom)
        {
            rightChannel = true;
            ghostsVisualizers[ghostRandom].GetComponent<VisualizerScript>().PlaySound();
            //staticRef.GetComponent<AudioSource>().Stop();
        }
        else if (frequencyCurrent > frequencyRandom - 3 | frequencyCurrent < frequencyRandom + 3)
        {
            staticStrength = 1;
            staticRef.GetComponent<AudioSource>().Play();
        }
        else if (frequencyCurrent > frequencyRandom - 5 | frequencyCurrent < frequencyRandom + 5)
        {
            staticStrength = 2;
            staticRef.GetComponent<AudioSource>().Play();
        }
        else if (frequencyCurrent > frequencyRandom - 7 | frequencyCurrent < frequencyRandom + 7)
        {
            staticStrength = 3;
            staticRef.GetComponent<AudioSource>().Play();
        }
        else if (frequencyCurrent > frequencyRandom - 10 | frequencyCurrent < frequencyRandom + 10)
        {
            staticStrength = 4;
            staticRef.GetComponent<AudioSource>().Play();
        }
        else
        {
            staticStrength = 5;
            staticRef.GetComponent<AudioSource>().Play();
            ghostsVisualizers[ghostRandom].GetComponent<VisualizerScript>().StopSound();
        }


        // the following code is disgusting, i am sorry.
        //check for each switch being on/off and assign to variable.


        if (Input.GetKey(KeyCode.Alpha1))
        {
            switch0 = true;
            switch0Buffer = 200;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            switch1 = true;
            switch1Buffer = 200;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            switch2 = true;
            switch2Buffer = 200;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            switch3 = true;
            switch3Buffer = 200;
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            switchAMFM = true;
            switch4Buffer = 200;
        }

        if (frequencyCurrent <= 50 && Input.GetKey(KeyCode.D))
        {
            frequencyCurrent++;
        }
        if (frequencyCurrent >= 1 && Input.GetKey(KeyCode.A))
        {
            frequencyCurrent--;
        }

        //switch buffers increment
        if (switch0)
        {
            switch0Buffer--;
            if (switch0Buffer == 0)
            {
                switch0 = false;
            }
        }
        if (switch1)
        {
            switch1Buffer--;
            if (switch1Buffer == 0)
            {
                switch1 = false;
            }
        }
        if (switch2)
        {
            switch2Buffer--;
            if (switch2Buffer == 0)
            {
                switch2 = false;
            }
        }
        if (switch3)
        {
            switch3Buffer--;
            if (switch3Buffer == 0)
            {
                switch3 = false;
            }
        }
        if (switchAMFM)
        {
            switch4Buffer--;
            if (switch4Buffer == 0)
            {
                switchAMFM = false;
            }
        }
    }



}


