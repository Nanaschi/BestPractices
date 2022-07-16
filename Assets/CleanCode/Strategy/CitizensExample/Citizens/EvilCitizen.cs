using System;
using CleanCode.Strategy.CitizensExample.DialogueSystem;
using CleanCode.Strategy.CitizensExample.MoveSystem;
using CleanCode.Strategy.CitizensExample.TradingSystem;
using UnityEngine;

namespace CleanCode.Strategy.CitizensExample
{
    public class EvilCitizen: Citizen
    {

        protected override void InitializeBehaviours(CitizensView citizensView)
        {
            citizensView.OnEvilCitizenButtonClicked += DoBehaviours;
            _tradable = new DisabledTradingBehaviour();
            _movable = new PatrolPattern(transform, new Vector3[]{Vector3.zero});
            _speakable = new SimpleDialogueBehaviour("cap", new DialogueSystem.DialogueSystem());
        }

        private void DoBehaviours()
        {
            _tradable.Trade(new Player());
        }

        /*private void Start()
        {
            ChangeTrading(new ArmoryTradingBehaviour("123", new ExchangeSystem()));
        }*/
    }
}