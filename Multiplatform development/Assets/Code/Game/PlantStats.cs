using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantStats : MonoBehaviour {

    public static PlantStats instance;

    private float _water;
    public float maxWater;

    public float waterAdded;

    private void Awake()
    {
        if (PlantStats.instance == null)
        {
            instance = this;
            
        }
        else
        {
            Debug.Log("An instance of PlantStats already exists. Calling Destroy(gameObject) on the duplicate instance");
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        instance.SetUpWater();
    }

    private void SetUpWater() 
    {
        if (!DateChecker.instance.CheckForDifferentDayOfYear())
        {
            instance._water = 0;
            DataSerializer.instance.savedData.flowerHealth = _water;
            DataSerializer.instance.SaveGame();
        }
        else
        {
            instance._water = DataSerializer.instance.savedData.flowerHealth;
        }
    }

    public void WaterPlant()
    {
        if (instance._water + waterAdded > maxWater)
        {
            instance._water = maxWater;
        }
        else
        {
            instance._water += waterAdded;
        }
        DataSerializer.instance.savedData.flowerHealth = instance._water;
        DataSerializer.instance.SaveGame();
        TapParticles.instance.EmitRewardParticles();
        Debug.Log(instance._water);
    }

    public float GetWater()
    {
        return _water;
    }

}
