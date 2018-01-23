using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateChecker : MonoBehaviour {
    
    public static DateChecker instance;

    public int currentDayOfYear;

    public GameObject firstVisitButton;

    private void Awake()
    {
        if (DateChecker.instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("An instance of DateChecker already exists. Calling Destroy(gameObject) on the duplicate instance");
            Destroy(gameObject);
        }
        
    }

    private void Start()
    {
        LoadDayOfYear();
        Debug.Log(CheckForDifferentDayOfYear());
        TryFirstTimeVisit();
    }

    private void LoadDayOfYear()
    {
        currentDayOfYear = System.DateTime.Now.DayOfYear;
    }

    private void TryFirstTimeVisit() ////currentDayOfYear should be 0 if the game is played for the first time. If this is true, then show textbox.
    {
        if (currentDayOfYear == 0)
        {
            firstVisitButton.SetActive(true);
            DataSerializer.instance.savedData.lastDayOfYear = currentDayOfYear;
            DataSerializer.instance.SaveGame();
        }
    }

    public bool CheckForDifferentDayOfYear()
    {
        if(currentDayOfYear != DataSerializer.instance.savedData.lastDayOfYear) ////different day of year from last time you played
        {
            DataSerializer.instance.savedData.lastDayOfYear = currentDayOfYear;
            DataSerializer.instance.SaveGame();
            return true;
        }

        else ////same day of year as last time you played
        {
            return false;
        }
    }

}
