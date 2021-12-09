using System;
using UnityEngine;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers.SampleRandomizers.Tags;
using UnityEngine.Perception.Randomization.Samplers;

using System.Linq;
using UnityEngine.Perception.Randomization.Randomizers.Utilities;

namespace UnityEngine.Perception.Randomization.Randomizers.SampleRandomizers
{
    /// <summary>
    /// Randomizes the shader graph texture of objects tagged with a ShaderGraphTextureRandomizerTag
    /// </summary>
    [Serializable]
    [AddRandomizerMenu("Perception/Shader Graph Texture Randomizer")]
    public class ShaderGraphTextureRandomizer : Randomizer
    {
        FloatParameter m_FloatParameter = new FloatParameter { value = new UniformSampler(0, 360) };

        /// <summary>
        /// The list of textures to sample and apply to tagged objects
        /// </summary>
        public Texture2DParameter albedoTexture;
        public Texture2DParameter normalTexture;
        public Texture2DParameter maskTexture;
        public float hueTop = 0.0f;
        public float hueBottom = 0.0f;
        public MaterialParameter characterMaterial;

        /// <summary>
        /// Randomizes the material texture of tagged objects at the start of each scenario iteration
        /// </summary>
        protected override void OnIterationStart()
        {
            foreach (var tag in characterMaterial.categories)
            {
                Material material = tag.Item1;
                material.SetTexture("Texture2D_D27E6D66", albedoTexture.Sample());
                material.SetTexture("Texture2D_A2664602", maskTexture.Sample());
                material.SetTexture("Texture2D_A8936B7E", normalTexture.Sample());
                material.SetFloat("Vector1_46FBBF67", m_FloatParameter.Sample());
                material.SetFloat("Vector1_4EA3F53", m_FloatParameter.Sample());

            }
        }

    }
}
