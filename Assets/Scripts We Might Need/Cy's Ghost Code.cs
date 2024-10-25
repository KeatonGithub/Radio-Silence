using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using JetBrains.Annotations;

public class NewBehaviourScript : MonoBehaviour
{
    public int ghostRandom;
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

    public int ghostsKilled;

    public System.Random rnd = new System.Random();


    // Start is called before the first frame update
    void Start()
    {

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
                switch2Target = false;
                switch3Target = false;
            }
            if (ghostRandom == 1)
            {
                //shadow
                switch0Target = false;
                switch1Target = false;
                switch2Target = false;
                switch3Target = false;
            }
            if (ghostRandom == 2)
            {
                //poltergeist
                switch0Target = false;
                switch1Target = false;
                switch2Target = false;
                switch3Target = false;
            }
            if (ghostRandom == 3)
            {
                //wraith
                switch0Target = false;
                switch1Target = false;
                switch2Target = false;
                switch3Target = false;
            }
            if (ghostRandom == 4)
            {
                //oni
                switch0Target = false;
                switch1Target = false;
                switch2Target = false;
                switch3Target = false;
            }
            if (ghostRandom == 5)
            {
                //banshee
                switch0Target = false;
                switch1Target = false;
                switch2Target = false;
                switch3Target = false;
            }
            if (ghostRandom == 6)
            {
                //covenant
                switch0Target = false;
                switch1Target = false;
                switch2Target = false;
                switch3Target = false;
            }
        }
        //randomly select a number for the ghost's frequency
        if (callFrequency == true)
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
        }
        else if (frequencyCurrent > frequencyRandom - 3 | frequencyCurrent < frequencyRandom + 3)
        {
            staticStrength = 1;
        }
        else if (frequencyCurrent > frequencyRandom - 5 | frequencyCurrent < frequencyRandom + 5)
        {
            staticStrength = 2;
        }
        else if (frequencyCurrent > frequencyRandom - 7 | frequencyCurrent < frequencyRandom + 7)
        {
            staticStrength = 3;
        }
        else if (frequencyCurrent > frequencyRandom - 10 | frequencyCurrent < frequencyRandom + 10)
        {
            staticStrength = 4;
        }
        else
        {
            staticStrength = 5;
        }

        // the following code is disgusting, i am sorry.
        //check for each switch being on/off and assign to variable.

        switch0 = false;
        switch1 = false;
        switch2 = false;
        switch3 = false;
        switchAMFM = false;

        if (Input.GetKey(KeyCode.Alpha1))
        {
            switch0 = true;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            switch1 = true;
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            switch2 = true;
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            switch3 = true;
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            switchAMFM = true;
        }

    }

    

}


