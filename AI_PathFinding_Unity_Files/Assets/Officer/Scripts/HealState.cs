using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;
using UnityEngine.AI;

public class HealState : StateBehaviour
{
    public float healAmount;

    GameObjectVar canisterVar;
    FloatVar energyVar;
    NavMeshAgent _agent;

    private void Awake()
    {
        canisterVar = blackboard.GetGameObjectVar("canister");
        energyVar = blackboard.GetFloatVar("energy");
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        GoForCollection();

    }

    void GoForCollection()
    {
        if (canisterVar.Value != null)
        {
            Vector3 dirToPlayer = transform.position - canisterVar.Value.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;

            _agent.SetDestination(newPos);
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Canister") //When the Officer collides with a heal canister, they heal a set amount of energy
        {
            energyVar.Value += healAmount;
        }
    }

    void OnVisionExit()
    {
        canisterVar.Value = null;
        SendEvent("Healed");
    }
}


