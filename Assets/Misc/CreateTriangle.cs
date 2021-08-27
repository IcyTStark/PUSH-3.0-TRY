using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTriangle : MonoBehaviour
{
    public Material cubeMaterial;
    
    void CreateTrian()
    {
        Mesh mesh = new Mesh();
        mesh.name = "ScriptedTriangle";

        Vector3[] vertices = new Vector3[3];
        Vector3[] normals = new Vector3[3];
        //Vector2[] uvs = new Vector2[4];
        int[] triangles = new int[6];

        //all possible UVs
        Vector2 uv00 = new Vector2(0f, 0f);
        Vector2 uv10 = new Vector2(1f, 0f);
        Vector2 uv01 = new Vector2(0f, 1f);
        Vector2 uv11 = new Vector2(1f, 1f);

        //all possible vertices
        Vector3 p0 = new Vector3(0f, 0f, 0f);
        Vector3 p1 = new Vector3(1f, 0f, 0f);
        Vector3 p2 = new Vector3(0f, 1f, 0f);
        //Vector3 p3 = new Vector3(-0.5f, -0.5f, -0.5f);
        //Vector3 p4 = new Vector3(-0.5f, 0.5f, 0.5f);
        //Vector3 p5 = new Vector3(0.5f, 0.5f, 0.5f);
        //Vector3 p6 = new Vector3(0.5f, 0.5f, -0.5f);
        //Vector3 p7 = new Vector3(-0.5f, 0.5f, -0.5f);

        
        vertices = new Vector3[] { p0, p1, p2};
        normals = new Vector3[] { Vector3.forward, Vector3.forward, Vector3.forward};
        //uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
        triangles = new int[] {0,1,2};



        mesh.vertices = vertices;
        mesh.normals = normals;
        //mesh.uv = uvs;
        mesh.triangles = triangles;

        mesh.RecalculateBounds();
        GameObject Triangle = new GameObject("Triangle");
        Triangle.transform.parent = this.gameObject.transform;
        MeshFilter meshfilter = Triangle.AddComponent(typeof(MeshFilter)) as MeshFilter;
        meshfilter.mesh = mesh;
        MeshRenderer renderer = Triangle.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
        renderer.material.color = Color.red;

    }

    

    void Start()
    {
        CreateTrian();
    }
}

