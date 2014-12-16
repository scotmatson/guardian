using UnityEngine;
using System.Collections;

public class SpeedMod : MonoBehaviour {

    public float width  = 0.2f;
    public float height = 0.2f;
    public float depth  = 0.2f;

    EnemyPath pathScript;
    public bool accelerate = false;
    public float speedMultiplier = 0f;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position, new Vector3(width, height, depth));
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Enemy")
        {
            pathScript = other.GetComponent<EnemyPath>();
            if (accelerate)
            {
                pathScript.travelSpeed *= speedMultiplier;
            }
            else
            {
                pathScript.travelSpeed /= speedMultiplier;
            }
        }
    }

}

