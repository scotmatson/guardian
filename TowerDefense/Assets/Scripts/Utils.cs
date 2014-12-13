using UnityEngine;
using System.Collections;

public  class Utils : MonoBehaviour {


    private static Plane _xzPlane = new Plane(Vector3.up,Vector3.zero);

    public static GameObject Turret_TwinTurret  = Resources.Load<GameObject>("Turrets/TwinPrefab");
    public static GameObject Turret_Missle = Resources.Load<GameObject>("Turrets/MissilePrefab");
    public static GameObject Turret_Beam = Resources.Load<GameObject>("Turrets/BeamPrefab");


    //Returns the Postion in the Gameworld where mouse input is given
    public static Vector3 GetTargetPosition(Vector3 mouseInput) {
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
        switch (tower)
        {
            case TowerType.DoubleTurret:
                return Turret_TwinTurret;
            case TowerType.Missile:
                return Turret_Missle;
            case TowerType.Beam:
                return Turret_Beam;
        }

        return null;
    }

    public static int TowerCost(TowerType tower) {
        switch (tower) {
          case TowerType.DoubleTurret:
            return 100;
          case TowerType.Beam:
            return 150;
          case TowerType.Missile:
            return 200;

        }
        return 0;
    }

    public static bool CanAfford() {
      return GameState.Currency >= Utils.TowerCost(GameState.CurrenTowerType);
    }


    public enum TowerType {
      DoubleTurret,
      Missile,
      Beam 
    }
}
