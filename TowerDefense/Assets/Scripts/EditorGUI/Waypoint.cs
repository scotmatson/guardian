using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {

    public float width  = 0.2f;
    public float height = 0.2f;
    public float depth  = 0.2f;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, new Vector3(width, height, depth));
    }
}
