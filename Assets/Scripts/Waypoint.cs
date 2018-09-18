using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    public bool isExplored = false;
    const int gridSize = 1;
    public Waypoint exploredFrom;

    Vector2Int gridPos;


    public int GetGridSize()
    {
        return gridSize;
    }

    public void SetTopColor(Color color)
    {
        var startColor = transform.Find("Top").GetComponent<MeshRenderer>();
        startColor.material.color = color;

    }


    public Vector2Int GetGridPos()
    {
        return new Vector2Int(Mathf.RoundToInt(transform.position.x / gridSize),
                              Mathf.RoundToInt(transform.position.z / gridSize));
    }
}
