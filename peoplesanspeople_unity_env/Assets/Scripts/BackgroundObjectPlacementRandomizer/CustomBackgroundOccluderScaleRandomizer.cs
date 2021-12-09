using System;
using UnityEngine;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers;

[Serializable]
[AddRandomizerMenu("Perception/Custom Background Occluder Scale Randomizer")]
public class CustomBackgroundOccluderScaleRandomizer : Randomizer
{
    public FloatParameter scale;

    protected override void OnIterationStart()
    {
        var taggedObjects = tagManager.Query<CustomBackgroundOccluderScaleRandomizerTag>();
        foreach (var taggedObject in taggedObjects)
        {
            taggedObject.transform.localScale = Vector3.one * scale.Sample();
        }
    }
}