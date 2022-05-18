using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Class Excavatable
* Parent Class for different types of Ground Prefabs,
* features logic for overarching excavation
**/

public class Excavatable : MonoBehaviour
{
    //Instance Variables
    [SerializeField]
    private int hardness;
    [SerializeField]
    private int excavationState;
    [SerializeField]
    private int maxExcavationState;

    public void OnTriggerEnter(Collider other)
    {
        //Check if colliding object is excavation tool
        if (other.gameObject.CompareTag("ExcavationTool"))
        {
            //Check if excavation tool has required hardness
            if(other.gameObject.GetComponent<ExcavationTool>().getHardness() >= this.hardness)
            {
                //Progress excavation state
                excavationState++;

                //Progress mesh according to excavation state or disable gameobject
                if (excavationState >= maxExcavationState)
                {
                    this.gameObject.SetActive(false);
                }
                else
                {
                    //TODO: change mesh
                    //Currently changes material for testing
                }
            }
        }
    }

    public int getHardness()
    {
        return this.hardness;
    }

    public int getExcavationState()
    {
        return this.excavationState;
    }

    public int getMaxExcavationState()
    {
        return this.maxExcavationState;
    }
}
