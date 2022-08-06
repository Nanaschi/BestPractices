using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class DSGraphWindow : EditorWindow
{


    [MenuItem("Window/DS/Dialogue Graph")]

    public static void Open()
    {
        GetWindow<DSGraphWindow>("Dialogue Graph");
    }


    private void OnEnable()
    {
        AddGraphView();
        AddStyles();
    }

    private void AddStyles()
    {
        StyleSheet styleSheet = 
            (StyleSheet) EditorGUIUtility.Load
                ("DialogueSystem/DialogueSystemUSSFile.uss");
        
        rootVisualElement.styleSheets.Add(styleSheet);
    }

    private void AddGraphView()
    {
        DialogueSystemGraphView dialogueSystemGraphView
            = new DialogueSystemGraphView();
        
        dialogueSystemGraphView.StretchToParentSize();
        
        rootVisualElement.Add(dialogueSystemGraphView);
    }
}
