using UnityEngine;
using System.Collections;

public class ClickablePlane : MonoBehaviour
{
    public Plane thisPlane;

    public bool canAfford;

    private Color _startingColor;

	// Use this for initialization
	void Start ()
	{
	    _startingColor = this.gameObject.renderer.material.color;
	}
	
	// Update is called once per frame
	void Update () {
	 


	}



    void OnMouseEnter()
    {
        

        //Changes Color to Green if can afford tower
        this.gameObject.renderer.material.color = Utils.CanAfford() ? Color.green : Color.red;
    }

    void OnMouseExit()
    {
        //Reset the color
        this.gameObject.renderer.material.color = _startingColor;
    }
}
