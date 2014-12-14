using System.Linq;
using UnityEditor;
using UnityEngine;
using System.Collections;
using Debug = System.Diagnostics.Debug;

public class Turret : MonoBehaviour
{

    //
    public GameObject _currentTarget;

    public bool HasTarget;


	// Use this for initialization
	void Start ()
	{
	    HasTarget = false;
	}
	
	// Update is called once per frame
	void Update ()
	{

	    if (_currentTarget != null && IsCloseEnough())
	    {
	        RotateTowardsObject(_currentTarget);
	    }
	    else
	    {
            GetClosetEnemy();
	    }

	}

    bool IsCloseEnough()
    {
        return Vector3.Distance(transform.position, _currentTarget.transform.position) <= 20;
    }

    /// <summary>
    /// Finds the closet Gameobject
    /// </summary>
    private void GetClosetEnemy()
    {

        //Gets Array of Enemies within range
        Collider[] hitColliders = Physics.OverlapSphere(transform.position,10);

        //Returns if nothing is close by
        if (hitColliders.Length <= 0) return;

        Collider close = null;
        var closeDist = transform.localScale.x*5;
        foreach (var hitCollider in hitColliders.Where(hitCollider => Vector3.Distance(hitCollider.transform.position,transform.position) < closeDist).Where(hitCollider => hitCollider.tag == "Enemy"))
        {
            close = hitCollider;
        }

        if (close != null)
        {
            _currentTarget = close.gameObject;
            HasTarget = true;
        }
        else
        {
            HasTarget = false;
        }
    }

    //Rotates the Turret Towads a target 
    void RotateTowardsObject(GameObject target)
    {
        var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = targetRotation;
    }

}
