using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkapaOchRenderaTriangel : MonoBehaviour {
	[SerializeField]
	private float maxX = 10.0f;

	[SerializeField]
	private float maxY = 10.0f;

	private Mesh mesh;

	private void Awake() {
		mesh = new Mesh();
	}

	// Start is called before the first frame update
	void Start() {
		MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

		Vector3[] vertices = new Vector3[3] {
			new Vector3(0, 0, 0),
			new Vector3(1, 0, 0),
			new Vector3(1, 1, 0),
		};
		mesh.vertices = vertices;

		int[] triangles = new int[3] {
			// Index i vertices-vektor deklarerade medsols
			0, 2, 1
		};
		mesh.triangles = triangles;

		Vector3[] normals = new Vector3[3] {
			Vector3.forward,
			Vector3.forward,
			Vector3.forward
		};
		mesh.normals = normals;

		meshFilter.mesh = mesh;
	}

	// Update is called once per frame
	void Update() {

	}
}
