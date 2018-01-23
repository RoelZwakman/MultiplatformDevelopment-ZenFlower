using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerCustomizationUIHelper : MonoBehaviour {

    public GameObject[] customizationButtons; 

	public void ToggleCustomizationButtons() /////Toggles all UI elements in customizationButtons[] to be active or inactive.
    {
        for(int i = 0; i < customizationButtons.Length; i++)
        {
            if (customizationButtons[i].activeSelf)
            {
                customizationButtons[i].SetActive(false);
            }
            else
            {
                customizationButtons[i].SetActive(true);
            }
        }
    }

}
