﻿using UnityEngine;
using System.Collections;

public class EnemyState : MonoBehaviour
{

    public int  Health;
    public GameObject MyGameObject;

	// Use this for initialization
	void Start ()
	{

	    Health = (Health == 0) ? 5 : Health;

	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void DoDamage(int damage)
    {
        Health -=  damage;

        if (Health <= 0)
        {
            Instantiate(MyGameObject, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }

    }

}
