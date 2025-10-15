using UnityEngine;

public class RainEffectController : MonoBehaviour
{
    public ParticleSystem rainFX;
    public Material puddleMaterial;
    [Range(0,1)] public float wetness = 0f;

    void Start()
    {
        UpdateWetness();
    }

    public void SetWetness(float amount)
    {
        wetness = Mathf.Clamp01(amount);
        UpdateWetness();
    }

    void UpdateWetness()
    {
        if (rainFX)
        {
            var emission = rainFX.emission;
            emission.rateOverTime = Mathf.Lerp(0, 2000, wetness);
        }

        if (puddleMaterial)
        {
            puddleMaterial.SetFloat("_Wetness", wetness); // requires shader supporting _Wetness
        }
    }
}
