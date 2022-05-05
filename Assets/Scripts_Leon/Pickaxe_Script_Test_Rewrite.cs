using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickaxe_Script_Test_Rewrite : MonoBehaviour
{
    //Todo: Variables in seperate Namespace
    #region GlobalVariables

    public GameObject MainObjectPrefab_1;
    public GameObject MainObjectPrefab_2;
    public GameObject MainObjectPrefab_3;

    private GameObject NewMainObject_1;
    private GameObject NewMainObject_2;
    private GameObject NewMainObject_3;

    public GameObject VFXObject_1;
    public GameObject VFXObject_2;
    public GameObject VFXObject_3;

    public int MainObjectCounter;
    public int currentID;

    private Vector3 MainObjectPosition;
    private Quaternion MainObjectRotation;
    #endregion


    void Start()
    {
        MainObjectCounter = 0;
        MainObjectPosition = new Vector3(0, 0, 0);    
    }

    #region SeperateIntoOtherScript
    void InstaniateMainObjects()
    {
   
        //Stages of how many times the groundlayer should scale down
        if (MainObjectCounter == 0 )
        {
            NewMainObject_1 = Instantiate(MainObjectPrefab_1, MainObjectPosition, MainObjectRotation);
        }
        /*
        if (MainObjectCounter == 1)
        {
            NewMainObject_2 = Instantiate(MainObjectPrefab_2, MainObjectPosition, MainObjectRotation);
        }
        if (MainObjectCounter == 2)
        {
            NewMainObject_3 = Instantiate(MainObjectPrefab_3, MainObjectPosition, MainObjectRotation);
            
        }*/
    }
    private void InstaniateVFX() 
    {

    }
    private void DestroyMainObjects()
    {
        
        if (MainObjectCounter > 1 )
        {
            Destroy(NewMainObject_1);
        }
        if (MainObjectCounter >= 2)
        {
            Destroy(NewMainObject_2);
        }
        if (MainObjectCounter >= 3)
        {
            Destroy(NewMainObject_3);
            MainObjectCounter = 0;
        }
    }
    private void DestroyVFX()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
  
        if (other.tag == "Test_Pickaxe")
        {
            if (currentID != other.gameObject.GetInstanceID())
            {
                currentID = other.gameObject.GetInstanceID();
                MainObjectCounter = 0; // Dosent work well with instaniate 
                other.gameObject.tag = "Active";
            }

            MainObjectPosition = other.gameObject.transform.position;
            MainObjectRotation = other.gameObject.transform.rotation;
            InstaniateMainObjects();
            DestroyMainObjects();
        }
    }
    #endregion SeperateIntoOtherScript

    //Todo: Trigger that detects collision between pickaxe and ground
    //Deletes old Objects and instaniates smaller object 
    //random picks between a selection of different objects per state
    //optinal also instaniates small little stones as VFX 
    //Velocity queue + rotation + maybe add something like a acceleration variable
    //Add Resistance if the ground was hit and count the hit, maxhit -> destroys the object 
}
