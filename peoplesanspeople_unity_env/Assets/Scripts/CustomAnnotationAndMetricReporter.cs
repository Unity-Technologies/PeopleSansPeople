using System;
using UnityEngine;
using UnityEngine.Perception.GroundTruth;

[RequireComponent(typeof(PerceptionCamera))]
public class CustomAnnotationAndMetricReporter : MonoBehaviour
{
    //public GameObject targetLight;
    public GameObject targetCamera;
    //public GameObject target;

    public GameObject[] lightSources;

    MetricDefinition lightPositionMetricDefinition;
    MetricDefinition lightRotationMetricDefinition;
    MetricDefinition lightIntensityMetricDefinition;
    MetricDefinition lightColorMetricDefinition;

    MetricDefinition cameraPositionMetricDefinition;
    MetricDefinition cameraRotationMetricDefinition;
    MetricDefinition cameraFieldOfViewMetricDefinition;
    MetricDefinition cameraFocalLengthMetricDefinition;

    //AnnotationDefinition boundingBoxAnnotationDefinition;
    //SensorHandle cameraSensorHandle;

    public void Start()
    {
        //Debug.Log(Guid.NewGuid());
        //Debug.Log(Guid.NewGuid());


        //Metrics and annotations are registered up-front
        lightPositionMetricDefinition = DatasetCapture.RegisterMetricDefinition(
            "Light position",
            "The world-space position of the light",
            Guid.Parse("c0b5e272-9715-4ea2-930e-cfe8cecf1b6e"));

        lightRotationMetricDefinition = DatasetCapture.RegisterMetricDefinition(
            "Light rotation",
            "The world-space rotation of the light",
            Guid.Parse("317735b9-b4a4-4f6b-a4c9-eb846463a583"));

        lightIntensityMetricDefinition = DatasetCapture.RegisterMetricDefinition(
            "Light intensity",
            "The intensity of the light",
            Guid.Parse("1a709e09-81bd-43b5-b8f0-f3952a1af444"));

        lightColorMetricDefinition = DatasetCapture.RegisterMetricDefinition(
            "Light color",
            "The color of the light",
            Guid.Parse("a640e390-fa13-4bb0-b2cd-1e0cb3f43eb9"));

        cameraPositionMetricDefinition = DatasetCapture.RegisterMetricDefinition(
            "Camera position",
            "The world-space position of the camera",
            Guid.Parse("1529faeb-863f-40c2-840f-5fe4221c1065"));

        cameraRotationMetricDefinition = DatasetCapture.RegisterMetricDefinition(
            "Camera rotation",
            "The world-space rotation of the camera",
            Guid.Parse("5199deef-2eb0-42fe-b00d-1d2418aedaff"));

        cameraFieldOfViewMetricDefinition = DatasetCapture.RegisterMetricDefinition(
            "Camera field of view",
            "The field of view of the camera",
            Guid.Parse("42e7fa88-084b-423d-ba6e-830c711383e1"));

        cameraFocalLengthMetricDefinition = DatasetCapture.RegisterMetricDefinition(
            "Camera focal length",
            "The focal length of the camera",
            Guid.Parse("11aa1dfc-3495-467c-a998-71d9bfe6980e"));


        //boundingBoxAnnotationDefinition = DatasetCapture.RegisterAnnotationDefinition(
        //    "Target bounding box",
        //    "The position of the target in the camera's local space",
        //    id: Guid.Parse("C0B4A22C-0420-4D9F-BAFC-954B8F7B35A7"));
    }

