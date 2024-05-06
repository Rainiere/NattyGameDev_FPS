using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    [SerializeField] private GameObject[] WeaponsList;
    private GameObject CurrentActiveWeapon;
    [SerializeField] private Camera WeaponCam;
    private GameObject PlayerCam;
    private GameObject Player;

    private WeaponStats _WeaponStats;
    private int Damage;
    private bool SingleFire;
    private float FireRate;
    private float OriginalFireRate;
    private float BulletVelocity;

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
    }

    public void SetShooting()
    {
        isFiring = !isFiring;
    }
    public void Shoot()
    {
        if (isFiring == true)
        {
            if (CanFire == true)
            {
                GameObject Bullet = GameObject.Instantiate(Resources.Load("Prefabs/PlayerBullet") as GameObject, _WeaponStats.GunBarrel.transform.position, _WeaponStats.GunBarrel.transform.rotation);
                Vector3 ShootDirection = (_WeaponStats.GunBarrel.transform.position);
                Bullet.GetComponent<Rigidbody>().velocity = (Bullet.transform.forward * BulletVelocity);
                CanFire = false;
            }
        }
     }


    public int GetDamageStat()
    {
        return Damage;
    }
}