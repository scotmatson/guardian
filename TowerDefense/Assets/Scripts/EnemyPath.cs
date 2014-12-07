using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPath : MonoBehaviour {

    private GameObject wpContainer;
    private Transform[] waypoints;
    private Vector3 currentPosition;
    public float travelSpeed;
    public float rotationalSpeed;
    public int wpNum;

	// Use this for initialization
	void Start () {
        //The travel speed of the game object
        travelSpeed = 5.0f;
        //The rotational speed of game object
        rotationalSpeed = 10.0f;
        //Locate the parent container which holds all of the waypoints
        wpContainer = GameObject.Find("Waypoints");
        //Collects the (x, y, z) position of all waypoints into an Array
        waypoints = wpContainer.GetComponentsInChildren<Transform>();
        //The starting index for waypoints
        wpNum = 2;
    }
	
	// Update is called once per frame
	void Update () {
        var currentPosition = transform.position;
        var nextPosition = waypoints[wpNum].position;
        var rotation = Quaternion.LookRotation(nextPosition - currentPosition);
        if (currentPosition != nextPosition) {
            //Faces enemy towards next waypoint
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationalSpeed);
            //Moves enemy towards next waypoint
            transform.position = Vector3.MoveTowards(currentPosition, nextPosition, travelSpeed * Time.deltaTime);
        }
        if (currentPosition == nextPosition && wpNum < waypoints.Length - 1) {
            ++wpNum;
        }
	}
}

