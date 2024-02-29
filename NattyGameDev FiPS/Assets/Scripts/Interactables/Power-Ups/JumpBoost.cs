using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : PowerUp
{
private JumpBoostHandler _Handler;

    void Start()
    {
        _Handler = ManagerTarget.GetComponent<JumpBoostHandler>();
    }

    protected override void Interact()
    {
        _Handler.HandlePowerUp(Cube, BuffDuration, ModificationToAttribute, Cooldown);
    }

}
