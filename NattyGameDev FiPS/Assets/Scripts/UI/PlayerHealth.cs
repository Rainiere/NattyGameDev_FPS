using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float Health;
    private float LerpTimer;
    public float MaxHealth = 100;
    public float ChipSpeed = 2f; //The delay before the health(front or back)bar catches up to the other one on health change.

    public Image FrontHealthbar;
    public Image BackHealthbar;

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;    
    }

    // Update is called once per frame
    void Update()
    {
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        UpdateHealthUI();

        if (Input.GetKeyUp(KeyCode.F))
        {
            TakeDamage(Random.Range(5, 10));
        }
        if (Input.GetKeyUp(KeyCode.G)) {
            RestoreHealth(Random.Range(5, 10));
        }
    }

    public void UpdateHealthUI()
    {
        float FillFront = FrontHealthbar.fillAmount;
        float FillBack = BackHealthbar.fillAmount;
        float HealthFraction = Health / MaxHealth;
        if (FillBack > HealthFraction)
        {
            FrontHealthbar.fillAmount = HealthFraction;
            BackHealthbar.color = Color.red;
            LerpTimer += Time.deltaTime;
            float PercentComplete = LerpTimer / ChipSpeed;
            PercentComplete = PercentComplete * PercentComplete;
            BackHealthbar.fillAmount = Mathf.Lerp(FillBack, HealthFraction, PercentComplete);
        }
        if (FillFront < HealthFraction)
        {
            BackHealthbar.color = Color.green;
            BackHealthbar.fillAmount = HealthFraction;
            LerpTimer += Time.deltaTime;
            float PercentComplete = LerpTimer / ChipSpeed;
            PercentComplete = PercentComplete * PercentComplete;
            FrontHealthbar.fillAmount = Mathf.Lerp(FillFront, BackHealthbar.fillAmount, PercentComplete);
        }
    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
        LerpTimer = 0f;
    }

    public void RestoreHealth(float Healing)
    {
        Health += Healing;
        LerpTimer = 0f;
    }

    public float GetHealthValue()
    {
        return Health;
    }
}
