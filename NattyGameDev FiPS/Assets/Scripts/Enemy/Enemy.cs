using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private StateMachine _StateMachine;
    private NavMeshAgent agent;

    public NavMeshAgent Agent { get => agent;  }

    public Path path;
    public GameObject Player;
    private Vector3 PlayerLastKnownPos;
    public Vector3 _PlayerLastKnownPos { get => PlayerLastKnownPos; set => PlayerLastKnownPos = value; }

    [Header("Sight values")]
    public float SightDistance = 20f;
    public float FieldOfView = 85f;
    public float EyeHeight;

    public GameObject GunModel;

    [Header("Stats")]
    public int Health;

    [Header("Weapon values")]
    public Transform GunBarrel;
    [Range(0.1f, 10f)]
    public float FireRate;

    //For debugging
    [SerializeField]
    private string CurrentState;

    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        _StateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        _StateMachine.Initialize();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        CurrentState = _StateMachine.ActiveState.ToString();
    }

    public bool CanSeePlayer()
    {
        if(Player != null)
        {
            //Is the player close enough to be seen?
            if(Vector3.Distance(transform.position, Player.transform.position) < SightDistance)
            {
                Vector3 TargetDirection = Player.transform.position - transform.position - (Vector3.up * EyeHeight);
                float AngleToPlayer = Vector3.Angle(TargetDirection, transform.forward);
                if (AngleToPlayer >= -FieldOfView && AngleToPlayer <= FieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * EyeHeight), TargetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if(Physics.Raycast(ray, out hitInfo, SightDistance)) 
                    {
                        if(hitInfo.transform.gameObject == Player)
                        {
                            return true;
                        }
                    }
                    Debug.DrawRay(ray.origin, ray.direction * SightDistance);
                }
            }
        }
        return false;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if(Health <= 0)
        {
            if (isDead == false)
            {
                _StateMachine.ChangeState(new DeathState());
                isDead = true;
            }
        }
    }


}
