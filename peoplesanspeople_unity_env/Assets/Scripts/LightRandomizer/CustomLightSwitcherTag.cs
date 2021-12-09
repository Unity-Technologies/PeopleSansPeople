using UnityEngine;
using UnityEngine.Perception.Randomization.Randomizers;

[AddComponentMenu("Perception/RandomizerTags/CustomLightSwitcherTag")]
public class CustomLightSwitcherTag : RandomizerTag
{
    public float enabledProbability = 0.5f;
    public void Act(float rawInput)
    {
        var light = gameObject.GetComponent<Light>();
        if (light)
        {
            light.enabled = rawInput < enabledProbability;
        }
    }
}