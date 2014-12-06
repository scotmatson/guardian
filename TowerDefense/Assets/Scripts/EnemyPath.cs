using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPath : MonoBehaviour {

    private GameObject wpContainer;
    private Transform[] waypoints;
    private Vector3 currentPosition;
    public float speed;
    public int wpNum;

	// Use this for initialization
	void Start () {
        //The current location of this GameObject
        currentPosition = transform.position;
        //The speed of the game object
        speed = 3f;

        //Locate the parent container which holds all of the waypoints
        wpContainer = GameObject.Find("Waypoints");
        //Collects the (x, y, z) position of all waypoints into an Array
        waypoints = wpContainer.GetComponentsInChildren<Transform>();
        //The starting index for waypoints
        wpNum = 2;
    }
	
	// Update is called once per frame
	void Update () {
        var nextPosition = waypoints[wpNum].position;
        if (currentPosition != nextPosition) {
            transform.position = new Vector3(nextPosition.x, nextPosition.y, nextPosition.z);
        }
	}

}

