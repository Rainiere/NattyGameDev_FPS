using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState ActiveState;
    // property for the patrol state
    public PatrolState _PatrolState;
    public void Initialize()
    {
        _PatrolState = new PatrolState();
        ChangeState(_PatrolState);

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ActiveState != null)
        {
            ActiveState.Perform();
        }
    }

    public void ChangeState(BaseState NewState)
    {
        if(ActiveState != null)
        {
            //Clean-up of the active state
            ActiveState.Exit();
        }
        //Change to a new state
        ActiveState = NewState;

        //Fail-safe check to make sure the new state isn't null
        if(ActiveState != null ) {
            //Set up the new state
            ActiveState.stateMachine = this;
            ActiveState.enemy = GetComponent<Enemy>();
            ActiveState.Enter();
        }
    }
}
