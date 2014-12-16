using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour {

    //Takes an AudioSource component (Which needs to have an audio clip assigned to it)
    //and a game object which will trigger the audio clip. You should be able to easily place
    //this anywhere in the game to add sound triggers.
    public AudioSource audioSource;
    public GameObject MyGameObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == MyGameObject.tag)
        {
            AudioSource.PlayClipAtPoint(audioSource.clip, MyGameObject.transform.position);
        }
    }
}
