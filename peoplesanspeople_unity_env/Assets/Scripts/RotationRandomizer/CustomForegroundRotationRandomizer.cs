using System;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers.SampleRandomizers.Tags;
using UnityEngine.Perception.Randomization.Samplers;

namespace UnityEngine.Perception.Randomization.Randomizers.SampleRandomizers
{
    /// <summary>
    /// Randomizes the rotation of objects tagged with a CustomForegroundRotationRandomizerTag
    /// </summary>
    [Serializable]
    [AddRandomizerMenu("Perception/Custom Foreground Rotation Randomizer")]
    public class CustomForegroundRotationRandomizer : Randomizer
    {
        /// <summary>
        /// Defines the range of random rotations that can be assigned to tagged objects
        /// </summary>
        public Vector3Parameter rotation = new Vector3Parameter
        {
            x = new UniformSampler(0, 0),
            y = new UniformSampler(0, 360),
            z = new UniformSampler(0, 0)
        };

        /// <summary>
        /// Randomizes the rotation of tagged objects at the start of each scenario iteration
        /// </summary>
        protected override void OnIterationStart()
        {
            var taggedObjects = tagManager.Query<CustomForegroundRotationRandomizerTag>();
            foreach (var taggedObject in taggedObjects)
                taggedObject.transform.rotation = Quaternion.Euler(rotation.Sample());
        }
    }
}
