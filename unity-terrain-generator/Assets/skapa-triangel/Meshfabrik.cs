using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Domain.Entity;

public class Meshfabrik {
	public Mesh triangel() {
		Mesh mesh = new Mesh();

		Vector3[] vertices = new Vector3[] {
			CreateVector3(new Position(0, 0, 0)),
			CreateVector3(new Position(RandomValue(), 0, 0)),
			CreateVector3(new Position(RandomValue(), RandomValue(), 0)),
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

		return mesh;
	}
	private Vector3 CreateVector3(Position position) {
		float scale = 1.0f;
		return new Vector3(position.x * scale, position.y * scale, position.z * scale);
	}

	private float RandomValue() {
		return Random.Range(0.0f, 2.0f);
	}
}
