using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{

    //
    public GameObject _currentTarget;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        RotateTowardsObject(_currentTarget);


	}

    /// <summary>
    /// Finds the closet Gameobject
    /// </summary>
    void GetClosetEnemy()
    {
        var enemyList = GameObject.FindGameObjectsWithTag("Enemy");

        foreach(var enemy in enemyList)
        {
            
        }

    }

    //Rotates the Turret Towads a target 
    void RotateTowardsObject(GameObject target)
    {
        var targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
        transform.rotation = targetRotation;
    }

}
