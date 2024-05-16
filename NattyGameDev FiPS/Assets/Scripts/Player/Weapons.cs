using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] private GameObject[] WeaponsList;
    private GameObject CurrentActiveWeapon;
    [SerializeField] private Camera WeaponCam;
    private Vector3 OriginalWeaponCamPos;
    private GameObject PlayerCam;
    private GameObject Player;

    private WeaponStats _WeaponStats;
    private int Damage;
    private bool SingleFire;
    private float FireRate;
    private float OriginalFireRate;
    private float BulletVelocity;
    private float RecoilModifier;
    private float OriginalRecoilModifier;
    private float RecoilResetTimer;
    private float RecoilMax;

    private bool CanFire = true;
    private bool isFiring = false;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerCam = GameObject.FindGameObjectWithTag("PlayerCam");
        SwitchWeapon(0);
    }
    public void Update()
    {
        WeaponCam.transform.rotation = PlayerCam.transform.rotation;
        if(CanFire == false)
        {
            FireRate -= Time.deltaTime;
            if (FireRate <= 0)
            {
                FireRate = OriginalFireRate;
                CanFire = true;
            }

        }
        Shoot();

        RecoilResetTimer -= Time.deltaTime;
        if (RecoilResetTimer <= 0)
        {
            RecoilModifier -= OriginalRecoilModifier;
            RecoilResetTimer = FireRate * 1.5f;
        }
    }
    public void SwitchWeapon(int Weapon)
    {
        CurrentActiveWeapon = WeaponsList[Weapon];
        _WeaponStats = CurrentActiveWeapon.GetComponent<WeaponStats>();
        Damage = _WeaponStats.Damage;
        SingleFire = _WeaponStats.SingleFire;
        FireRate = _WeaponStats.FireRate;
        OriginalFireRate = _WeaponStats.FireRate;
        BulletVelocity = _WeaponStats.BulletVelocity;
        RecoilModifier = _WeaponStats.RecoilModifier;
        OriginalRecoilModifier = RecoilModifier;
        RecoilMax = _WeaponStats.RecoilMax;
        RecoilResetTimer = FireRate * 1.5f;
    }

    public void SetShooting()
    {
        isFiring = !isFiring;
        //Make multiple control schemes for semi and full auto

    }
    public void Shoot()
    {
        float RandomX = Random.Range(-4f, 2f) * (1 + RecoilModifier); 
        float RandomY = Random.Range(-4f, 2f) * (1 + RecoilModifier);
        if (isFiring == true)
        {
            if (CanFire == true)
            {
                RecoilModifier = Mathf.Clamp(RecoilModifier, 0, RecoilMax);
                GameObject Bullet = GameObject.Instantiate(Resources.Load("Prefabs/PlayerBullet") as GameObject, _WeaponStats.GunBarrel.transform.position, _WeaponStats.GunBarrel.transform.rotation);
                Vector3 ShootDirection = (Vector3.forward - _WeaponStats.GunBarrel.transform.position).normalized;
                Bullet.GetComponent<Rigidbody>().velocity = (Bullet.transform.forward * BulletVelocity) + new Vector3(RandomX,RandomY,0);
                RecoilModifier += RecoilModifier;
                CanFire = false;
            }
        }
     }


    public int GetDamageStat()
    {
        return Damage;
    }
}