using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class Robot : MonoBehaviour
{



    public bool IsSeleceted;
    public bool IsMoving;
    public float Speed;

    public bool flip;

    private Vector3 _targetPos;
    private 

	// Use this for initialization
	void Start ()
    {

        Speed = (Speed == 0) ? 3 : Speed;

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
                MoveRobotToClickSpot(Input.mousePosition);
	        }
	    }
	    if (IsMoving)
	    {
	        MoveRobot();
	    }

	}

    //This is called when clicked. It Modifies IsMoving to Be true
    public void MoveRobotToClickSpot(Vector3 mousePos)
    {
        _targetPos = Utils.GetTargetPosition(mousePos);
        if (_targetPos != Vector3.zero)
        {
            IsMoving = true;
            var targetRotation = Quaternion.LookRotation(_targetPos - transform.position);
            transform.rotation = targetRotation;
            transform.position = Vector3.Lerp(transform.position, _targetPos, Time.deltaTime * Speed);
            if (_targetPos == transform.position)
            {
                IsMoving = false;
            }
        }
    }

    void MoveRobot()
    {
        if (_targetPos != Vector3.zero)
        {
            var targetRotation = Quaternion.LookRotation(_targetPos - transform.position);
            transform.rotation = targetRotation;
            transform.position = Vector3.Lerp(transform.position, _targetPos, Time.deltaTime * Speed);
            if (_targetPos == transform.position)
            {
                IsMoving = false;
            }
        }
    }

    void OnMouseDown()
    {
        IsSeleceted = true;
    }

}
