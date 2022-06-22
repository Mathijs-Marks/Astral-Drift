using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(GenerateMap))]
public class MapGenerateEditor : Editor
{
    // Start is called before the first frame update
 public override void OnInspectorGUI()
    {
        GenerateMap mapGen = (GenerateMap)target;

        if (DrawDefaultInspector())
        {
            if (mapGen.autoUpdate)
            {
                mapGen.DrawMapInEditor();
            }
        }
        if (GUILayout.Button("Generate"))
        {
            mapGen.DrawMapInEditor();
        }
    }
}
