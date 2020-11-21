using System;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class PlaneGenerator : MonoBehaviour {
	[SerializeField]
	private int resolutionX = 64;
	[SerializeField]
	private int resolutionY = 64;

	public bool updateAutomatically = true;

	internal void GeneratePlane() {
		GetComponent<MeshFilter>().sharedMesh = new MeshGenerator(resolutionX, resolutionY).CreatePlane();
	}
}
