using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class SkapaMark : MonoBehaviour {
	private const int resolutionX = 4;
	private const int resolutionY = 4;

	void Start() {
		var random = new System.Random();
		Mesh mesh = new Mesh();
		Vector3[] vertices = new Vector3[resolutionX * resolutionY];
		Color32[] vertexColours = new Color32[vertices.Length];

		for(int x = 0; x < resolutionX; x++) {
			for(int y = 0; y < resolutionY; y++) {
				vertices[VertexIndex(x, y)] = new Vector3(x, y, 0);
				vertexColours[VertexIndex(x, y)] = CreateRandomColour(random);
			}
		}
		mesh.vertices = vertices;
		mesh.colors32 = vertexColours;

		var numberOfSquares = (resolutionX - 1) * (resolutionY - 1);

		int[] triangles = new int[numberOfSquares * 6];

		for(int x = 0; x < resolutionX - 1; x++) {
			for(int y = 0; y < resolutionY - 1; y++) {
				var index = TriangleIndex(x, y) * 6;
				triangles[0 + index] = VertexIndex(0 + x, 0 + y);
				triangles[1 + index] = VertexIndex(0 + x, 1 + y);
				triangles[2 + index] = VertexIndex(1 + x, 1 + y);
				triangles[3 + index] = VertexIndex(0 + x, 0 + y);
				triangles[4 + index] = VertexIndex(1 + x, 1 + y);
				triangles[5 + index] = VertexIndex(1 + x, 0 + y);
			}
		}
		mesh.triangles = triangles;
		mesh.RecalculateNormals();

		GetComponent<MeshFilter>().mesh = mesh;
	}

	private Color32 CreateRandomColour(System.Random random) {
		return new Color32((byte) random.Next(0, 255), (byte) random.Next(0, 255), (byte) random.Next(0, 255), 255);
	}
	private int TriangleIndex(int x, int y) {
		return x * (resolutionY - 1) + y;
	}
	private int VertexIndex(int x, int y) {
		return x * resolutionY + y;
	}
}
