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
    [SerializeField]
    private int hardness;
    [SerializeField]
    private bool isExcavating;

    public int getHardness()
    {
        return this.hardness;
    }
}
