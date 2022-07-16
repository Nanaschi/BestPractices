using CleanCode.Strategy.CitizensExample.Interfaces;

namespace CleanCode.Strategy.CitizensExample.DialogueSystem
{
    public class SimpleDialogueBehaviour: ISpeakable
    {
        private string _characterKey;
        private DialogueSystem _dialogueSystem;

        public SimpleDialogueBehaviour(string key, DialogueSystem dialogueSystem)
        {
            _characterKey = key;
            _dialogueSystem = dialogueSystem;
        }
        
        
        public void Speak(Player player)
        {
            _dialogueSystem.OpenSmallDialogue(_characterKey);
        }
    }
}