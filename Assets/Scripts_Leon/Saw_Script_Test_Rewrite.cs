using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw_Script_Test_Rewrite : MonoBehaviour
{

    public float TimerQuery; 
    void Start()
    {
        TimerQuery = 0;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Test_groundlayer")
        {
            TimerQuery += 0.1f;
            if (TimerQuery >= 5f)
            {
                Destroy(other.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Test_groundlayer")
        {
            if (TimerQuery < 5f)
            {
                TimerQuery = 0f;
            }
        }
    }


    //For Velocity_Tracking_Script: Worth trying out a angular check, so that it tracks the velocity 90 <-> 180
    //Everything below or above doesnt get tracked --> horizontal swings wont get tracked

    //For seperate testscripts: merge into one script called something like "Tools_...", for working logic
    //Actual states/switches/Variables into a seperate class/script 
}
