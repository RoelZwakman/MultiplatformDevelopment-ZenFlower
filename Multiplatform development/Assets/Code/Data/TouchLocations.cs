using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLocations : MonoBehaviour {

    public static TouchLocations instance;

    public Vector2 tapToWaterPlantPos;
    public float tapToWaterPlantPosTolerance; ////max distance between touch location and tapToWaterPlantPos that is still acceptable

    private void Awake()
    {
        if (TouchLocations.instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("An instance of TouchLocations already exists. Calling Destroy(gameObject) on the duplicate instance");
            Destroy(gameObject);
        }

        

    }

    private void Start()
    {
        tapToWaterPlantPos.x = Screen.width / 2;
        tapToWaterPlantPos.y = Screen.height / 2;
    }

}
