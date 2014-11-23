using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour
{



    public bool IsSeleceted;

    public float Speed;

	// Use this for initialization
	void Start () {
	
	}




	// Update is called once per frame
	void Update ()
	{

	    if (IsSeleceted)
	    {
            //Get Right Click
            //http://answers.unity3d.com/questions/213152/move-to-clicked-point.html
	        if (Input.GetMouseButton(1))
	        {
                //This creates a plane to RayCast off of
	            var playerPlane = new Plane(Vector3.up, transform.position);
	            
                //Uses the Camera which has Screen Points to Ray Cast
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	            float hitDist;

	            var targetPostion = new Vector3();

                if (playerPlane.Raycast(ray, out hitDist))
                {
                    //Gets the New Position to move to 
                    var targetPoint = ray.GetPoint(hitDist);
                    targetPostion = ray.GetPoint(hitDist);

                    //Rotation
                    var targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
                    transform.rotation = targetRotation;
                }

                transform.position = Vector3.Lerp(transform.position, targetPostion, Time.deltaTime * Speed);

	        }
	    }
	}




    void OnMouseDown()
    {
        IsSeleceted = true;
    }

}
