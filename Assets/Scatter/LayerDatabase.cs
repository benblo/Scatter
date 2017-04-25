using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class LayerDatabase : MonoBehaviour
{
	public Layer[] layers;


	[ContextMenu("Collect Layers")]
	protected void collectLayers()
	{
		layers = GetComponentsInChildren<Layer>();
		EditorUtility.SetDirty(this);
	}

	[MenuItem("Swing/Test/Some Menu")]
	static void someMenu()
	{
		Debug.Log("hey from menu");
	}
}
