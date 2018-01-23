using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterfallScrollHelper : MonoBehaviour {

    public Material mat;
    public float speedModifier;

	void FixedUpdate()
    {
        SetUTime();
    }

    void SetUTime()
    {
        mat.SetFloat("_UTime", speedModifier * Time.time);
    }

}
