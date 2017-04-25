using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class ScatterHairComponent : LayerComponent
{
	public PaintSurfaceComponent paint;
	[Range(0, 500)]
	public float density;
	[Range(0, 10)]
	public float length;
	[Range(0, 1)]
	public float curvature;
	public Mesh outputMesh;

	public Mesh scatter()
	{
		return null;
	}

	void Reset()
	{
		paint = GetComponent<PaintSurfaceComponent>();
	}
}
