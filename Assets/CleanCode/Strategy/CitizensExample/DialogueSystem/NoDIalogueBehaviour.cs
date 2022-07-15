using CleanCode.Strategy.CitizensExample.Interfaces;

namespace CleanCode.Strategy.CitizensExample.DialogueSystem
{
    public class NoDIalogueBehaviour: ISpeakable
    {
        public void Speak(Player player)
        {
            throw new System.NotImplementedException();
        }
    }
}