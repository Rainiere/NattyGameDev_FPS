using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Interactables
{
    [SerializeField] private float BuffDuration; // How long the buff lasts on activation in seconds
                     private bool BuffActive = false; // Bool to check if the buff is active
                     private float BuffRemainingDuration; // The remaining time the buff will be active for

    [SerializeField] private float Cooldown; // How long it takes for the buff to become available for pick-up again
                     private float CooldownRemaining;
                     private bool OnCooldown;

    [SerializeField] private GameObject ManagerTarget; //Which empty GameObject to reference
    [SerializeField] private float ModifificationToVariable; // How much the variable gets changed by
    
    //[SerializeField] private GameObject Cube; // The Cube Interactable that triggered the powerup


}