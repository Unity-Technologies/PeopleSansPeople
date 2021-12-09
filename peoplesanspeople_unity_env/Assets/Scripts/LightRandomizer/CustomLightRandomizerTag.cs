using UnityEngine;
using UnityEngine.Perception.Randomization.Randomizers;

[AddComponentMenu("Perception/RandomizerTags/CustomLightRandomizerTag")]
public class CustomLightRandomizerTag : RandomizerTag
{
    public float minIntensity = 5000.0f;
    public float maxIntensity = 20000.0f;

    public void SetIntensity(float rawIntensity)
    {
        var light = gameObject.GetComponent<Light>();
        if (light)
        {
            var scaledIntensity = rawIntensity * (maxIntensity - minIntensity) + minIntensity;
            light.intensity = scaledIntensity;
        }
    }
}