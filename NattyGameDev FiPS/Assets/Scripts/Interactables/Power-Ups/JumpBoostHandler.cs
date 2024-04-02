using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoostHandler : PowerUpHandler
{
    private PlayerMotor _PlayerMotor;

    private float JumpIncrease;
    private GameObject Cube;
    void Start()
    {
        _PlayerMotor = _Player.GetComponent<PlayerMotor>();
    }

    void Update()
    {
        //Handle once activated
        if (OnCooldown == true) //Handles Cube activity
        {
            CooldownRemainingDuration -= Time.deltaTime;
            if (CooldownRemainingDuration <= 0)
            {
                OnCooldown = false;
                Cube.SetActive(true);
            }
        }
        if (BuffActive == true) //Handles Player activity
        {
            BuffRemainingDuration -= Time.deltaTime;
            if (BuffRemainingDuration <= 0)
            {
                _PlayerMotor.SetJumpHeight(-JumpIncrease, false);
                BuffActive = false;
            }
        }
    }
public void HandlePowerUp(GameObject _Cube, float BuffDuration, float _JumpIncrease, float CooldownDuration)
    {
        //Handle on Interact
        OnCooldown = true;
        BuffActive = true;
        Cube = _Cube;
        CooldownRemainingDuration = CooldownDuration + BuffDuration;
        BuffRemainingDuration = BuffDuration;
        JumpIncrease = _JumpIncrease;
        _PlayerMotor.SetJumpHeight(JumpIncrease, true);
        Cube.SetActive(false);
    }
}
