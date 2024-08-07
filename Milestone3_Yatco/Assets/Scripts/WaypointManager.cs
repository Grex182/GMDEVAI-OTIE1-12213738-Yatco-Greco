using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Link
{
    public enum Direction { UNI, BI };
    public GameObject node1;
    public GameObject node2;
    public Direction dir;
}

public class WaypointManager : MonoBehaviour
{
    public GameObject[] waypoints;
    public Link[] links;
    public Graph graph = new Graph();

    // Start is called before the first frame update
    void Start()
    {
        if (waypoints.Length > 0)
        {
            foreach (GameObject wp in waypoints)
            {
                graph.AddNode(wp);
            }

            foreach (Link link in links)
            {
                graph.AddEdge(link.node1, link.node2);
                if (link.dir == Link.Direction.BI)
                {
                    graph.AddEdge(link.node2, link.node1);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        graph.debugDraw();
    }
}