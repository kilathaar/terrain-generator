using System;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class GroundGenerator : MonoBehaviour {
	[SerializeField]
	[Range(1, 255)]
	private int width = 64;
	[SerializeField]
	[Range(1, 255)]
	private int depth = 64;
	[SerializeField]
	private float scale = 1.0f;

	public bool updateAutomatically = true;

	internal void GeneratePlane() {
		GetComponent<MeshFilter>().sharedMesh = new MeshGenerator(width + 1, depth + 1, scale).CreatePlane();
	}
}
