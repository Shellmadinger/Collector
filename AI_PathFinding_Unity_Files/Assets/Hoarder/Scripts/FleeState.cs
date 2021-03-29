using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;
using UnityEngine.AI;

public class FleeState : StateBehaviour
{

    GameObjectVar playerVar;
    GameObjectVar officerVar;
    NavMeshAgent _agent;

    private void Awake()
    {
        playerVar = blackboard.GetGameObjectVar("player");
        officerVar = blackboard.GetGameObjectVar("officer");

        _agent = GetComponent<NavMeshAgent>();
    }

    void OnDisable () {
        StopAllCoroutines();
	}  

    // Update is called once per frame
    void Update () {
        Flee();
	}

    void Flee()
    {
        //check which field is not null, and do respective calculations
        if (playerVar.Value != null)
        {
            Vector3 dirToPlayer = transform.position - playerVar.Value.transform.position;
            Vector3 newPos = transform.position + dirToPlayer; //Unlike other states, the direction is used to find the distance way from the object

            _agent.SetDestination(newPos); //Set position away from object
        }
       
        if (officerVar.Value != null)
        {
            Vector3 dirToOfficer = transform.position - officerVar.Value.transform.position;
            Vector3 newPosOff = transform.position + dirToOfficer;

            _agent.SetDestination(newPosOff);
        }

    }

    void OnVisionExit()
    {
        StartCoroutine(WaitForPatrol()); //if an object is out of view, start coroutine
    }

    IEnumerator WaitForPatrol()
    {
        yield return new WaitForSeconds(3f); //Keeping hoarder fleeing for 3 seconds
        playerVar.Value = null;//After three seconds, clear both fields, and change state
        officerVar.Value = null;
        SendEvent("NoMoreDanger");
    }

}


