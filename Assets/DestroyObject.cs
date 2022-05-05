using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
   [SerializeField]
   public int MaxHit = 0;
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickaxe")
        {
            MaxHit++;
        }
    }
}
