using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;
using UnityEngine.AI;

public class DestroySphereState : StateBehaviour
{
    GameObjectVar sphereVar; //Get desired object
    NavMeshAgent _agent;

    private void Awake()
    {
        sphereVar = blackboard.GetGameObjectVar("sphere");
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        DestroyThatSphere();

    }

    void DestroyThatSphere()
    {
        if (sphereVar.Value != null) // if object isn't null, do calculations
        {
            Vector3 dirToSphere = transform.position - sphereVar.Value.transform.position; //Find the direction from the NPC and desired object
            Vector3 newPos = transform.position - dirToSphere;//Get the distance between the NPC and the object

            _agent.SetDestination(newPos); //Moves towards object
        }
       
    }

    void OnVisionExit()
    {
        sphereVar.Value = null; //Clear field, and change states
        SendEvent("SphereDestroyed");
    }
}


