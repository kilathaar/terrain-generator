using UnityEngine;

public class MeshGenerator {
	private readonly int resolutionZ;

	private Vector3[] vertices;
	private int[] triangles;
	private Color32[] vertexColours;

	public MeshGenerator(int resolutionX, int resolutionZ) {
		this.resolutionZ = resolutionZ;

		vertices = CreateVertices(resolutionX, resolutionZ);
		triangles = CreateTriangles(resolutionX, resolutionZ);
		vertexColours = CreateColours(resolutionX, resolutionZ);
	}

	public Mesh CreatePlane() {
		Mesh mesh = new Mesh();
		mesh.vertices = vertices;
		mesh.colors32 = vertexColours;
		mesh.triangles = triangles;
		mesh.RecalculateNormals();
		return mesh;
	}

	private Vector3[] CreateVertices(int resolutionX, int resolutionz) {
		var vertices = new Vector3[resolutionX * resolutionz];

		for(int x = 0; x < resolutionX; x++) {
			for(int z = 0; z < resolutionz; z++) {
				vertices[VertexIndex(x, z)] = new Vector3(x, 0, z);
			}
		}

		return vertices;
	}

	private Color32[] CreateColours(int resolutionX, int resolutionY) {
		var colours = new Color32[resolutionX * resolutionY];
		var random = new System.Random();

		for(int x = 0; x < resolutionX; x++) {
			for(int z = 0; z < resolutionY; z++) {
				colours[VertexIndex(x, z)] = CreateRandomColour(random);
			}
		}

		return colours;
	}

	private int[] CreateTriangles(int resolutionX, int resolutionZ) {
		var numberOfSquares = (resolutionX - 1) * (resolutionZ - 1);
		var triangles = new int[numberOfSquares * 6];

		for(int x = 0; x < resolutionX - 1; x++) {
			for(int z = 0; z < resolutionZ - 1; z++) {
				var index = TriangleIndex(x, z) * 6;
				triangles[0 + index] = VertexIndex(0 + x, 0 + z);
				triangles[1 + index] = VertexIndex(0 + x, 1 + z);
				triangles[2 + index] = VertexIndex(1 + x, 1 + z);
				triangles[3 + index] = VertexIndex(0 + x, 0 + z);
				triangles[4 + index] = VertexIndex(1 + x, 1 + z);
				triangles[5 + index] = VertexIndex(1 + x, 0 + z);
			}
		}
		return triangles;
	}

	private Color32 CreateRandomColour(System.Random random) {
		return new Color32((byte) random.Next(0, 255), (byte) random.Next(0, 255), (byte) random.Next(0, 255), 255);
	}

	private int TriangleIndex(int x, int z) {
		return x * (resolutionZ - 1) + z;
	}

	private int VertexIndex(int x, int z) {
		return x * resolutionZ + z;
	}
}
