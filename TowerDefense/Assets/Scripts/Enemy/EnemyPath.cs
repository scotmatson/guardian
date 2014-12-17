using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPath : MonoBehaviour {

    private GameObject wpContainer;
    private Transform[] waypoints;
    private Vector3 currentPosition;

    public Vector3 predictedPos;

    //The travel speed of the game object
    public float travelSpeed = 1.0f;
    //The rotational speed of game object
    public float rotationalSpeed = 10.0f;
    //The starting index for waypoints
    public int wpNum = 1;
    public string path = "Waypoints";

	// Use this for initialization
	void Start () {
        //Locate the parent container which holds all of the waypoints
        wpContainer = GameObject.Find(path);
        //Collects the (x, y, z) position of all waypoints into an Array
        waypoints = wpContainer.GetComponentsInChildren<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
        var currentPosition = transform.position;
        var nextPosition = waypoints[wpNum].position;
        var rotation = Quaternion.Euler(Vector3.zero);
        if ((currentPosition - nextPosition) != Vector3.zero)
        {
            rotation = Quaternion.LookRotation(nextPosition - currentPosition);
        }
        if (currentPosition != nextPosition) {
            //Faces enemy towards next waypoint
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationalSpeed);
            //Moves enemy towards next waypoint
            transform.position = Vector3.MoveTowards(currentPosition, nextPosition, travelSpeed * Time.deltaTime);

            //Position 1 second later
            predictedPos = Vector3.MoveTowards(currentPosition, nextPosition, travelSpeed*Time.deltaTime + 2f);

        }
        if (currentPosition == nextPosition && wpNum < waypoints.Length - 1) {
            ++wpNum;
        }
	}
}

