using System;
using System.Linq;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers.Utilities;
using UnityEngine.Perception.Randomization.Samplers;

namespace UnityEngine.Perception.Randomization.Randomizers.SampleRandomizers
{
    /// <summary>
    /// Creates multiple layers of evenly distributed but randomly placed objects
    /// </summary>
    [Serializable]
    [AddRandomizerMenu("Perception/Custom Background Object Placement Randomizer")]
    public class CustomBackgroundObjectPlacementRandomizer : Randomizer
    {
        public float minX = -7.5f;
        public float maxX = 7.5f;
        public float minY = -7.5f;
        public float maxY = 7.5f;
        private float _widthX => Math.Abs(minX) + Math.Abs(maxX);
        private float _widthY => Math.Abs(minY) + Math.Abs(maxY);

        public FloatParameter depth = new FloatParameter();

        /// <summary>
        /// The minimum distance between placed background objects
        /// </summary>
        public float separationDistance = 2f;

        /// <summary>
        /// A categorical parameter for sampling random prefabs to place
        /// </summary>
        public GameObjectParameter prefabs;

        GameObject m_Container;
        CustomGameObjectOneWayCache m_GameObjectOneWayCache;

        /// <inheritdoc/>
        protected override void OnAwake()
        {
            m_Container = new GameObject("BackgroundContainer");
            m_Container.transform.parent = scenario.transform;
            m_GameObjectOneWayCache = new CustomGameObjectOneWayCache(
                m_Container.transform, prefabs.categories.Select((element) => element.Item1).ToArray());
        }

        /// <summary>
        /// Generates background layers of objects at the start of each scenario iteration
        /// </summary>
        protected override void OnIterationStart()
        {
            var seed = SamplerState.NextRandomState();
            var placementSamples = CustomPoissonDiskSampling.GenerateSamples(
                _widthX, _widthY, separationDistance, seed);
            var offset = new Vector3(minX, minY, 0f); // this is to recenter the samples at origin
            foreach (var sample in placementSamples)
            {
                float placementDepth = depth.Sample();
                var instance = m_GameObjectOneWayCache.GetOrInstantiate(prefabs.Sample());
                instance.transform.position = new Vector3(sample.x, sample.y, placementDepth) + offset;
            }
            placementSamples.Dispose();
        }

        /// <summary>
        /// Deletes generated background objects after each scenario iteration is complete
        /// </summary>
        protected override void OnIterationEnd()
        {
            m_GameObjectOneWayCache.ResetAllObjects();
        }
    }
}
