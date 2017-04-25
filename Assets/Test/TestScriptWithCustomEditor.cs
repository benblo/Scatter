using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class TestScriptWithCustomEditor : MonoBehaviour
{
	public string someString;
}

[CustomEditor(typeof(TestScriptWithCustomEditor))]
public class TestCustomEditor : Editor
{
	bool drawDefaultEditor = true;

	public override void OnInspectorGUI()
	{
		TestScriptWithCustomEditor target = (TestScriptWithCustomEditor)base.target;

		GUILayout.Label("hello world before");
		GUILayout.Label("target is called " + target.name);
		GUILayout.Label("target says " + target.someString);

		drawDefaultEditor = GUILayout.Toggle(drawDefaultEditor, "drawDefaultEditor");
		if (drawDefaultEditor)
		{
			GUILayout.Space(10);
			base.OnInspectorGUI();
			GUILayout.Space(10);
		}

		GUILayout.Label("hello world after");
	}
}
