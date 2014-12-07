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
        //The speed of the game object
        speed = 5.0f;

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
        if (currentPosition != nextPosition) {
            transform.position = Vector3.MoveTowards(currentPosition, nextPosition, speed * Time.deltaTime);
            //transform.position = new Vector3(nextPosition.x, nextPosition.y, nextPosition.z);
            //transform.Translate((waypoints[wpNum].position - currentPosition) * Time.deltaTime * speed);
            //if (currentPosition == nextPosition)
                //++wpNum;
        }
        if (currentPosition == nextPosition && wpNum < waypoints.Length - 1) {
            ++wpNum;
        }
        
	}
}

