using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers;
using UnityEngine.Perception.Randomization.Samplers;

[Serializable]

[AddRandomizerMenu("Perception/Custom Light Randomizer")]
public class CustomLightRandomizer : Randomizer
{

    public FloatParameter lightIntensityParameter = new FloatParameter { value = new UniformSampler(0f, 1f) };
    public ColorRgbParameter lightColorParameter = new ColorRgbParameter
    {
        red = new UniformSampler(0.4f, 1f),
        green = new UniformSampler(0.4f, 1f),
        blue = new UniformSampler(0.4f, 1f),
        alpha = new ConstantSampler(1f),
    };
    public FloatParameter auxParameter = new FloatParameter { value = new UniformSampler(0f, 1f) };

    protected override void OnIterationStart()
    {
        var taggedObjects = tagManager.Query<CustomLightRandomizerTag>();
        foreach (var taggedObject in taggedObjects)
        {
            var light = taggedObject.GetComponent<Light>();
            if (light)
            {
                light.color = lightColorParameter.Sample();
            }

            var tag = taggedObject.GetComponent<CustomLightRandomizerTag>();
            if (tag)
            {
                tag.SetIntensity(lightIntensityParameter.Sample());
            }
        }

        var taggedObjectsSwitcher = tagManager.Query<CustomLightSwitcherTag>();
        foreach (var taggedObject in taggedObjectsSwitcher)
        {
            var tag = taggedObject.GetComponent<CustomLightSwitcherTag>();
            if (tag)
            {
                tag.Act(auxParameter.Sample());
            }
        }
    }
}