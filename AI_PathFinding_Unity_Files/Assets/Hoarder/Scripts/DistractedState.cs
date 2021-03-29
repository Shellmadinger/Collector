using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;
using UnityEngine.AI;

public class DistractedState : StateBehaviour
{
    GameObjectVar cubeVar; //Get desired object
    NavMeshAgent _agent;

    private void Awake()
    {
        cubeVar = blackboard.GetGameObjectVar("cube");
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update () {

        GetDistracted();
	
	}

    void GetDistracted()
    {
        if (cubeVar.Value != null) // if object isn't null, do calculations
        {
            Vector3 dirToPlayer = transform.position - cubeVar.Value.transform.position; //Find the direction from the NPC and desired object
            Vector3 newPos = transform.position - dirToPlayer; //Get the distance between the NPC and the object

            _agent.SetDestination(newPos); //Moves towards object
        }
       
    }

    void OnVisionExit()
    {
        cubeVar.Value = null; //Clear field, and change states
        SendEvent("NoLongerDistracted");
    }
}


