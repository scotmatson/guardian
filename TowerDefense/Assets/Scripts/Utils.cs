﻿using UnityEngine;
using System.Collections;

public  class Utils : MonoBehaviour {


    private static Plane _xzPlane = new Plane(Vector3.up,Vector3.zero);

    public static GameObject Turret_TwinTurret;
    public static GameObject Turret_Fire;
    public static GameObject Turret_Beam;


    //Returns the Postion in the Gameworld where mouse input is given
    public static Vector3 GetTargetPosition(Vector3 mouseInput)
    {
        var ray = Camera.main.ScreenPointToRay(mouseInput);
        float hitDist;

        var targetPostion = Vector3.zero;

        if (_xzPlane.Raycast(ray, out hitDist))
        {
            //Gets the New Position to move to 
            targetPostion = ray.GetPoint(hitDist);
        }
        return targetPostion;
    }

    public static GameObject TowerFromType(TowerType tower)
    {
        Turret_TwinTurret = Resources.Load<GameObject>("Turrets/TwinPrefab");

        switch (tower)
        {
                case TowerType.DoubleTurret:
                return Turret_TwinTurret;

        }

        return null;
    }


    public enum TowerType
    {
        DoubleTurret,
        Fire,
        Beam 
    }

}
