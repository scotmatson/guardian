﻿using UnityEngine;
using System.Collections;

public class EnemyState : MonoBehaviour
{

    public int  Health;
    public GameObject MyGameObject;
    AudioSource shipExplode;

	// Use this for initialization
	void Start ()
	{
        shipExplode = GetComponent<AudioSource>();
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
            //Gives 50 Credit
            GameState.Currency += 25;

            //
            GameState.Score += 50;

            Instantiate(MyGameObject, gameObject.transform.position, gameObject.transform.rotation);
            AudioSource.PlayClipAtPoint(shipExplode.clip, transform.position);
            Destroy(gameObject);
        }

    }

}
