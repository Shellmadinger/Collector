using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;
using UnityEngine.AI;

public class ChaseState : StateBehaviour
{
    GameObjectVar playerVar;
    GameObjectVar hoarderVar;
    NavMeshAgent _agent;

    private void Awake()
    {
        playerVar = blackboard.GetGameObjectVar("player");
        hoarderVar = blackboard.GetGameObjectVar("hoarder");

        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Flee();
    }

    void Flee()
    {
        //Check with target was in view. Do appropriate calculations
        if (playerVar.Value != null)
        {
            Vector3 dirToPlayer = transform.position - playerVar.Value.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;

            _agent.SetDestination(newPos);
        }

        if (hoarderVar.Value != null)
        {
            Vector3 dirToHoarder = transform.position - hoarderVar.Value.transform.position;
            Vector3 newPosOff = transform.position - dirToHoarder;

            _agent.SetDestination(newPosOff);
        }

    }

    void OnVisionExit()
    {
        //Clear both fields, and change states
        playerVar.Value = null;
        hoarderVar.Value = null;
        SendEvent("TargetLost");
    }

}


