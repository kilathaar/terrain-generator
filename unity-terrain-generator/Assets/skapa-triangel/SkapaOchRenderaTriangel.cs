using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Domain.Entity;

public class SkapaOchRenderaTriangel : MonoBehaviour {
	[SerializeField]
	private float maxX = 1.0f;

	[SerializeField]
	private float maxY = 1.0f;

	private Mesh mesh;

	private void Awake() {
		mesh = new Mesh();
	}

	// Start is called before the first frame update
	void Start() {
		MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

		Vector3[] vertices = new Vector3[3] {
			CreateVector3(new Position(0, 0, 0)),
			CreateVector3(new Position(RandomValue(), 0, 0)),
			CreateVector3(new Position(RandomValue(), RandomValue(), 0))
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
		mesh.RecalculateNormals();

		meshFilter.mesh = mesh;
	}

	private Vector3 CreateVector3(Position position) {
		return new Vector3(position.x, position.y, position.z);
	}

	private float RandomValue() {
		return Random.Range(0.0f, 2.0f);
	}
}
