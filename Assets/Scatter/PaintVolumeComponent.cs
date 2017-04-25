using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class PaintVolumeComponent : PaintComponent
{
	public Color color = Color.red;
	public BoxCollider volume;
}
