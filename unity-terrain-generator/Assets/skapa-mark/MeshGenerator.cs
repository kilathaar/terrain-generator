using UnityEngine;

public class MeshGenerator {
	private readonly int resolutionY;

	private Vector3[] vertices;
	private int[] triangles;
	private Color32[] vertexColours;

	public MeshGenerator(int resolutionX, int resolutionY) {
		this.resolutionY = resolutionY;

		vertices = CreateVertices(resolutionX, resolutionY);
		triangles = CreateTriangles(resolutionX, resolutionY);
		vertexColours = CreateColours(resolutionX, resolutionY);
	}

	public Mesh CreatePlane() {
		Mesh mesh = new Mesh();
		mesh.vertices = vertices;
		mesh.colors32 = vertexColours;
		mesh.triangles = triangles;
		mesh.RecalculateNormals();
		return mesh;
	}

	private Vector3[] CreateVertices(int resolutionX, int resolutionY) {
		var vertices = new Vector3[resolutionX * resolutionY];

		for(int x = 0; x < resolutionX; x++) {
			for(int y = 0; y < resolutionY; y++) {
				vertices[VertexIndex(x, y)] = new Vector3(x, y, 0);
			}
		}

		return vertices;
	}

	private Color32[] CreateColours(int resolutionX, int resolutionY) {
		var colours = new Color32[resolutionX * resolutionY];
		var random = new System.Random();

		for(int x = 0; x < resolutionX; x++) {
			for(int y = 0; y < resolutionY; y++) {
				colours[VertexIndex(x, y)] = CreateRandomColour(random);
			}
		}

		return colours;
	}

	private int[] CreateTriangles(int resolutionX, int resolutionY) {
		var numberOfSquares = (resolutionX - 1) * (resolutionY - 1);
		var triangles = new int[numberOfSquares * 6];

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
		return triangles;
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
