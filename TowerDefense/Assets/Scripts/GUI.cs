using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Collections;

public class GUI : MonoBehaviour
{
    public bool TurretMenu;

    public bool GamePaused;

    public Texture2D turret1texture2D;
    public Texture2D turret2Texture2D;
    public Texture2D Turret3Texture2D;
    
    public Rect Turret1Rect;
    public Rect Turret2Rect;
    public Rect Turret3Rect;

    private Rect _pauseMenuRect;

    public Rect TurretBoarder;


    public Rect ActiveTurret;
    public Texture2D ActiveTurretTexture2D;

    void Start ()
    {
        //Just to be safe 
        GamePaused = false;
        TurretMenu = false;

        //Fixed in the corner can move
        ActiveTurret = new Rect(10,Screen.height - 110 ,100,100);
        
        //Default Turret
        ActiveTurretTexture2D = turret1texture2D; 

        var x = (Screen.width / 2) - (400 / 2);
        var y =  (Screen.height / 2) - (110 / 2);
        Turret1Rect = new Rect(x,y, 100, 100);       
        
        Turret2Rect = new Rect(x + 100, y, 100, 100);

        Turret3Rect = new Rect(x + 200, y ,100, 100);

        TurretBoarder = new Rect(x - 5, y - 10, 400,110);


        const float pauseWidth = 350f;
        const float pauseHeight = 500f;

        var pauseX = (Screen.width/2) - (pauseWidth/2);
        var pauseY = (Screen.height/2) - (pauseHeight/2);

        _pauseMenuRect = new Rect(pauseX,pauseY,pauseWidth,pauseHeight);


    }
	
	// Update is called once per frame
	void Update () {


        //T Will Toggle Turret Menu
	    if (Input.GetKeyDown(KeyCode.T))
	    {
	        TurretMenu = !TurretMenu;
	    }


	    if (!GamePaused)
	    {
	        GamePaused = Input.GetKeyDown(KeyCode.Escape);
	    }
	    if (GamePaused)
	    {
	        Pausegame();
	    }

	}



    void OnGUI()
    {


        if (GamePaused)
        {
            _pauseMenuRect = UnityEngine.GUI.Window(2, _pauseMenuRect, PauseMenu, "");
        }

        //Active Turret
        UnityEngine.GUI.DrawTexture(ActiveTurret,ActiveTurretTexture2D);

        if (TurretMenu)
        {
            //Turret Menu stuff
            UnityEngine.GUI.DrawTexture(Turret1Rect, turret1texture2D);

            UnityEngine.GUI.DrawTexture(Turret2Rect, turret2Texture2D);

            UnityEngine.GUI.DrawTexture(Turret3Rect, Turret3Texture2D);

            UnityEngine.GUI.Box(TurretBoarder, ""); 

            SelectTurret();
        }
       

    

        //TurretSelector = UnityEngine.GUI.Window(0, TurretSelector, PauseMenu, "");
    }


    public void SelectTurret()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Stupid Unity Making me do stupid offset
            var clickedOnScreen = Input.mousePosition;
            clickedOnScreen.y = Screen.height - clickedOnScreen.y;

            if (Turret1Rect.Contains(clickedOnScreen))
            {
                ActiveTurretTexture2D = turret1texture2D;
            }
            if (Turret2Rect.Contains(clickedOnScreen))
            {
                ActiveTurretTexture2D = turret2Texture2D;
            }
            if (Turret3Rect.Contains(clickedOnScreen))
            {
                ActiveTurretTexture2D = Turret3Texture2D;
            }
        }
    }


    void Pausegame()
    {
        Time.timeScale = 0;
    }

    void UnPause()
    {
        Time.timeScale = 1;
        GamePaused = false;
    }


    void PauseMenu(int windowID)
    {
        GUILayout.BeginVertical();

        

        GUILayout.Label("Paused");

        if (GUILayout.Button("Unpause"))
        {
            UnPause();
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
        }

     //   GUILayout.Space(8);
        GUILayout.EndVertical();
        //GUI.DragWindow(new Rect(0, 0, 10000, 10000));

    }


}
