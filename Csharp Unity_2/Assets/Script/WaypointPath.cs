using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    public List<Transform> nodes = new List<Transform>();
    public Transform[] pathTransform;

    public Vector3 CurrNode;
    public Vector3 PrevNode;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        pathTransform = GetComponentsInChildren<Transform>();
        if (pathTransform.Length > 0)
        {
            foreach(Transform T in pathTransform)
            {
                if (!nodes.Contains(T) && T != transform)
                {
                    nodes.Add(T);
                }
            }
        }
        if (nodes.Count > 2)
        {
            for(int i= 0; i < nodes.Count; i++)
            {
                CurrNode = nodes[i].position;
                if (i > 0)
                {
                    PrevNode = nodes[i - 1].position;
                }
                else if(i==0 && nodes.Count > 1)
                {
                    PrevNode = nodes[nodes.Count - 1].position;

                }
                Gizmos.DrawLine(PrevNode, CurrNode);
                Gizmos.color = Color.blue;
                Gizmos.DrawCube(CurrNode, Vector3.one);

            }
        }

    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
