using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : PowerUp
{
    //[SerializeField] private float BuffDuration; // How long the buff lasts on activation in seconds
    //private bool BuffActive = false; // Bool to check if the buff is active
    //private float BuffRemainingDuration; // The remaining time the buff will be active for

    //[SerializeField] private float Cooldown;
    //private float CooldownRemaining;
    //private bool OnCooldown;

    //[SerializeField] private float JumpIncrease;

    //[SerializeField] private GameObject _Player;
    //private PlayerMotor _PlayerMotor;

    //[SerializeField] private GameObject Cube;

    //void Start()
    //{
    //    _PlayerMotor = _Player.GetComponent<PlayerMotor>();
    //}

    //protected override void Interact()
    //{
    //    if (BuffActive)
    //    {
    //        BuffRemainingDuration = BuffDuration;
    //    }
    //        else
    //    {
    //        BuffActive = true;
    //        _PlayerMotor.SetJumpHeight(JumpIncrease);
    //        BuffRemainingDuration = BuffDuration;
    //    }
    //            //        Cube.SetActive(false);
    //            //CooldownRemaining = Cooldown + BuffDuration;
    //            //OnCooldown = true;
    //}

    //void Update()
    //{
    //    if (BuffActive)
    //    {
    //        BuffRemainingDuration -= Time.deltaTime;
    //        if (BuffRemainingDuration <= 0)
    //        {
    //            _PlayerMotor.SetJumpHeight(-JumpIncrease);
    //            BuffActive = false;
    //        }
    //    }
    //    if (OnCooldown)
    //    {
    //        CooldownRemaining -= Time.deltaTime;
    //        if (CooldownRemaining <= 0)
    //        {
    //            Cube.SetActive(true);
    //            OnCooldown = false;
    //        }
    //    }
    //}
}
