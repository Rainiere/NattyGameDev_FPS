using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private NavMeshAgent agent;

    public NavMeshAgent Agent { get => agent;  }

    //For debugging
    [SerializeField]
    private string CurrentState;
    public Path path;
    private GameObject Player;
    public float SightDistance = 20f;
    public float FieldOfView = 85f;
    public float EyeHeight;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        stateMachine.Initialize();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
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

    
}
