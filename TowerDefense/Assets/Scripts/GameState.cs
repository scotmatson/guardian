﻿using System.Runtime.InteropServices;
using UnityEngine;
using System.Collections;

public class GameState : MonoBehaviour
{

    public static int Currency = 300;
    public static int Score = 0;

    public static int Wave = 0;
    public static int EnemyCount = 0;

    public static int LevelScore = 0;

    //Arbituray 5 right now
    public static int Health = 10;

    public static Utils.TowerType CurrentTowerType;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
