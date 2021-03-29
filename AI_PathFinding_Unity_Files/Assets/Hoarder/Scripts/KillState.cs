using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;
using UnityEngine.AI;

public class KillState : StateBehaviour
{
    GameObjectVar playerVar;
    NavMeshAgent _agent;

    private void Awake()
    {
        playerVar = blackboard.GetGameObjectVar("player");
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        GoAfterPlayer();

    }

    void GoAfterPlayer()
    {
        if (playerVar.Value != null)
        {
            Vector3 dirToPlayer = transform.position - playerVar.Value.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;

            _agent.SetDestination(newPos);
        }
        
    }

    void OnVisionExit()
    {
        playerVar.Value = null;
        SendEvent("CalmingDown");
    }
}


