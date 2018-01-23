using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapParticles : MonoBehaviour {

    public static TapParticles instance;

    public ParticleSystem rewardParticleSystem;
    public ParticleSystem incentiveParticleSystem;

    private void Awake()
    {
        if (TapParticles.instance == null)
        {
            instance = this;
            rewardParticleSystem.transform.position = incentiveParticleSystem.transform.position;
        }
        else
        {
            Debug.Log("An instance of TapParticles already exists. Calling Destroy(gameObject) on the duplicate instance");
            Destroy(gameObject);
        }

    }

    private void FixedUpdate()
    {
        PlayIncentiveIfNeeded();
    }

    private void PlayIncentiveIfNeeded()
    {
        if (PlantStats.instance.GetWater() < PlantStats.instance.maxWater && !incentiveParticleSystem.isPlaying)
        {
            incentiveParticleSystem.Play();
        }
        else if (incentiveParticleSystem.isPlaying)
        {
            incentiveParticleSystem.Stop();
        }
        else return;
    }

    public void EmitRewardParticles()
    {
        rewardParticleSystem.Emit(rewardParticleSystem.emission.GetBurst(0).maxCount);
    }

}
