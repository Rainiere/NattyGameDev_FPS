using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Interactables
{
    [SerializeField] protected float BuffDuration; // How long the buff lasts on activation in seconds

    [SerializeField] protected float Cooldown; // How long it takes for the buff to become available for pick-up again

    [SerializeField] protected GameObject ManagerTarget; //Which Buff Manager to reference
    [SerializeField] protected float ModificationToAttribute; // How much the attribute gets changed by

    [SerializeField] protected GameObject Cube;
}