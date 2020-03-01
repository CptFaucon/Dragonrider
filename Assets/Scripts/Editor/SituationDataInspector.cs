using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SituationData)), CanEditMultipleObjects]
public class SituationDataInspector : Editor {

	public override void OnInspectorGUI () {
		serializedObject.Update();
        EditorGUILayout.PropertyField(serializedObject.FindProperty("majorChallenge"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("difficulty"));
        EditorList.Show(serializedObject.FindProperty("elements"), EditorListOption.NoListSize | EditorListOption.Buttons);
		serializedObject.ApplyModifiedProperties();
	}
}
