using UnityEngine;

public static class GenerateMesh
{
    public static MeshData GenerateTerrainMesh(float[,] heightMap, float heightMultiplier, AnimationCurve _heightCurve, int levelOfDetail)
    {
        AnimationCurve heightCurve = new AnimationCurve(_heightCurve.keys);

        int meshSimplificationIncrement = (levelOfDetail == 0) ? 1 : levelOfDetail * 2;

        int borderedSize = heightMap.GetLength(0);
        // int borderedSize = heightMap.GetLength(1); //Width and depth are currently the same size
        int meshSize = borderedSize - 2 * meshSimplificationIncrement;
        int unsimplifiedMeshSize = borderedSize - 2;
        float topLeftX = (unsimplifiedMeshSize - 1) / 2f;
        float topLeftZ = (unsimplifiedMeshSize - 1) / -2f;

        int verticesPerLine = (borderedSize - 1) / meshSimplificationIncrement + 1;

        MeshData meshData = new MeshData(verticesPerLine);

        int[,] vertexIndicesMap = new int[borderedSize, borderedSize];
        int meshVertexIndex = 0;
        int borderVertexIndex = -1;

        for (int z = 0; z < borderedSize; z += meshSimplificationIncrement)
        {
            for (int x = 0; x < borderedSize; x += meshSimplificationIncrement)
            {
                bool isBorderVertex = z == 0 || z == borderedSize - 1 || x == 0 || x == borderedSize - 1;

                if (isBorderVertex)
                {
                    vertexIndicesMap[x, z] = borderVertexIndex;
                    borderVertexIndex--;
                }
                else
                {
                    vertexIndicesMap[x, z] = meshVertexIndex;
                    meshVertexIndex++;
                }
            }
        }
        for (int z = 0; z < borderedSize; z += meshSimplificationIncrement)
        {
            for (int x = 0; x < borderedSize; x += meshSimplificationIncrement)
            {
                int vertexIndex = vertexIndicesMap[x, z];
                Vector2 percent = new Vector2((x - meshSimplificationIncrement) / (float)meshSize, (z - meshSimplificationIncrement) / (float)meshSize);
                float height = heightCurve.Evaluate(heightMap[x, z]) * heightMultiplier;
                Vector3 vertexPosition = new Vector3(topLeftX - percent.x * unsimplifiedMeshSize, height, topLeftZ + percent.y * unsimplifiedMeshSize);

                meshData.AddVertex(vertexPosition, percent, vertexIndex);
                if (x < borderedSize - 1 & z < borderedSize - 1)
                {
                    int a = vertexIndicesMap[x, z];
                    int b = vertexIndicesMap[x + meshSimplificationIncrement, z];
                    int c = vertexIndicesMap[x, z + meshSimplificationIncrement];
                    int d = vertexIndicesMap[x + meshSimplificationIncrement, z + meshSimplificationIncrement];
                    //meshData.AddQuad(vertexIndex, vertexIndex+1, vertexIndex+width+1, vertexIndex+width+2);
                    meshData.AddTriangle(a, d, c);
                    meshData.AddTriangle(d, a, b);
                }
            }
        }
        return meshData;
    }
}
public class MeshData
{
    Vector3[] vertices;
    int[] triangles;
    Vector2[] uvs;

    int triangleIndex;
    int borderTriangleIndex;

    Vector3[] borderVertices;
    int[] borderTriangles;

    public MeshData(int verticesPerLine)
    {
        vertices = new Vector3[verticesPerLine * verticesPerLine];
        uvs = new Vector2[vertices.Length];
        triangles = new int[(verticesPerLine - 1) * (verticesPerLine - 1) * 6];

        borderVertices = new Vector3[verticesPerLine * 4 + 4];
        borderTriangles = new int[24 * verticesPerLine];
    }
    public void AddVertex(Vector3 vertexPosition, Vector2 uv, int vertexIndex)
    {
        if (vertexIndex < 0)
        {
            borderVertices[-vertexIndex - 1] = vertexPosition;
        }
        else
        {
            vertices[vertexIndex] = vertexPosition;
            uvs[vertexIndex] = uv;
        }
    }
    /*public void AddQuad(int v00, int v10, int v01,int v11)
    {
        triangles[i] = v00;
        triangles[i + 1] = triangles[i + 4] = v01;
        triangles[i + 2] = triangles[i + 3] = v10;
        triangles[i + 5] = v11;

        i += 6;
    }*/
    public void AddTriangle(int a, int b, int c)
    {
        if (a < 0 || b < 0 || c < 0)
        {
            borderTriangles[borderTriangleIndex] = a;
            borderTriangles[borderTriangleIndex + 1] = b;
            borderTriangles[borderTriangleIndex + 2] = c;
            triangleIndex += 3;
        }
        else
        {
            triangles[triangleIndex] = a;
            triangles[triangleIndex + 1] = b;
            triangles[triangleIndex + 2] = c;
            triangleIndex += 3;
        }
    }
    Vector3[] CalculateNormals()
    {
        Vector3[] vertexNormals = new Vector3[vertices.Length];
        int triangleCount = triangles.Length / 3;
        for (int i = 0; i < triangleCount; i++)
        {
            int normalTriangleIndex = i * 3;
            int vertexIndexA = triangles[normalTriangleIndex];
            int vertexIndexB = triangles[normalTriangleIndex + 1];
            int vertexIndexC = triangles[normalTriangleIndex + 2];

            Vector3 triangleNormal = SurfaceNormalFromIndices(vertexIndexA, vertexIndexB, vertexIndexC);
            vertexNormals[vertexIndexA] += triangleNormal;
            vertexNormals[vertexIndexB] += triangleNormal;
            vertexNormals[vertexIndexC] += triangleNormal;
        }

        int borderTriangleCount = borderTriangles.Length / 3;
        for (int i = 0; i < borderTriangleCount; i++)
        {
            int normalTriangleIndex = i * 3;
            int vertexIndexA = borderTriangles[normalTriangleIndex];
            int vertexIndexB = borderTriangles[normalTriangleIndex + 1];
            int vertexIndexC = borderTriangles[normalTriangleIndex + 2];

            Vector3 triangleNormal = SurfaceNormalFromIndices(vertexIndexA, vertexIndexB, vertexIndexC);
            if (vertexIndexA >= 0)
            {
                vertexNormals[vertexIndexA] += triangleNormal;
            }
            if (vertexIndexB >= 0)
            {
                vertexNormals[vertexIndexB] += triangleNormal;
            }
            if (vertexIndexC >= 0)
            {
                vertexNormals[vertexIndexC] += triangleNormal;
            }
        }
        for (int i = 0; i < vertexNormals.Length; i++)
        {
            vertexNormals[i].Normalize();
        }
        return vertexNormals;
    }

    Vector3 SurfaceNormalFromIndices(int indexA, int indexB, int indexC)
    {

        Vector3 pointA = (indexA < 0) ? borderVertices[-indexA - 1] : vertices[indexA];
        Vector3 pointB = (indexB < 0) ? borderVertices[-indexB - 1] : vertices[indexB];
        Vector3 pointC = (indexC < 0) ? borderVertices[-indexC - 1] : vertices[indexC];

        Vector3 sideAB = pointB - pointA;
        Vector3 sideAC = pointC - pointA;

        return Vector3.Cross(sideAB, sideAC).normalized;
    }

    public Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.normals = CalculateNormals();
        return mesh;
    }
    private void OnDrawGizmos()
    {
        if (vertices == null)
        {
            return;
        }
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawSphere(vertices[i], 0.1f);

        }
    }
}

