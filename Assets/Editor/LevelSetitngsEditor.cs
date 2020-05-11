using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelSettings))]
public class LevelSetitngsEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        LevelSettings settingsScript = (LevelSettings)target;

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        
        if (GUILayout.Button("Save Settings in file"))
        {
            settingsScript.Save();
        }        
        
        if (GUILayout.Button("Load Settings from file"))
        {
            settingsScript.Load();
        }
    }
}
