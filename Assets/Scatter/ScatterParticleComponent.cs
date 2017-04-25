using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

public class ScatterParticleComponent : LayerComponent
{
	public PaintComponent paint;

	[Serializable]
	public class Asset
	{
		public string name;
		public Mesh mesh;
		[Range(0, 500)]
		public float density;
		public float bla;
	}
	public Asset[] assets;

	public Vector3[] scatter()
	{
		return null;
	}

	void Reset()
	{
		paint = GetComponent<PaintComponent>();
	}
}
