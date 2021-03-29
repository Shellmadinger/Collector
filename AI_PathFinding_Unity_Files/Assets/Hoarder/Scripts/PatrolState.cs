using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class PatrolState : StateBehaviour
{
    public List<GameObject> targets;
    public int wayPointIndex;
    public float decayRate;
    public HudManager checkScore;

    UnityEngine.AI.NavMeshAgent agent;
    FloatVar energyVar;
    GameObjectVar playerVar;
    GameObjectVar cubeVar;
    GameObjectVar sphereVar;
    GameObjectVar officerVar;

    private void Awake()
    {
        //Getting all require components
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        energyVar = blackboard.GetFloatVar("energy");
        playerVar = blackboard.GetGameObjectVar("player");
        cubeVar = blackboard.GetGameObjectVar("cube");
        sphereVar = blackboard.GetGameObjectVar("sphere");
        officerVar = blackboard.GetGameObjectVar("officer");
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
            //if the Hoarder sees the player, check if they have 10 or more spheres.
            if (checkScore.scoreCountPlayer >= 10)
            {
                //If player has 10 or more spheres, go to chase state
                playerVar.Value = other;
                SendEvent("Angry");
            }
            //otherwise, go to flee state
            playerVar.Value = other;
            SendEvent("DangerDetected");
        }

        if (other.tag == "Officer")
        {
            officerVar.Value = other;
            SendEvent("DangerDetected");
        }

        if (other.tag == "Sphere")
        {
            sphereVar.Value = other;
            SendEvent("SphereDetected");
        }

        if (other.tag == "Cube")
        {
            cubeVar.Value = other;
            SendEvent("Distracted");
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


