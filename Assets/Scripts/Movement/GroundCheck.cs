using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] LayerMask groundMask = 0;
    [SerializeField] float sphereScale = 1;

    bool isEnabled = true;

    /// <summary>
    /// Used to check if this object is touching the ground
    /// </summary>
    /// <returns>True if the object is touching the ground</returns>
    public bool CheckGroundedStatus()
    {
        if(Physics.CheckSphere(transform.position, sphereScale / 2, groundMask, QueryTriggerInteraction.Ignore) && isEnabled)
        {
            //Debug.Log("Grounded");
            return true;
        }

        //Debug.Log("Not Grounded");
        return false;
    }

    /// <summary>
    /// Coroutine that makes this ground check only return not grounded for specified amount of time
    /// </summary>
    /// <param name="delayTime">time you want the this to only return false</param>
    /// <returns></returns>
    public IEnumerator DelayChecks(float delayTime)
    {
        isEnabled = false;
        yield return new WaitForSeconds(delayTime);
        isEnabled = true;
    }
}
