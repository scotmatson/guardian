using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;
using GUI = UnityEngine.GUI;

public class MainMenu : MonoBehaviour
{
    public GUISkin mySkin;

    public int SelectedLevel;

    public Rect mainWindowRect;

    public Texture2D myT;

    public Rect TitleRect;



	// Use this for initialization
	void Start ()
	{
	    SelectedLevel = (SelectedLevel == 1) ? 1 : SelectedLevel;

	    const float mainWindowwidth = 750f;
	    const float mainWindowheight = 510f;

	    var mainX = (Screen.width/2) - (mainWindowwidth/2);
	    var mainY = (Screen.height/2) - (mainWindowheight/2);

        mainWindowRect = new Rect(mainX,mainY,mainWindowwidth,mainWindowheight);

        TitleRect  = new Rect(50, -100, 700, 1000);

	}
	
    void OnGUI()
    {
        GUI.skin = null;//mySkin;
        mainWindowRect = UnityEngine.GUI.Window(GUI_IDs.MainMenu, mainWindowRect, MainMenuBuilder, "");
    }

    void PlayGame()
    {
        Application.LoadLevel(SelectedLevel);
    }

 

    //This function is used to build the stuff in the main menu
    void MainMenuBuilder(int windowID)
    {
     
        GUILayout.BeginVertical();
        GUILayout.Space(8);
        //GUILayout.Label("","Divder");

      
        //GUI.Label(labelPos,"Defend!",mySkin.FindStyle("Label"));
        GUI.DrawTexture(TitleRect,myT);


       // GUILayout.Label("","Divider");

        var playPos = new Rect(175, 200, 400, 75);
        var play = GUI.Button(playPos, "Play Game",mySkin.FindStyle("Button"));

        var pos = new Rect {y = 300, height = 50, width = 200};

        //Level 1
        pos.x = 60;
        if (GUI.Button(pos, "Deep Space", mySkin.FindStyle("Button")))
        {
            SelectedLevel = 1;
        }

        //Level 2
        pos.x = 280;
        if (GUI.Button(pos, "Crossing Streams", mySkin.FindStyle("Button")))
        {
            SelectedLevel = 2;
        }

        //Level 3
        pos.x = 500;
        if (GUI.Button(pos, "Map 3", mySkin.FindStyle("Button")))
        {
            SelectedLevel = 3;
        }

        //Quit Game
        var quitPos = new Rect(175, 375, 400, 75);

        if (GUI.Button(quitPos, "Exit", mySkin.FindStyle("Button")))
        {
            Application.Quit();
        }

        if (play)
        {
            PlayGame();
        }
        
        GUILayout.EndVertical();
    }



}
