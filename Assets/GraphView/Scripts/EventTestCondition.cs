using PeartreeGames.EvtGraph;
using UnityEngine;

namespace GraphView.Scripts
{
    public class EventTestCondition: EventCondition
    {
        [SerializeField] private bool value;
        
        public override bool CheckIsSatisfied(EvtTrigger evtTrigger)
        {
            return value;
        }
    }
}