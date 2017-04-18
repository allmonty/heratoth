using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "AI/SerializableDictionary")]
[Serializable] //????
public class SerializableDictionary : ScriptableObject {
	[NonSerialized] public Dictionary<string, ScriptableObject> dictionary = new Dictionary<string, ScriptableObject>();
}
