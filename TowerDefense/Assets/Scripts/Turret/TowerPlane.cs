using UnityEngine;
using System.Collections;

public class TowerPlane : MonoBehaviour
{

    

    public bool HasTower;
    //THe instance of the Turret Prefab OK to Destroy 
    public GameObject InstanceOfPrefab;
    public bool PromptDelete;

    private Color _startingColor;
    private Utils.TowerType _currentType;
    private Rect _deleteConfirmRect;
    private Rect _deleteConfirmYesRect;
    private Rect _deleteConfirmNoRect;

    // This represents the physical Asset loaded dont destroy !
    private GameObject _tower;


	// Use this for initialization
	void Start () {

        _startingColor = this.gameObject.renderer.material.color;
	    PromptDelete = false;

        //Make the Rectangles for Prompt
        const float promptWidth = 200f;
        const float promptHeight = 100f;
	    const float buttonWidth = 70;
	    const float buttonHeight = 70;

        var x = (Screen.width / 2) - (promptWidth / 2);
        var y = (Screen.height / 2) - (promptHeight / 2);

        _deleteConfirmRect = new Rect(x, y, promptWidth, promptHeight);
        _deleteConfirmYesRect = new Rect(x + 25f, y + 20 , buttonWidth, buttonHeight  );
        _deleteConfirmNoRect = new Rect(x + 100f, y + 20,buttonWidth,buttonHeight);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void BuildTowerOnPlane()
    {
        //Gets the current type that will be built
        _currentType = GameState.CurrentTowerType;

        this._tower = Utils.TowerFromType(_currentType);

        //Creates an Instance of the _tower which is an asset. Cast it to GameObject from Object
        InstanceOfPrefab = (GameObject) Instantiate(_tower, this.transform.position , transform.rotation);

        GameState.Currency -= Utils.TowerCost(_currentType);
    }

    //Deletes tower from plane and refunds money
    void RecycleTower()
    {
        //
        Destroy(InstanceOfPrefab);

        //No Longer has tower
        HasTower = false;

        GameState.Currency += Utils.TowerCost(_currentType) / 2;
    }

    void OnMouseOver()
    {
        //Left Click
        if (Input.GetMouseButton(0))
        {
            //Can Afford and there is no previous tower
            if (Utils.CanAfford() && !HasTower)
            {
                //Debug.Log("Build");
                BuildTowerOnPlane();
                HasTower = true;
            }
        }
        //Right Click
        if (Input.GetMouseButtonDown(1))
        {
            // If there is a tower
            if (HasTower)
            {
                PromptDelete = true;
            }
        }
    }

    void OnGUI()
    {
        if (PromptDelete)
        {
            Debug.Log("Prompt Delete");

            var creditBack = Utils.TowerCost(_currentType) / 2;

            //
            UnityEngine.GUI.Box(_deleteConfirmRect, "Delete for " + creditBack + " credit back?");

            //If Yes Clicked Recyle
            if (UnityEngine.GUI.Button(_deleteConfirmYesRect, "Yes"))
            {
                RecycleTower();

                //CLose the prompt
                PromptDelete = false;
            }

            //If No is Clicked Set Prompt show to false esentially cloeing this prompt
            if (UnityEngine.GUI.Button(_deleteConfirmNoRect, "No"))
            {
                //
                PromptDelete = false;
            }
        }
    }

    //Mouse Hover over Object
    void OnMouseEnter()
    {
        //Highlights on if there is no Tower
        if (!HasTower)
        {
            //Changes Color to Green if can afford tower
            this.gameObject.renderer.material.color = Utils.CanAfford() ? Color.green : Color.red;
        }
    }

    //Mouse Stops hovering over object
    void OnMouseExit()
    {
        //Reset the color
        this.gameObject.renderer.material.color = _startingColor;
    }
}