    public void Update()
    {
        ////Report the light's position by manually creating the json array string.
        //var lightPosition = targetLight.transform.position;
        //DatasetCapture.ReportMetric(lightPositionMetricDefinition,
        //    $@"[{{ ""x"": {lightPosition.x}, ""y"": {lightPosition.y}, ""z"": {lightPosition.z} }}]");

        ////Report the light's rotation by manually creating the json array string.
        //var lightRotation = targetLight.transform.rotation.eulerAngles;
        //DatasetCapture.ReportMetric(lightRotationMetricDefinition,
        //    $@"[{{ ""x"": {lightRotation.x}, ""y"": {lightRotation.y}, ""z"": {lightRotation.z} }}]");

        //var lightIntensity = targetLight.GetComponent<Light>().intensity;
        //DatasetCapture.ReportMetric(lightIntensityMetricDefinition,
        //    $@"[{{ ""LightIntensity"": {lightIntensity} }}]");

        //var lightColor = targetLight.GetComponent<Light>().color;
        //DatasetCapture.ReportMetric(lightColorMetricDefinition,
        //    $@"[{{ ""LightColorR"": {lightColor.r}, ""LightColorG"": {lightColor.g}, ""LightColorB"": {lightColor.b}, ""LightColorA"": {lightColor.a} }}]");


        foreach (GameObject lightObject in lightSources)
        {
            string lightName = lightObject.name;

            //Report the light's position by manually creating the json array string.
            var lightPosition = lightObject.transform.position;
            DatasetCapture.ReportMetric(lightPositionMetricDefinition,
                $@"[{{ ""{"LightPositionX_" + lightName}"": {lightPosition.x},
                       ""{"LightPositionY_" + lightName}"": {lightPosition.y},
                       ""{"LightPositionZ_" + lightName}"": {lightPosition.z} }}]");

            //Report the light's rotation by manually creating the json array string.
            var lightRotation = lightObject.transform.rotation.eulerAngles;
            DatasetCapture.ReportMetric(lightRotationMetricDefinition,
                $@"[{{ ""{"LightRotationX_" + lightName}"": {lightRotation.x},
                       ""{"LightRotationY_" + lightName}"": {lightRotation.y},
                       ""{"LightRotationZ_" + lightName}"": {lightRotation.z} }}]");

            var lightIntensity = lightObject.GetComponent<Light>().intensity;
            DatasetCapture.ReportMetric(lightIntensityMetricDefinition,
                $@"[{{ ""{"LightIntensity_" + lightName}"": {lightIntensity} }}]");

            var lightColor = lightObject.GetComponent<Light>().color;
            DatasetCapture.ReportMetric(lightColorMetricDefinition,
                $@"[{{ ""{"LightColorR_" + lightName}"": {lightColor.r},
                       ""{"LightColorG_" + lightName}"": {lightColor.g},
                       ""{"LightColorB_" + lightName}"": {lightColor.b},
                       ""{"LightColorA_" + lightName}"": {lightColor.a} }}]");
        }

        //Report the camera's position by manually creating the json array string.
        var cameraPosition = targetCamera.transform.position;
        DatasetCapture.ReportMetric(cameraPositionMetricDefinition,
            $@"[{{ ""CameraPositionX"": {cameraPosition.x}, ""CameraPositionY"": {cameraPosition.y}, ""CameraPositionZ"": {cameraPosition.z} }}]");

        //Report the camera's rotation by manually creating the json array string.q
        var cameraRotation = targetCamera.transform.rotation.eulerAngles;
        DatasetCapture.ReportMetric(cameraRotationMetricDefinition,
            $@"[{{ ""CameraRotationX"": {cameraRotation.x}, ""CameraRotationY"": {cameraRotation.y}, ""CameraRotationZ"": {cameraRotation.z} }}]");


        var cameraFieldOfView = targetCamera.GetComponent<Camera>().fieldOfView;
        DatasetCapture.ReportMetric(cameraFieldOfViewMetricDefinition,
            $@"[{{ ""CameraFieldOfView"": {cameraFieldOfView} }}]");

        var cameraFocalLength = targetCamera.GetComponent<Camera>().focalLength;
        DatasetCapture.ReportMetric(cameraFocalLengthMetricDefinition,
            $@"[{{ ""CameraFocalLength"": {cameraFocalLength} }}]");


        ////compute the location of the object in the camera's local space
        //Vector3 targetPos = transform.worldToLocalMatrix * target.transform.position;
        ////Report using the PerceptionCamera's SensorHandle if scheduled this frame
        //var sensorHandle = GetComponent<PerceptionCamera>().SensorHandle;
        //if (sensorHandle.ShouldCaptureThisFrame)
        //{
        //    sensorHandle.ReportAnnotationValues(
        //        boundingBoxAnnotationDefinition,
        //        new[] { targetPos });
        //}
    }
}