using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    [SerializeField] public GameObject GunBarrel;
    [SerializeField] public GameObject Bullet;

    [Header ("Stats")]
    [SerializeField] public int Damage;
    [SerializeField] public bool SingleFire;
    [SerializeField] public float FireRate;
    [SerializeField] public int BulletVelocity;
    [SerializeField] public float RecoilModifier;
    [SerializeField] public float RecoilMax;
}
