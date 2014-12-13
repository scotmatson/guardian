using UnityEngine;
using System.Collections;

public class StationaryTurret : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
    

	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDrag()
    {

        var newT = transform;
        var x = transform.eulerAngles.x;
        var z = transform.eulerAngles.z;

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(x, 0, z);
            Debug.Log("Up");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) 
        {
            transform.eulerAngles = new Vector3(x, 180, z);
            Debug.Log("Down");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(x, 270, z);
            Debug.Log("Left");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(x, 90, z);
            Debug.Log("Right");
        }

       // Debug.Log(newT.y.ToString());
       // transform = newT;
    }

}
