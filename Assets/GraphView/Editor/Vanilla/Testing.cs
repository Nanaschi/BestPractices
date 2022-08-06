using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class Testing : EditorWindow
{
    [MenuItem("Window/UI Toolkit/Testing")]
    public static void ShowExample()
    {
        Testing wnd = GetWindow<Testing>();
        wnd.titleContent = new GUIContent("Testing");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Hello World! From C#");
        root.Add(label);
    }
}