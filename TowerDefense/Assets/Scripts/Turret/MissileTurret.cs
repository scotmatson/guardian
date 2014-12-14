using UnityEngine;
using System.Collections;

public class MissileTurret : MonoBehaviour
{


    public GameObject BulletRef;
    public float ShootingFreq;

    public GameObject ParentGameObject;


    private float _nextShot;

    private bool delayShot;

    // Use this for initialization
    void Start()
    {
        //This gets the TwinPrefab Obeject it is Game Objects up
        ParentGameObject = transform.parent.gameObject;

        BulletRef = Resources.Load<GameObject>("Ammo/Missile");


        //Initalize if they are not 
        ShootingFreq = (ShootingFreq == 0) ? 1.0f : ShootingFreq;

        //Delay first shot 
        _nextShot = 0;

        delayShot = true;

    }

    // Update is called once per frame
    void Update()
    {


        if (ParentGameObject.GetComponent<Turret>().HasTarget)
        {

            //Used to delay the turret enough to spin
            if (delayShot)
            {
                delayShot = false;
                return;
            }

            if (Time.time > _nextShot)
            {
                _nextShot = Time.time + ShootingFreq;
                var newMissile = (GameObject) Instantiate(BulletRef, transform.position, transform.rotation);
                newMissile.GetComponent<Missile>().CurrentTarget =
                    ParentGameObject.GetComponent<Turret>()._currentTarget;

            }

        }
        else
        {
            delayShot = true;
        }

    }



}
