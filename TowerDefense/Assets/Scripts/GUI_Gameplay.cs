using UnityEngine;
using System.Collections;

public class GUI_Gameplay : MonoBehaviour
{

    public GUISkin skin;

    public bool TurretMenu;
    public bool GamePaused;
    public static bool GameIsOver = false;


    public Rect _hudDisplay;


    private Texture2D _turret1texture2D;
    private Texture2D _turret2Texture2D;
    //public Texture2D Turret3Texture2D;
    
    public Rect Turret1Rect;
    public Rect Turret2Rect;
    public Rect Turret3Rect;
    private Rect _pauseMenuRect;
    public Rect TurretBoarder;

    public Rect ActiveTurret;
    public Texture2D ActiveTurretTexture2D;

    private float SliderValue;
    private float prevSpeed;


    void Awake()
    {
        
    }

    void Start ()
    {
        //Just to be safe 
        GamePaused = false;
        TurretMenu = false;

        //Fixed in the corner can move
        ActiveTurret = new Rect(10,Screen.height - 110 ,100,100);


        _turret1texture2D = Utils.TurreTexture2DFromType(Utils.TowerType.DoubleTurret);
        _turret2Texture2D = Utils.TurreTexture2DFromType(Utils.TowerType.Missile);


        //Default Turret
        ActiveTurretTexture2D = _turret1texture2D; 

        var x = (Screen.width / 2) - (400 / 2);
        var y =  (Screen.height / 2) - (110 / 2);
        
        Turret1Rect = new Rect(x,y, 100, 100);       
        Turret2Rect = new Rect(x + 100, y, 100, 100);
        //Turret3Rect = new Rect(x + 200, y ,100, 100);
        TurretBoarder = new Rect(x - 5, y - 10, 200,110);

        const float pauseWidth = 350f;
        const float pauseHeight = 500f;

        var pauseX = (Screen.width/2) - (pauseWidth/2);
        var pauseY = (Screen.height/2) - (pauseHeight/2);

        _pauseMenuRect = new Rect(pauseX,pauseY,pauseWidth,pauseHeight);



        var hud_x = 10F;
        var hud_y = 10F;
        var hudHeight = 180F;
        var hudWidth = 110;

        _hudDisplay = new Rect(hud_x, hud_y, hudWidth, hudHeight);


        SliderValue = 1.0f;
        prevSpeed = SliderValue;

    }

	
	// Update is called once per frame
	void Update () {
        //'t' Will Toggle Turret Menu
	/*    if (Input.GetKeyDown(KeyCode.T)) {
	        TurretMenu = !TurretMenu;
            Pausegame();
	    }
        else if (Input.GetMouseButtonDown(0))
        {
            //Clicking on the Active Turret will Toggle Turret Menu too
            if (CurrentTurretClicked())
            {
                TurretMenu = !TurretMenu;
                Pausegame();
            }
        }*/

        //TOggle the Turrts now

	    if (Input.GetMouseButtonDown(0))
	    {
	        if (CurrentTurretClicked())
	        {
	            if (GameState.CurrentTowerType == Utils.TowerType.DoubleTurret)
	            {
	                GameState.CurrentTowerType = Utils.TowerType.Missile;
	                ActiveTurretTexture2D = _turret2Texture2D;
	            }
	            else
	            {
	                GameState.CurrentTowerType = Utils.TowerType.DoubleTurret;
                    ActiveTurretTexture2D = _turret1texture2D;
	            }
	        }
	    }


	    if (!GamePaused) {
	        GamePaused = Input.GetKeyDown(KeyCode.Escape);
	    }
	    if (GamePaused) {
	        Pausegame();
	    }
	}

    bool CurrentTurretClicked()
    {
        var clickedOnScreen = Input.mousePosition;
        clickedOnScreen.y = Screen.height - clickedOnScreen.y;
        
        //Pauses Game makes it easier to select

        return ActiveTurret.Contains(clickedOnScreen);
    }

    void OnGUI()
    {


        //This Stops from drawing on Main Menu
        if ( Application.loadedLevel == 0) return;
        ;

        GUI.skin = skin;

        RenderHUD();

        if (GameIsOver)
        {
            //Using _Pause menu becasue it doesnt matter just needs a Rect
            _pauseMenuRect = GUI.Window(GUI_IDs.GameOver,_pauseMenuRect, GameOver, "");
        }

        if (GamePaused) {
            _pauseMenuRect = UnityEngine.GUI.Window(GUI_IDs.Paused , _pauseMenuRect, PauseMenu, "");
        }

       


        //Active Turret
        UnityEngine.GUI.DrawTexture(ActiveTurret,ActiveTurretTexture2D);

        if (TurretMenu)
        {
            GUI.skin = null;
            //Turret Menu stuff
            UnityEngine.GUI.DrawTexture(Turret1Rect, _turret1texture2D);
            UnityEngine.GUI.DrawTexture(Turret2Rect, _turret2Texture2D);
       //     UnityEngine.GUI.DrawTexture(Turret3Rect, Turret3Texture2D);
            UnityEngine.GUI.Box(TurretBoarder, ""); 
            SelectTurret();
        }
        //TurretSelector = UnityEngine.GUI.Window(0, TurretSelector, PauseMenu, "");
    }

