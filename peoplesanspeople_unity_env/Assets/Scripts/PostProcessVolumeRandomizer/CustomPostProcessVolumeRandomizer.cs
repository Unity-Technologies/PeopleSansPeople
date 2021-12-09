using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using FloatParameter = UnityEngine.Perception.Randomization.Parameters.FloatParameter;
using UnityEngine.Perception.Randomization.Samplers;
using UnityEngine.Perception.Randomization.Randomizers;


[Serializable]

[AddRandomizerMenu("Perception/Custom Post Process Volume Randomizer")]
public class CustomPostProcessVolumeRandomizer : Randomizer
{
    public FloatParameter vignetteIntensityParameter = new FloatParameter { value = new UniformSampler(0.0f, 0.5f) };
    public FloatParameter fixedExposureParameter = new FloatParameter { value = new UniformSampler(5.0f, 10.0f) };
    public FloatParameter whiteBalanceTemperatureParameter = new FloatParameter { value = new UniformSampler(-20.0f, 20.0f) };
    public FloatParameter filmGrainIntensityParameter = new FloatParameter { value = new UniformSampler(0.0f, 1.0f) };
    public FloatParameter lensDistortionIntensityParameter = new FloatParameter { value = new UniformSampler(-0.2f, 0.2f) };
    public FloatParameter focusDistanceParameter = new FloatParameter { value = new UniformSampler(0.1f, 4.0f) };
    public FloatParameter contrastParameter = new FloatParameter { value = new UniformSampler(-30.0f, 30.0f) };
    public FloatParameter saturationParameter = new FloatParameter { value = new UniformSampler(-30.0f, 30.0f) };

    protected override void OnIterationStart()
    {
        // TODO: does Start() vs Update() matter for effects propagating?
        var taggedObjects = tagManager.Query<CustomPostProcessVolumeTag>();
        foreach (var obj in taggedObjects)
        {
            var volumeProfile = obj.GetComponent<Volume>();

            // Modify Vignette;
            ModVignette(volumeProfile);

            // Modify Exposure;
            ModExposure(volumeProfile);

            // Modify White Balance;
            ModWhiteBalance(volumeProfile);

            // Modify Film Grain
            ModFilmGrain(volumeProfile);

            // Modify Lens Distortion
            ModLensDistortion(volumeProfile);

            // Modify Depth of Field - remember to set Focus Mode to (Use Physical Camera) and Quality to (Custom) in inspector
            ModDepthOfField(volumeProfile);

            // Modify Color Adjustment
            ModColorAdjustments(volumeProfile);
        }
    }

    public void ModVignette(Volume volumeProfile)
    {
        Vignette vignette;
        if (volumeProfile.profile.TryGet(out vignette))
        {
            float vignetteVal = vignetteIntensityParameter.Sample();
            vignette.intensity.value = vignetteVal;
        }
    }

    public void ModExposure(Volume volumeProfile)
    {
        Exposure exposure;
        if (volumeProfile.profile.TryGet(out exposure))
        {
            float exposureVal = fixedExposureParameter.Sample();
            exposure.fixedExposure.value = exposureVal;
        }
    }

    public void ModWhiteBalance(Volume volumeProfile)
    {
        WhiteBalance whiteBalance;
        if (volumeProfile.profile.TryGet(out whiteBalance))
        {
            float whiteBalanceTemperatureVal = whiteBalanceTemperatureParameter.Sample();
            whiteBalance.temperature.value = whiteBalanceTemperatureVal;
        }
    }

    public void ModFilmGrain(Volume volumeProfile)
    {
        FilmGrain filmGrain;
        if (volumeProfile.profile.TryGet(out filmGrain))
        {
            float filmGrainVal = filmGrainIntensityParameter.Sample();
            filmGrain.intensity.value = filmGrainVal;
        }
    }

    public void ModLensDistortion(Volume volumeProfile)
    {
        LensDistortion lensDistortion;
        if (volumeProfile.profile.TryGet(out lensDistortion))
        {
            float lensDistortionVal = lensDistortionIntensityParameter.Sample();
            lensDistortion.intensity.value = lensDistortionVal;
        }
    }

    public void ModDepthOfField(Volume volumeProfile)
    {
        DepthOfField depthOfField;
        if (volumeProfile.profile.TryGet(out depthOfField))
        {
            float blurParameterNear = focusDistanceParameter.Sample();
            depthOfField.focusDistance.value = blurParameterNear;
        }
    }

    public void ModColorAdjustments(Volume volumeProfile)
    {
        ColorAdjustments colorAdjustments;
        if (volumeProfile.profile.TryGet(out colorAdjustments))
        {
            float contrastVal = contrastParameter.Sample();
            colorAdjustments.contrast.value = contrastVal;

            float saturationVal = saturationParameter.Sample();
            colorAdjustments.saturation.value = saturationVal;
        }
    }
}
