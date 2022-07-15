namespace CleanCode.Strategy.CitizensExample.DialogueSystem
{
    public class QuestDialogueBehaviour
    {
        private string _characterKey;
        private DialogueSystem _dialogueSystem;

        QuestDialogueBehaviour(string key, DialogueSystem dialogueSystem)
        {
            _characterKey = key;
            _dialogueSystem = dialogueSystem;
        }
        
        
        public void Speak(Player player)
        {
            _dialogueSystem.OpenQuestDialogue(_characterKey);
        }
    }
}