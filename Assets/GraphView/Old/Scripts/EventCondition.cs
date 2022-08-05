using PeartreeGames.EvtGraph;

namespace GraphView.Scripts
{
    public abstract class EventCondition: EventNodeItemData
    {
        public abstract bool CheckIsSatisfied(EvtTrigger evtTrigger);
    }
}