using System;
using UnityEngine;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers;

[Serializable]
[AddRandomizerMenu("Perception/Custom Foreground Scale Randomizer")]
public class CustomForegroundScaleRandomizer : Randomizer
{
    public FloatParameter scale;

    protected override void OnIterationStart()
    {
        var taggedObjects = tagManager.Query<CustomForegroundScaleRandomizerTag>();
        foreach (var taggedObject in taggedObjects)
        {
            taggedObject.transform.localScale = Vector3.one * scale.Sample();
        }
    }
}