using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHelper : MonoBehaviour {

    Text _healthText;

    private void Awake()
    {
        _healthText = GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        _healthText.text = PlantStats.instance.GetWater().ToString();
    }
}
