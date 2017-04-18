using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SerializableDictionary))]
[CanEditMultipleObjects]
public class Editor_SerializableDictionary : Editor {

	private SerializableDictionary it;

	private List<string> keysToDelete;

	private string newKey = "new key";
	private ScriptableObject newObject = null;

    void OnEnable()
    {
        it = target as SerializableDictionary;
		keysToDelete = new List<string>();
    }

	public override void OnInspectorGUI()
	{
		GUILayout.BeginHorizontal("box");
		GUILayout.Label("Serializable Dictionary");
		GUILayout.EndHorizontal();

		foreach(string key in it.dictionary.Keys)
		{
			GUILayout.BeginHorizontal("box");

			GUI.SetNextControlName(key);
			EditorGUILayout.ObjectField(key ,it.dictionary[key], typeof(ScriptableObject), true);

			if (Event.current.isKey && Event.current.keyCode == KeyCode.Delete && GUI.GetNameOfFocusedControl() == key)
			{
				Debug.Log(GUI.GetNameOfFocusedControl());
				keysToDelete.Add(key);
			}

			GUILayout.EndHorizontal();
		}

		GUILayout.BeginHorizontal("box");
		newKey = GUILayout.TextField(newKey);
		newObject = EditorGUILayout.ObjectField(newObject, typeof(ScriptableObject), true) as ScriptableObject;
		if(GUILayout.Button("+")){
			addNewEntryToDictionary();
			//deveria salvar no scriptableobject
			EditorUtility.SetDirty(it);
			AssetDatabase.SaveAssets();
			AssetDatabase.Refresh();
		}
		GUILayout.EndHorizontal();

		if(GUI.changed)
		{
			deleteKeysFromDictionary();
		}
	}

	private void deleteKeysFromDictionary()
	{
		foreach(string key in keysToDelete)
		{
			it.dictionary.Remove(key);
		}
		keysToDelete.Clear();
	}

	private void addNewEntryToDictionary()
	{
		it.dictionary.Add(newKey, newObject);
		newKey = "new key";
		newObject = null;
	}
}
