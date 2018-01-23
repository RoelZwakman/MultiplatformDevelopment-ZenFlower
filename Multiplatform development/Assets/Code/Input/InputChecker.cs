using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputChecker : MonoBehaviour {

    public static InputChecker instance;

    private void Awake()
    {
        if (InputChecker.instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("An instance of InputChecker already exists. Calling Destroy(gameObject) on the duplicate instance");
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        //////Checks the input of the currently running platform.
        #if UNITY_ANDROID
        AndroidInput();
        #endif    

        #if UNITY_STANDALONE_WIN
        WindowsInput();
        #endif
    }


    #region windows input code
    #if UNITY_STANDALONE_WIN
    private void WindowsInput() /////Checks what input is being given on Windows.
    {   
        if(Input.GetButtonDown("Water plant"))
        {
            CheckClick();
        }
    }

    private void CheckClick()
    {
        if(Vector2.Distance(Input.mousePosition, TouchLocations.instance.tapToWaterPlantPos) < TouchLocations.instance.tapToWaterPlantPosTolerance)
        {
            Debug.Log("Pressed the Water plant button within max distance tapToWaterPlantPosTolerance");
            PlantStats.instance.WaterPlant();
        }
    }

    #endif
    #endregion


    #region android input code
    #if UNITY_ANDROID
    private void AndroidInput() /////Checks what input is being given on Android.
    {
        if(Input.touches.Length > 0)
        {
            CheckTouch();
        }
    }

    private void CheckTouch()
    {
        if(Input.GetTouch(0).phase == TouchPhase.Began && Vector2.Distance(Input.GetTouch(0).position, TouchLocations.instance.tapToWaterPlantPos) < TouchLocations.instance.tapToWaterPlantPosTolerance)
        {
            Debug.Log("Tapped the tapToWaterPlantPos within max distance tapToWaterPlantPosTolerance");
            PlantStats.instance.WaterPlant();
            Debug.LogError("Touch position: " + Input.GetTouch(0).position);
            Debug.LogError("TouchLocations.instance.tapToWaterPlantPos: " + TouchLocations.instance.tapToWaterPlantPos);
        }
    }
    #endif
    #endregion
}
