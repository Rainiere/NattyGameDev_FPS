using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpHandler : MonoBehaviour
{
    protected bool BuffActive = false; // Bool to check if the buff is active
    protected float BuffRemainingDuration; // The remaining time the buff will be active for

    protected bool OnCooldown = false;
    protected float CooldownRemainingDuration;

    [SerializeField] protected GameObject _Player;
}
