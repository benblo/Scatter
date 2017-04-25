using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class PaintSurfaceComponent : PaintComponent
{
	public Color color = Color.green;
	public MeshFilter surface;
	public Texture texture;
}
