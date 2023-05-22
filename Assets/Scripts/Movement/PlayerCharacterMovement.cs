using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterMovement : BaseCharacterMovement
{
    // Update is called once per frame
    void Update()
    {
        Vector3 attemptedChange = Vector3.zero;

        if (PlayerInputManager.instance.GetJumpInput())
        {
            attemptedChange += ApplyJumpVector();
        }

        attemptedChange += ApplyMovementInput(PlayerInputManager.instance.GetMovementVector(), PlayerInputManager.instance.GetSprintInput());

        ApplyMotion(attemptedChange);
    }
}
