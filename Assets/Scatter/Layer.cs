using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class Layer : MonoBehaviour
{
	public LayerComponent[] components;


	[ContextMenu("Collect Components")]
	protected void collectLayers()
	{
		components = GetComponentsInChildren<LayerComponent>();
		EditorUtility.SetDirty(this);
	}
}

public abstract class LayerComponent : MonoBehaviour
{
}

public abstract class PaintComponent : LayerComponent
{
}
