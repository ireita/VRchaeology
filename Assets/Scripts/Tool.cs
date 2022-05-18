using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    #region variables
    public enum SelectedTool { Nothing, PickAxe, Shovel, PickHammer };
    public SelectedTool selectedtool;
    public Vector3 ToolVelocity;
    Vector3 OldPosition = Vector3.zero;
    #endregion

    #region Pending code

    //Smoother Function for Velocity tracking, tracks 3 values (x, y, z)
    private void Start()
    {
        StartCoroutine(VelocityCalculation());
    }


    IEnumerator VelocityCalculation()
    {
        while(Application.isPlaying)
        {
            Vector3 OldPosition = transform.position;  
            
            yield return new WaitForEndOfFrame();

            ToolVelocity = (OldPosition - transform.position) / Time.deltaTime;

            Debug.Log(ToolVelocity);
        }
    }
    #endregion

    #region functions
    private void OnTriggerEnter(Collider other)
    {
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
