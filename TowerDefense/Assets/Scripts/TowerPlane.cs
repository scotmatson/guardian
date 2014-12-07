using UnityEngine;
using System.Collections;

public class TowerPlane : MonoBehaviour
{


    public Plane thisPlane;

    public bool hasTower;
    public GameObject tower;

	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void BuildTowerOnPlane()
    {
        this.tower = Utils.TowerFromType(Utils.TowerType.DoubleTurret);

        Instantiate(tower, this.transform.position , transform.rotation);
    }

    void OnMouseDown()
    {
        Debug.Log("Build");
        BuildTowerOnPlane();
    }
}
