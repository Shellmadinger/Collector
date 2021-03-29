using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class PatrolStateOfficer : StateBehaviour
{
    public List<GameObject> targets;
    public int wayPointIndex;
    public float decayRate;

    UnityEngine.AI.NavMeshAgent agent;
    FloatVar energyVar;
    GameObjectVar playerVar;
    GameObjectVar cubeVar;
    GameObjectVar sphereVar;
    GameObjectVar hoarderVar;
    GameObjectVar canisterVar;

    private void Awake()
    {
        //Getting all require components
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>(); 
        energyVar = blackboard.GetFloatVar("energy");
        playerVar = blackboard.GetGameObjectVar("player");
        cubeVar = blackboard.GetGameObjectVar("cube");
        sphereVar = blackboard.GetGameObjectVar("sphere");
        hoarderVar = blackboard.GetGameObjectVar("hoarder");
        canisterVar = blackboard.GetGameObjectVar("canister");
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(targets[wayPointIndex].transform.position); //Set distance towards way points
        EnergyDrain();
    }

    void EnergyDrain()
    {
        energyVar.Value -= decayRate * Time.deltaTime; //Lose energy
        if (energyVar.Value <= 0)
        {
            energyVar.Value = 0;
            SendEvent("Tired");
        }
    }

    void OnVisionEnter(GameObject other)
    {
        //if a seeable object enters vision, store object in respective variable, and change to the appropriate state
        if (other.tag == "Player")
        {
            playerVar.Value = other;
            SendEvent("BeginChase");
        }


        if (other.tag == "Hoarder")
        {
            hoarderVar.Value = other;
            SendEvent("BeginChase");

        }

        if (other.tag == "Cube")
        {
            cubeVar.Value = other;
            SendEvent("ApproachCube");

        }

        if (other.tag == "Sphere")
        {
            sphereVar.Value = other;
            SendEvent("DestroySphere");

        }

        if (other.tag == "Canister")
        {
            canisterVar.Value = other;
            SendEvent("GetCanister");

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targets[wayPointIndex])
        {
            wayPointIndex = (wayPointIndex + 1) % targets.Count; //Find next waypoint in list after reaching one
        }
    }
}


