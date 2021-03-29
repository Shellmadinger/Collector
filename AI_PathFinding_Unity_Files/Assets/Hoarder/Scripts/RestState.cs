using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

public class RestState : StateBehaviour
{
    public float restRate;
    public float maxEnergy;

    FloatVar energyVar;

    private void Awake()
    {
        energyVar = blackboard.GetFloatVar("energy"); //Needed for other states
    }

    // Update is called once per frame
    void Update()
    {
        Growth();
    }

    void Growth()
    {
        energyVar.Value += restRate * Time.deltaTime; //Increment energy by growthrate
        if (energyVar.Value >= maxEnergy)
        {
            energyVar.Value = maxEnergy; //When energy is maxed, set to max and send event IsRipe
            SendEvent("Awake");
            return;
        }
    }
}