    void SelectTurret() {
        if (Input.GetMouseButtonDown(0)) {
            //Stupid Unity Making me do stupid offset
            var clickedOnScreen = Input.mousePosition;
            clickedOnScreen.y = Screen.height - clickedOnScreen.y;

            if (Turret1Rect.Contains(clickedOnScreen)) {
                ActiveTurretTexture2D = _turret1texture2D;
                GameState.CurrentTowerType = Utils.TowerType.DoubleTurret;
            }
            if (Turret2Rect.Contains(clickedOnScreen)) {
                ActiveTurretTexture2D = _turret2Texture2D;
                GameState.CurrentTowerType = Utils.TowerType.Missile;
            }
           // if (Turret3Rect.Contains(clickedOnScreen)) {
         //       ActiveTurretTexture2D = Turret3Texture2D;
         //       GameState.CurrenTowerType = Utils.TowerType.Beam;
        //    }
            UnPause();
            TurretMenu =  !TurretMenu;
        }
    }



    void Pausegame() {
        Time.timeScale = 0;
    
        //Can do music here
    
    
    }


    void UnPause() {


        //Time.timeScale = 1;

        Time.timeScale = SliderValue;
        
        GamePaused = false;

        //Can do Music Here


    }


    void PauseMenu(int windowID) {
        GUILayout.BeginVertical();
        GUILayout.Label("Paused");

        if (GUILayout.Button("Unpause",skin.FindStyle("Button"))) {
            UnPause();
        }

        if (GUILayout.Button("Restart Level", skin.FindStyle("Button")))
        {
          //  UnPause();
          //Sets the Scene to Current Level Index
          // ResetConfigLevel();
          RestartLevel();
        }

        if (GUILayout.Button("Main Menu", skin.FindStyle("Button")))
        {
             UnPause();
          //Go to the Main Menu
             MainMenu();
        }

        //GUILayout.Space(8);
        GUILayout.EndVertical();
        GUI.DragWindow(new Rect(0, 0, 10000, 10000));
    }

    private void RestartLevel()
    {
        ResetConfig();
        Application.LoadLevel(Application.loadedLevel);
    }

    private void MainMenu()
    {
        ResetConfig();    
        Application.LoadLevel(0);
    }

    void GameOver(int windowID)
    {
        GUILayout.BeginVertical();
        GUILayout.Label("Game Over");


        Pausegame();

        if (GUILayout.Button("Restart Level", skin.FindStyle("Button")))
        {
            //  UnPause();
            //Sets the Scene to Current Level Index
            RestartLevel();
        }

        if (GUILayout.Button("Main Menu", skin.FindStyle("Button")))
        {
            UnPause();
            //Go to the Main Menu
            MainMenu();
        }

        if (GUILayout.Button("Quit Game", skin.FindStyle("BUtton")))
        {
            Application.Quit();
        }

        //GUILayout.Space(8);
        GUILayout.EndVertical();
        GUI.DragWindow(new Rect(0, 0, 10000, 10000));
    }


    void ResetConfig()
    {
        GameState.Currency = 300;
        GameState.Score = 0;
        GameState.Wave = 0;
        GameState.Health = 10;
        
        //
        GameIsOver = false;

        //
        SliderValue = 1.0f;

        //Unpause the Game
        UnPause();

    }


    //Game HUD

    void RenderHUD()
    {

     /*   var hud_x = 10F;
        var hud_y = 10F;
        var hudHeight = 300F;
        var hudWidth = 80;*/


        var health = GameState.Health;
        var score = GameState.Score;
        var currency = GameState.Currency;

        GUI.Box(_hudDisplay, "");

        var waveRect = _hudDisplay;
        waveRect.x += 15;
        waveRect.y += 5;
        waveRect.width = 100;
        waveRect.height = 30;

        GUI.Label(waveRect, "Wave " + GameState.Wave.ToString());

        var healthRect = _hudDisplay;
        healthRect.x += 15;
        healthRect.y = waveRect.y + 35;
        waveRect.width = 100;
        waveRect.height = 30;

        GUI.Label(healthRect, "Health: " + health);


        var scoreRect = _hudDisplay;
        scoreRect.x += 15;
        scoreRect.y = healthRect.y + 35;
        scoreRect.width = 95;
        scoreRect.height = 30;

        GUI.Label(scoreRect, "Score: " + score);

        var currencyRect = _hudDisplay;
        currencyRect.x += 15;
        currencyRect.y = scoreRect.y + 35;
        currencyRect.width = 100;
        currencyRect.height = 30;

        GUI.Label(currencyRect,"$" + currency);

        var timeLabelRect = _hudDisplay;
        timeLabelRect.x += 15;
        timeLabelRect.y = currencyRect.y + 25;
        timeLabelRect.width = 100;
        timeLabelRect.height = 30;

        GUI.Label(timeLabelRect,"Game Speed");

        var timeSliderRect = _hudDisplay;
        timeSliderRect.x += 5;
        timeSliderRect.y += timeLabelRect.y + 10;
        timeSliderRect.width = 100;
        timeSliderRect.height = 30;

        SliderValue =  GUI.HorizontalSlider(timeSliderRect, SliderValue, 1f, 2f);

        if (prevSpeed != SliderValue)
        {
            UpdateSpeed();
            prevSpeed = SliderValue;
        }
        

        ///Going to stick Turret cost here

        //Get the Rect position
        var costRect = ActiveTurret;

        costRect.x += 10;
        costRect.y += costRect.height - 20;

        GUI.Label(costRect,"Cost: " + Utils.TowerCost(GameState.CurrentTowerType));


    }


    void UpdateSpeed()
    {
        Time.timeScale = SliderValue;
    }

}
