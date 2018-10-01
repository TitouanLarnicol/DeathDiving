﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper{
	public static GameObject CreatePlane(float width,float height){
		GameObject plane = new GameObject("landingPlane");
		MeshFilter mf = plane.AddComponent(typeof(MeshFilter)) as MeshFilter;
		MeshRenderer mr = plane.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
		Mesh m = new Mesh();
		m.vertices = new Vector3[]{
			new Vector3(0,0,0),
			new Vector3(width,0,0),
			new Vector3(width,height,0),
			new Vector3(0,height,0)
		};
		m.uv = new Vector2[]{
			new Vector2(0,0),
			new Vector2(0,1),
			new Vector2(1,1),
			new Vector2(1,0)
		};
		m.triangles = new int[]{0,1,2,0,2,3};
		mf.mesh = m;
		m.RecalculateBounds();
		m.RecalculateNormals();
		plane.transform.eulerAngles = new Vector3(90,0,0);
		return plane;
	}
}
