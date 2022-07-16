using System;
using CleanCode.Strategy.CitizensExample.DialogueSystem;
using CleanCode.Strategy.CitizensExample.MoveSystem;
using CleanCode.Strategy.CitizensExample.TradingSystem;
using UnityEngine;

namespace CleanCode.Strategy.CitizensExample
{
    public class EvilCitizen: Citizen
    {
        private CitizensView _citizensView1;

        protected override void InitializeBehaviours(CitizensView citizensView)
        {
            _citizensView1 = citizensView;
            _tradable = new DisabledTradingBehaviour();
            _movable = new FreeMovePattern(transform, new Vector3[]{});
            _speakable = new QuestDialogueBehaviour("cap", new DialogueSystem.DialogueSystem());
        }

        private void OnEnable()
        {
            _citizensView1.OnEvilCitizenButtonClicked += DoBehaviours;
        }

        private void OnDisable()
        {
            _citizensView1.OnEvilCitizenButtonClicked += DoBehaviours;
        }

        private void DoBehaviours()
        {
            _tradable.Trade(new Player());
            _movable.Move();
            _speakable.Speak(new Player());
        }

        /*private void Start()
        {
            ChangeTrading(new ArmoryTradingBehaviour("123", new ExchangeSystem()));
        }*/
    }
}