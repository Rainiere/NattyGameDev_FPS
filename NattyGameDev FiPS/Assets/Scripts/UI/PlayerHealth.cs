using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private float Health;
    private float LerpTimer;
    public float MaxHealth = 100;
    public float ChipSpeed = 2f; //The delay before the health(front or back)bar catches up to the other one on health change.

    public Image FrontHealthbar;
    public Image BackHealthbar;
    public Image DamageEffectBloodsplatter;


    [SerializeField] private TextMeshProUGUI CurrentHealthText;
    [SerializeField] private TextMeshProUGUI MaxHealthText;
    int TimesPressed;
    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
        CurrentHealthText.text = Health.ToString();
        MaxHealthText.text = MaxHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        UpdateHealthUI();
        if (Input.GetKeyUp(KeyCode.F))
        {
            //TakeDamage(Random.Range(5, 10));
            TakeDamage(50);
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            RestoreHealth(Random.Range(5, 10));
        }
    }

    public void UpdateHealthUI()
    {
        float FillFront = FrontHealthbar.fillAmount;
        float FillBack = BackHealthbar.fillAmount;
        float HealthFraction = Health / MaxHealth;
        var BloodsplatterColor = DamageEffectBloodsplatter.color;

        if (FillBack > HealthFraction)
        {
            FrontHealthbar.fillAmount = HealthFraction;
            BackHealthbar.color = Color.red;
            LerpTimer += Time.deltaTime;
            float PercentComplete = LerpTimer / ChipSpeed;
            PercentComplete = PercentComplete * PercentComplete;
            BackHealthbar.fillAmount = Mathf.Lerp(FillBack, HealthFraction, PercentComplete);
            CurrentHealthText.text = Health.ToString();
            BloodsplatterColor.a = 0.75f - HealthFraction;
            DamageEffectBloodsplatter.color = Color.Lerp(DamageEffectBloodsplatter.color, BloodsplatterColor, 1f * Time.deltaTime);

        }
        if (FillFront < HealthFraction)
        {
            BackHealthbar.color = Color.green;
            BackHealthbar.fillAmount = HealthFraction;
            LerpTimer += Time.deltaTime;
            float PercentComplete = LerpTimer / ChipSpeed;
            PercentComplete = PercentComplete * PercentComplete;
            FrontHealthbar.fillAmount = Mathf.Lerp(FillFront, BackHealthbar.fillAmount, PercentComplete);
            CurrentHealthText.text = Health.ToString();
            BloodsplatterColor.a = 1f - HealthFraction;     
            DamageEffectBloodsplatter.color = Color.Lerp(DamageEffectBloodsplatter.color, BloodsplatterColor, 1f * Time.deltaTime);
        }
    }

    public void TakeDamage(int Damage)
    {
        Health -= Damage;
        LerpTimer = 0f;
    }

    public void RestoreHealth(int Healing)
    {
        Health += Healing;
        LerpTimer = 0f;
    }

    public float GetHealthValue()
    {
        return Health;
    }
}
