using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

public class DialogueSystemGraphView : UnityEditor.Experimental.GraphView.GraphView
{
    public DialogueSystemGraphView()
    {
        AddGridBackground();

        AddStyles();
    }

    private void AddStyles()
    {
        StyleSheet styleSheet = 
            (StyleSheet) EditorGUIUtility.Load
                ("DialogueSystem/DialogueSystemUSSFile.uss");
        
        styleSheets.Add(styleSheet);
    }

    private void AddGridBackground()
    {
        var gridBackground = new GridBackground();
        
        gridBackground.StretchToParentSize();
        
        Insert(0, gridBackground);
    }
}
