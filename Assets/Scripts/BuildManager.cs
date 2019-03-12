
using System;
using UnityEngine;

public class BuildManager : MonoBehaviour {


    //we use singleton method to insure that there is only one BuildManager in the game
    public static BuildManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in the scene!");
            return;
        }
        instance = this;
    }

    private TurretBlueprint turretToBuild;

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;
    public GameObject lazerTurretPrefab;

    public GameObject buildEffect;

   public bool CanBuild { get { return turretToBuild != null; } }
   public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }
    
    
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not Enough Money to build that!, TODO: display on screen");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret=(GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        GameObject effect=(GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret built! Money Left: " + PlayerStats.Money.ToString());
    }
}
