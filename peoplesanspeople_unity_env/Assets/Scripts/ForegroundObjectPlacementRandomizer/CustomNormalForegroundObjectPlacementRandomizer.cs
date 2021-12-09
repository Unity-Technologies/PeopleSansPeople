using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers.Utilities;
using UnityEngine.Perception.Randomization.Samplers;

namespace UnityEngine.Perception.Randomization.Randomizers.SampleRandomizers
{
    /// <summary>
    /// Creates a 2D layer of of evenly spaced GameObjects from a given list of prefabs
    /// </summary>
    [Serializable]
    [AddRandomizerMenu("Perception/Normal Object Placement Randomizer")]
    public class NormalForegroundObjectPlacementRandomizer : Randomizer
    {
        /// <summary>
        /// The Z offset component applied to the generated layer of GameObjects
        /// </summary>
        [Tooltip("The Z offset applied to positions of all placed objects.")]
        public float depth;

        /// <summary>
        /// The minimum distance between all placed objects
        /// </summary>
        [Tooltip("The minimum distance between the centers of the placed objects.")]
        public float separationDistance = 2f;


        public FloatParameter xLocation = new FloatParameter() { value = new NormalSampler(0, 10, 5, 2) };
        public FloatParameter yLocation = new FloatParameter() { value = new NormalSampler(0, 10, 5, 2) };

        /// <summary>
        /// The list of prefabs sample and randomly place
        /// </summary>
        [Tooltip("The list of Prefabs to be placed by this Randomizer.")]
        public GameObjectParameter prefabs;

        GameObject m_Container;
        GameObjectOneWayCache m_GameObjectOneWayCache;
        public int objectCount = 20;

        /// <inheritdoc/>
        protected override void OnAwake()
        {
            m_Container = new GameObject("Foreground Objects");
            m_Container.transform.parent = scenario.transform;
            m_GameObjectOneWayCache = new GameObjectOneWayCache(
                m_Container.transform, prefabs.categories.Select(element => element.Item1).ToArray());
        }

        /// <summary>
        /// Generates a foreground layer of objects at the start of each scenario iteration
        /// </summary>
        protected override void OnIterationStart()
        {
            List<Vector3> objects = new List<Vector3>(objectCount);
            for (int i = 0; i < objectCount; i++)
            {
                var position = new Vector3(xLocation.Sample(), yLocation.Sample(), depth);

                bool shouldPlace = true;
                foreach (var o in objects)
                {
                    var distance = (position - o).magnitude;
                    var deviations = Math.Abs(position.x) / ((NormalSampler)xLocation.value).standardDeviation;
                    deviations += Math.Abs(position.y) / ((NormalSampler)yLocation.value).standardDeviation;
                    deviations /= 2;
                    if (distance < deviations)
                    {
                        shouldPlace = false;
                        break;
                    }
                }

                if (!shouldPlace)
                {
                    i--;
                    continue;
                }
                objects.Add(position);

                var instance = m_GameObjectOneWayCache.GetOrInstantiate(prefabs.Sample());
                instance.transform.position = position;
            }
        }

        /// <summary>
        /// Deletes generated foreground objects after each scenario iteration is complete
        /// </summary>
        protected override void OnIterationEnd()
        {
            m_GameObjectOneWayCache.ResetAllObjects();
        }
    }
}
