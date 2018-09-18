using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour {
    [SerializeField] Waypoint startWaypoint, endWaypoint;

    Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint>();
    Queue<Waypoint> queue = new Queue<Waypoint>();

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

    private void ExploreNeighbours(Waypoint from)
    {
        if (!isRunning) { return; }

        foreach(Vector2Int direction in directions)
        {
            Vector2Int explorationCoordinates = from.GetGridPos() + direction;
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
        if (neighbour.isExplored) { }
        else { 
            neighbour.SetTopColor(Color.blue);
            queue.Enqueue(neighbour);
            print("Queueing" + neighbour);
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
            var searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            HaltIfEnd(searchCenter);
            ExploreNeighbours(searchCenter);
            searchCenter.isExplored = true;  
        }
        print("done searching?");
    }

    private void HaltIfEnd(Waypoint searchCenter)
    {
        if (searchCenter == endWaypoint)
        {
            print("Search stopped because current waypoint is the end point");//TODO remove log
            isRunning = false;            
        }
    }



}
