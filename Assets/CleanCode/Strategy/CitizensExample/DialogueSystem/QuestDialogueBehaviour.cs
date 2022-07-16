using CleanCode.Strategy.CitizensExample.Interfaces;

namespace CleanCode.Strategy.CitizensExample.DialogueSystem
{
    public class QuestDialogueBehaviour: ISpeakable
    {
        private string _characterKey;
        private DialogueSystem _dialogueSystem;

        public QuestDialogueBehaviour(string key, DialogueSystem dialogueSystem)
        {
            _characterKey = key;
            _dialogueSystem = dialogueSystem;
        }
        
        
        public string Speak(Player player)
        {
             _dialogueSystem.OpenQuestDialogue(_characterKey);
             return "QuestDialogueBehaviour";
        }
    }
}