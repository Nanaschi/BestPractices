using System.Collections;
using PeartreeGames.EvtGraph;

namespace GraphView.Scripts
{
    public abstract class EventReaction: EventNodeItemData
    {
        public abstract IEnumerator React(EvtTrigger evtTrigger);
    }
}