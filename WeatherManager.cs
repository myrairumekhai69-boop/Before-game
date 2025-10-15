using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    [Header("Weather")]
    public ParticleSystem rainParticle;
    public Light directionalLight;
    public AnimationCurve dayLightIntensityByRain; // 0..1 rain -> intensity
    [Range(0,1)] public float rainIntensity = 0f; // 0 none, 1 heavy

    [Header("Wind")]
    public float windStrength = 1f;

    void Start()
    {
        ApplyWeather();
    }

    void Update()
    {
        // debug keys
        if (Input.GetKeyDown(KeyCode.F1)) SetRain(0f);
        if (Input.GetKeyDown(KeyCode.F2)) SetRain(0.6f);
        if (Input.GetKeyDown(KeyCode.F3)) SetRain(1f);

        // optional runtime smoothing could be added
    }

    public void SetRain(float intensity)
    {
        rainIntensity = Mathf.Clamp01(intensity);
        ApplyWeather();
    }

    void ApplyWeather()
    {
        var emission = rainParticle.emission;
        emission.rateOverTime = Mathf.Lerp(0f, 2000f, rainIntensity);

        if (directionalLight)
            directionalLight.intensity = Mathf.Lerp(1.1f, 0.45f, rainIntensity) * dayLightIntensityByRain.Evaluate(rainIntensity);

        Shader.SetGlobalFloat("_GlobalRainAmount", rainIntensity); // if you use shaders that read this
    }
}
