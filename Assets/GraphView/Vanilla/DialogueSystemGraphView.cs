using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

public class DialogueSystemGraphView : UnityEditor.Experimental.GraphView.GraphView
{
    public DialogueSystemGraphView()
    {
        AddGridBackground();
    }

    private void AddGridBackground()
    {
        var gridBackground = new GridBackground();
        
        gridBackground.StretchToParentSize();
        
        Insert(0, gridBackground);
    }
}
