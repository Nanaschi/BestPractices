using CleanCode.Strategy.CitizensExample.Interfaces;

namespace CleanCode.Strategy.CitizensExample.DialogueSystem
{
    public class NoDIalogueBehaviour: ISpeakable
    {
        public string Speak(Player player)
        {
            return "NoDIalogueBehaviour";
        }
    }
}