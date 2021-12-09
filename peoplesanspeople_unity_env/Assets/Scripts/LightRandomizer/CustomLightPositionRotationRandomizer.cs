using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Perception.Randomization.Randomizers;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using FloatParameter = UnityEngine.Perception.Randomization.Parameters.FloatParameter;
using UnityEngine.Perception.Randomization.Samplers;

[Serializable]

[AddRandomizerMenu("Perception/Custom Light Position Rotation Randomizer")]
public class CustomLightPositionRotationRandomizer : Randomizer
{
    public bool useMovingLight = true;
    public float changeLightPosition = 0.73f;
    public Vector3 initialLightPosition;

    public bool useRotatingLight = true;
    public float changeLightRotation = 10.0f;
    public Vector3 initialLightRotation;

    public float multiplyFactor = 5.0f;

    public FloatParameter randomFloat = new FloatParameter { value = new UniformSampler(0, 1) };

    protected override void OnIterationStart()
    {

        var taggedObjects = tagManager.Query<CustomLightPositionRotationRandomizerTag>();
        foreach (var taggedObject in taggedObjects)
        {
            var volume = taggedObject.GetComponent<Light>();

            // move the light
            if (useMovingLight)
            {
                float x_value, y_value, z_value;

                if (randomFloat.Sample() > 0.5)
                {
                    x_value = initialLightPosition[0] + multiplyFactor * changeLightPosition * randomFloat.Sample();
                }
                else
                {
                    x_value = initialLightPosition[0] - multiplyFactor * changeLightPosition * randomFloat.Sample();
                }
                if (randomFloat.Sample() > 0.5)
                {
                    y_value = initialLightPosition[1] + multiplyFactor * changeLightPosition * randomFloat.Sample();
                }
                else
                {
                    y_value = initialLightPosition[1] - multiplyFactor * changeLightPosition * randomFloat.Sample();
                }
                if (randomFloat.Sample() > 0.5)
                {
                    z_value = initialLightPosition[2] + multiplyFactor * changeLightPosition * randomFloat.Sample();
                }
                else
                {
                    z_value = initialLightPosition[2] - multiplyFactor * changeLightPosition * randomFloat.Sample();
                }
                volume.transform.position = new Vector3(x_value, y_value, z_value);
            }

            // rotate the Light
            if (useRotatingLight)
            {
                float x_rot, y_rot, z_rot;

                if (randomFloat.Sample() > 0.5)
                {
                    x_rot = initialLightRotation[0] + multiplyFactor * changeLightRotation * randomFloat.Sample();
                }
                else
                {
                    x_rot = initialLightRotation[0] - multiplyFactor * changeLightRotation * randomFloat.Sample();
                }

                if (randomFloat.Sample() > 0.5)
                {
                    y_rot = initialLightRotation[1] + multiplyFactor * changeLightRotation * randomFloat.Sample();

                }
                else
                {
                    y_rot = initialLightRotation[1] - multiplyFactor * changeLightRotation * randomFloat.Sample();
                }

                if (randomFloat.Sample() > 0.5)
                {
                    z_rot = initialLightRotation[2] + multiplyFactor * changeLightRotation * randomFloat.Sample();
                }
                else
                {
                    z_rot = initialLightRotation[2] - multiplyFactor * changeLightRotation * randomFloat.Sample();
                }

                volume.transform.rotation = Quaternion.Euler(x_rot, y_rot, z_rot);
            }
        }
    }
}