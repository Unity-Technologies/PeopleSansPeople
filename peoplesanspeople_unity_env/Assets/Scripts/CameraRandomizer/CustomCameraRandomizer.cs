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

[AddRandomizerMenu("Perception/Custom Camera Randomizer")]
public class CustomCameraRandomizer : Randomizer
{

    public bool useVariableFieldOfView = true;
    public FloatParameter cameraFieldOfViewParameter = new FloatParameter { value = new UniformSampler(5.0f, 50.0f) };

    public bool usePhysicalCamera = true;
    public FloatParameter cameraFocalLengthParameter = new FloatParameter { value = new UniformSampler(1.0f, 23.0f) };

    public bool useMovingCamera = true;
    public float changeCameraPosition = 1.0f; 
    public Vector3 initialCameraPosition;

    public bool useRotatingCamera = true;
    public float changeCameraRotation = 1.0f; 
    public Vector3 initialCameraRotation;

    public float multiplyFactor = 5.0f;

    public FloatParameter randomFloat = new FloatParameter { value = new UniformSampler(0, 1) };
    
    protected override void OnIterationStart()
    {

        var taggedObjects = tagManager.Query<CustomCameraRandomizerTag>();
        foreach (var taggedObject in taggedObjects)
        {
            var volume = taggedObject.GetComponent<Camera>();

            // change Field of View
            if (useVariableFieldOfView)
            {                
                float newFoV = cameraFieldOfViewParameter.Sample();
                volume.fieldOfView = newFoV;
            }

            // change Focal Length
            if (usePhysicalCamera)
            {
                float newFL = cameraFocalLengthParameter.Sample();
                volume.focalLength = newFL;
            }

            // transform the camera
            if (useMovingCamera)
            {
                float x_value, y_value, z_value;

                if (randomFloat.Sample() > 0.5)
                {
                    x_value = initialCameraPosition[0] + multiplyFactor * changeCameraPosition * randomFloat.Sample();
                }
                else
                {
                    x_value = initialCameraPosition[0] - multiplyFactor * changeCameraPosition * randomFloat.Sample();
                }
                if (randomFloat.Sample() > 0.5)
                {
                    y_value = initialCameraPosition[1] + multiplyFactor * changeCameraPosition * randomFloat.Sample();
                }
                else
                {
                    y_value = initialCameraPosition[1] - multiplyFactor * changeCameraPosition * randomFloat.Sample();
                }
                if (randomFloat.Sample() > 0.5)
                {
                    z_value = initialCameraPosition[2] + multiplyFactor * changeCameraPosition * randomFloat.Sample();
                }
                else
                {
                    z_value = initialCameraPosition[2] - multiplyFactor * changeCameraPosition * randomFloat.Sample();
                }
                volume.transform.position = new Vector3(x_value, y_value, z_value);
            }

            // rotate the camera
            if (useRotatingCamera)
            {
                float x_rot, y_rot, z_rot;

                if (randomFloat.Sample() > 0.5)
                {
                    x_rot = initialCameraRotation[0] + multiplyFactor * changeCameraRotation * randomFloat.Sample();
                }
                else
                {
                    x_rot = initialCameraRotation[0] - multiplyFactor * changeCameraRotation * randomFloat.Sample();
                }

                if (randomFloat.Sample() > 0.5)
                {
                    y_rot = initialCameraRotation[1] + multiplyFactor * changeCameraRotation * randomFloat.Sample();
                    
                }
                else
                {
                    y_rot = initialCameraRotation[1] - multiplyFactor * changeCameraRotation * randomFloat.Sample();
                }

                if (randomFloat.Sample() > 0.5)
                {
                    z_rot = initialCameraRotation[2] + multiplyFactor * changeCameraRotation * randomFloat.Sample();
                }
                else
                {
                    z_rot = initialCameraRotation[2] - multiplyFactor * changeCameraRotation * randomFloat.Sample();
                }

                volume.transform.rotation = Quaternion.Euler(x_rot, y_rot, z_rot);
            }
        }
    }
}