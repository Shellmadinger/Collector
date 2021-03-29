using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;
using UnityEngine.AI;

public class KickCubeState : StateBehaviour
{
    GameObjectVar cubeVar;
    NavMeshAgent _agent;

    private void Awake()
    {
        cubeVar = blackboard.GetGameObjectVar("cube");
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        DestroyThatSphere();

    }

    void DestroyThatSphere()
    {
        if (cubeVar.Value != null)
        {
            Vector3 dirToPlayer = transform.position - cubeVar.Value.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;

            _agent.SetDestination(newPos);
        }

    }

    void OnVisionExit()
    {
        cubeVar.Value = null;
        SendEvent("CubeKicked");
    }
}


