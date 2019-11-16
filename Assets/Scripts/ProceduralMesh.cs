using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralMesh : MonoBehaviour
{

	Mesh mesh;
	public int Size;
	int xSize;
	int zSize;
	Vector3[] vertices;
	int[] triangles;
	public Material mat;
	float perlinVal = 0f;
	Vector2[] uvs;
    public float animationFrames = 0.1f;
    public Vector2 redness;
    public Vector2 blueness;
    public Vector2 greenness;


	void Start()
	{
		xSize = Size;
		zSize = Size;
		mesh = new Mesh();
		GetComponent<MeshFilter>().mesh = mesh;
		GetComponent<MeshRenderer>().material = mat;
		StartCoroutine(anim());
	}

	IEnumerator anim()
	{
		CreateShape();
		UpdateMesh();
		SplitMesh();
		SetColors();

		while (true)
		{
			AnimateMesh();
			UpdateMesh();
			yield return new WaitForSeconds(0.01f);
		}
	}

	float offset = 0;

	void AnimateMesh()
	{

		for (int x = 0; x < vertices.Length; x++)
		{
			vertices[x].y = 3 * Mathf.PerlinNoise(vertices[x].x + offset, vertices[x].z + offset);
		}
		offset += animationFrames;

	}

	void SplitMesh()
	{
		int[] tris = mesh.triangles;
		Vector3[] verts = mesh.vertices;
		Vector3[] normals = mesh.normals;
		Vector2[] meshUvs = mesh.uv;

		Vector3[] newVerts;
		Vector3[] newNormals;
		Vector2[] newUvs;

		int n = tris.Length;
		newVerts = new Vector3[n];
		newNormals = new Vector3[n];
		newUvs = new Vector2[n];

		for (int i = 0; i < n; i++)
		{
			newVerts[i] = verts[tris[i]];
			newNormals[i] = normals[tris[i]];
			if (meshUvs.Length > 0)
			{
				newUvs[i] = meshUvs[tris[i]];
			}
			tris[i] = i;
		}
		vertices = newVerts;
		normals = newNormals;
		uvs = newUvs;
		triangles = tris;
	}

	Color[] colors;
	void SetColors()
	{
		colors = new Color[vertices.Length];
		for (int i = 0; i < colors.Length; i += 3)
		{
			Color col = new Color(Random.Range(redness.x, redness.y), Random.Range(greenness.x,greenness.y), Random.Range(blueness.x, blueness.y));
			colors[i] = col;
			colors[i + 1] = col;
			colors[i + 2] = col;
		}
	}

	void CreateShape()
	{
		vertices = new Vector3[(xSize + 1) * (zSize + 1)];
		for (int x = 0, i = 0; i <= xSize; i++)
		{
			for (int j = 0; j <= zSize; j++)
			{
				vertices[x] = new Vector3(j + Random.Range(0, 0.4f), Mathf.PerlinNoise((float)j / (float)zSize, (float)i / (float)xSize), i + Random.Range(0, 0.4f));
				x++;
			}
		}

		int tris = 0;
		int vert = 0;
		triangles = new int[xSize * zSize * 6];

		for (int q = 0; q < zSize; q++)
		{
			for (int i = 0; i < xSize; i++)
			{

				triangles[tris + 0] = vert;
				triangles[tris + 1] = vert + xSize + 1;
				triangles[tris + 2] = vert + 1;
				triangles[tris + 3] = vert + 1;
				triangles[tris + 4] = vert + xSize + 1;
				triangles[tris + 5] = vert + xSize + 2;

				vert++;
				tris += 6;
			}
			vert++;
		}

	}

	void UpdateMesh()
	{
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.colors = colors;
		mesh.RecalculateNormals();

	}

}
