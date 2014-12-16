using UnityEngine;
using System.Collections;

public class Missile : MonoBehaviour {

    public GameObject CurrentTarget;
    public float Speed;

    public bool HadTarget;

    public bool InPursuit;

    AudioSource missileAudio;

    // Use this for initialization
    void Start()
    {
        //Loads and plays audio on instantiate of a rocket
        missileAudio = GetComponent<AudioSource>();
        AudioSource.PlayClipAtPoint(missileAudio.clip, transform.position);
        Speed = (Speed == 0) ? Speed = 20 : Speed;

    }

    // Update is called once per frame
    void Update()
    {
        //Had true just incase the Update is rabn before CurrentTarget set
        if (HadTarget && CurrentTarget == null)
        {
            Destroy(gameObject);
        }

        if (CurrentTarget != null)
        {
            PursuitPlayer();
            HadTarget = true;
        }
        
    }

    void PursuitPlayer()
    {

        var newRotation = Quaternion.LookRotation(CurrentTarget.transform.position - transform.position).eulerAngles;
        newRotation.z = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(newRotation), 1);

        //If we want to move with updating pos
        transform.position += transform.forward * Speed * Time.deltaTime;
    }

     void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.tag == "Enemy")
         {
             //Calls the method DoDamage on all MonoBehaviours(Scripts) attached to this GameObject
             other.gameObject.SendMessage("DoDamage",3);
             
             //Destroy the Missile
             Destroy(gameObject);
         }
    }

}
