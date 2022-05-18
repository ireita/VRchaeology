using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tool_Template_NS;

public class Tool : MonoBehaviour
{
    //TODO: Adjust code to naming conventions
    #region variables

    Tool_Template tool_template_;

    //Move Enum maybe in tool_template Namespace
    public enum SelectedTool { Nothing, PickAxe, Shovel, PickHammer };
    public SelectedTool selectedtool;

    //Vector3 Velocity used for Smooth Velocity function
    public Vector3 ToolVelocity;
    //float used for first velocity calculation in Pending Code Region
    //public float ToolVelocity;
    Vector3 OldPosition = Vector3.zero;
    #endregion

    #region Pending code
    //old Velocity calculation for tools
    /*
    public void VelocityCalculation()
    {
        //Preventing tracking movement of non-Tools 
        if (selectedtool != SelectedTool.Nothing)
        {
            //Velocity for Tool, DeltaTime for Velocity per Frame
            ToolVelocity = Vector3.Distance(OldPosition, transform.position) / Time.deltaTime;
            OldPosition = transform.position;
        }
    }

    void Update()
    {
        // VelocityCalculation();
    }*/
    #endregion

    #region functions
    private void Start()
    {
        StartCoroutine(VelocityCalculation());
    }

    //Smoother Function for Velocity tracking, tracks 3 values (x, y, z)
    IEnumerator VelocityCalculation()
    {
        while (Application.isPlaying)
        {
            Vector3 OldPosition = transform.position;

            yield return new WaitForEndOfFrame();

            ToolVelocity = (OldPosition - transform.position) / Time.deltaTime;

            Debug.Log(ToolVelocity);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //Tag Query for Ground_Blocks? 
        //Switch Case in seperate function (probably)
        switch (selectedtool)
        {
            case SelectedTool.Nothing:

                //Nothing lol

                break;

            case SelectedTool.PickAxe:

                //Example of query for hardness + velocity
                //if (Hardness_Pickaxe > GerritSkript.Excavatinghardness && ToolVelocity > 5 && Excavationstate == ???)
                //{
                // other.GerritSkript.IsExcavating = true;
                // Depending on what the bool is doing, more queries are required
                //}
                break;

            case SelectedTool.Shovel:
                //Case working as intended
                Debug.Log("Hello, is this working?");

                break;

            case SelectedTool.PickHammer:

                break;

        }

    }
    #endregion
}
