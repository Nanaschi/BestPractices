using System;
using CleanCode.Strategy.CitizensExample.DialogueSystem;
using CleanCode.Strategy.CitizensExample.MoveSystem;
using CleanCode.Strategy.CitizensExample.TradingSystem;
using UnityEngine;

namespace CleanCode.Strategy.CitizensExample
{
    public class EvilCitizen: Citizen
    {
        [SerializeField] private Player _player;

        protected override void InitializeBehaviours(CitizensView citizensView)
        {
            _citizensView = citizensView;
            _tradable = new DisabledTradingBehaviour();
            _movable = new FreeMovePattern(transform, new Vector3[]{});
            _speakable = new QuestDialogueBehaviour("cap", new DialogueSystem.DialogueSystem());
        }

        private void OnEnable()
        {
            _citizensView.OnEvilCitizenButtonClicked += DoBehaviours;
        }

        private void OnDisable()
        {
            _citizensView.OnEvilCitizenButtonClicked += DoBehaviours;
        }

        private void DoBehaviours()
        {
            Trade(_player);
            Move();
            Speak(_player);
        }

        private void Start()
        {
            ChangeTrading(new ArmoryTradingBehaviour("123", new ExchangeSystem()));
        }
    }
}