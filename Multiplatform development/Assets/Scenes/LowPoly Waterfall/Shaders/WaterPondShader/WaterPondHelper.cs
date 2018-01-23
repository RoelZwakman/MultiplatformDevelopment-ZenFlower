using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPondHelper : MonoBehaviour {

    public Material mat;
    public float intensityModifier;

    void Update()
    {
        SetUTime();
    }

    void SetUTime()
    {
        mat.SetFloat("_UTime", intensityModifier * Time.time);
    }
}
