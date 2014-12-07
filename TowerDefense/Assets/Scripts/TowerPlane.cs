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
        this.tower = Utils.TowerFromType(GameState.CurrenTowerType);

        Instantiate(tower, this.transform.position , transform.rotation);

        GameState.Currency -= Utils.TowerCost(GameState.CurrenTowerType);

    }

    void OnMouseDown()
    {
        if (Utils.CanAfford())
        {
            Debug.Log("Build");
            BuildTowerOnPlane();
        }
    }
}
