using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();
    Waypoint searchCenter;

    bool isRunning = true;

    Vector2Int[] directions =
    {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };

	// Use this for initialization
	void Start ()
    {
        LoadBlocks();
        ColorStartAndEnd();
       // ExploreNeighbours();
        Pathfind();
    }

    private void LoadBlocks()
    {
        var waypoints = FindObjectsOfType<Waypoint>();
        foreach(Waypoint waypoint in waypoints)
        {
         grid.ContainsKey(waypoint.GetGridPos());
         var gridPos = grid.ContainsKey(waypoint.GetGridPos());
            bool isOverlapping = gridPos;

            if (isOverlapping)
            {
                Debug.LogWarning("Skipping overlapping block" + waypoint);
            }
            else
            {
                grid.Add(waypoint.GetGridPos(), waypoint);
            }
         }
    }    

    private void ExploreNeighbours()
    {
        if (!isRunning) { return; }

        foreach(Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = searchCenter.GetGridPos() + direction;
            try
            {
                QueueNewNeighbours(explorationCoordinates);
            }
            catch { }
        }
    }

    private void QueueNewNeighbours(Vector2Int explorationCoordinates)
    {
        Waypoint neighbour = grid[explorationCoordinates];
        if (neighbour.isExplored || queue.Contains(neighbour)) { }
        else { 
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
        } 
    }

    private void ColorStartAndEnd()
    {
        startWaypoint.SetTopColor(Color.green);
        endWaypoint.SetTopColor(Color.red);
    }

    private void Pathfind()
    {
        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            HaltIfEnd();
            ExploreNeighbours();
            searchCenter.isExplored = true;  
        }
        print("done searching?");
    }

    private void HaltIfEnd()
    {
        if (searchCenter == endWaypoint)
        {
            print("Search stopped because current waypoint is the end point");//TODO remove log
            isRunning = false;            
        }
    }



}
