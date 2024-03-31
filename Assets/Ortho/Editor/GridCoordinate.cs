using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GridCoordinate : EditorWindow
{
    [SerializeField]
    private VisualTreeAsset m_VisualTreeAsset = default;

    private ProjCoordinate grid;
    [MenuItem("Window/UI Toolkit/GridCoordinate")]
    public static void ShowExample()
    {
        GridCoordinate wnd = GetWindow<GridCoordinate>();
        wnd.titleContent = new GUIContent("GridCoordinate");
    }

    private void OnEnable() {
        SceneView.duringSceneGui += DrawSceneGUI;
        grid = GameObject.Find("Coordinate").GetComponent<ProjCoordinate>();
    }

    private void DrawSceneGUI(SceneView obj) {
        Handles.BeginGUI();
        GUILayout.BeginArea(obj.position);
        GUILayout.Label(grid.capsule.transform.localPosition.ToString());
        GUILayout.EndArea();
        Handles.EndGUI();
    }

    private void OnDisable() {
        SceneView.duringSceneGui -= DrawSceneGUI;
    }
    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;
        
        // Instantiate UXML
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);

        var position = labelFromUXML.Query<Vector3Field>("Position");
    }
}
