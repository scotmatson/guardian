using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Collections;

public class GUI : MonoBehaviour {

	// Use this for initialization

    public GameObject turret1;
    public GameObject turret2;

    public Texture2D turret1texture;
    public Texture2D turret2Texture;

    public Rect Turret2Rect;

    public Rect Turret1Rect;


    void Start ()
    {

        //foo.renderer.material.color = Color.red;

        turret1texture = AssetPreview.GetAssetPreview(turret1);

        turret2Texture = AssetPreview.GetAssetPreview(turret2);

        //te = AssetPreview.GetMiniThumbnail(foo);
        //this.guiTexture.texture = turret1texture;


       // var byt = turret1texture.EncodeToPNG();

        //File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", byt);

        var x = 10;
        var y =  Screen.height  - 110;


        Turret1Rect = new Rect(x,y, 100, 100);
        Turret2Rect = new Rect(x + 100, y, 100, 100);


    }
	
	// Update is called once per frame
	void Update () {
	
	}



    void OnGUI()
    {
       
        UnityEngine.GUI.DrawTexture(Turret1Rect, turret1texture); //ScaleMode.ScaleToFit,true, 10.0f);

        UnityEngine.GUI.DrawTexture(Turret2Rect,turret2Texture);


        if ( Input.GetMouseButton(0))
        {
            Debug.Log(Turret1Rect.Contains(Input.mousePosition));
            if (Turret1Rect.Contains(Input.mousePosition))
            {
                Debug.Log("Turret 1 clicked");
            }
            if (Turret2Rect.Contains(Input.mousePosition))
            {
                Debug.Log("Turret 2 clicked");
            }
            Debug.Log(Input.mousePosition.ToString());
        }

        //TurretSelector = UnityEngine.GUI.Window(0, TurretSelector, PauseMenu, "");
    }


    void PauseMenu(int windowID)
    {
        GUILayout.BeginVertical();

        

       // GUILayout.Label("Paused");

/*        if (GUILayout.Button("Unpause"))
        {
          //  UnPause();
        }

        if (GUILayout.Button("Restart Level"))
        {
          //  UnPause();
            //Sets the Scene to Current Level Index
           // ResetConfigLevel();
           // RestartLevel();
        }

        if (GUILayout.Button("Main Menu"))
        {
         //   UnPause();
            //Go to the Main Menu
         //   MainMenu();
        }*/

        GUILayout.Space(8);
        GUILayout.EndVertical();
        //GUI.DragWindow(new Rect(0, 0, 10000, 10000));

    }


}
