using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* Class ExcavationTool
* Parent Class for different types excavation tools,
* to be overriden by child classes implementing different logics
* according to each tool
**/

public class ExcavationTool : MonoBehaviour
{
    #region variables
    [SerializeField]
    private bool isExcavating;
    public enum SelectedTool { Nothing, PickAxe, Shovel, PickHammer };
    public SelectedTool selectedtool;
    public Vector3 lastMovement;
    public float toolVelocity;
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
        while (Application.isPlaying)
        {
            Vector3 OldPosition = transform.position;

            yield return new WaitForEndOfFrame();

            lastMovement = (OldPosition - transform.position) / Time.deltaTime;
            toolVelocity = lastMovement.magnitude;

            if (toolVelocity > 3)
            {
                isExcavating = true;
            }
            else
            {
                isExcavating = false;
            }
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

    #region get & set
    public int getHardness()
    {
        switch (selectedtool)
        {
            case SelectedTool.Nothing:
                return 0;
                break;
            case SelectedTool.PickAxe:
                return 3;
                break;
            case SelectedTool.Shovel:
                return 1;
                break;
            case SelectedTool.PickHammer:
                return 2;
                break;
            default:
                return -1;
                break;
        }
    }

    public bool getIsExcavating()
    {
        return isExcavating;
    }
    #endregion
}
