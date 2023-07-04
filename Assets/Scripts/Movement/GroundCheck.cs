using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] LayerMask groundMask = 0;
    [SerializeField] float sphereScale = 1;

    /// <summary>
    /// Used to check if this object is touching the ground
    /// </summary>
    /// <returns>True if the object is touching the ground</returns>
    public bool CheckGroundedStatus()
    {
        if(Physics.CheckSphere(transform.position, sphereScale / 2, groundMask, QueryTriggerInteraction.Ignore))
        {
            //Debug.Log("Grounded");
            return true;
        }

        //Debug.Log("Not Grounded");
        return false;
    }
}
