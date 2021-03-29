//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// Wrapper class for the InternalAnyState component.
    /// <summary>
    [RequireComponent(typeof(StateMachine))]
    public class AnyState : InternalAnyState {

        FloatVar energyVar;
        public float decayRate;

        private void Awake()
        {
            energyVar = blackboard.GetFloatVar("energy");
            decayRate = 5;
        }

        private void Update()
        {
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
    }

   
}