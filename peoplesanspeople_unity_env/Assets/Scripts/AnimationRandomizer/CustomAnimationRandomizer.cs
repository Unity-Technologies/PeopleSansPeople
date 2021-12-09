using System;
using UnityEngine;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers.SampleRandomizers.Tags;
using UnityEngine.Perception.Randomization.Samplers;

namespace UnityEngine.Perception.Randomization.Randomizers.SampleRandomizers
{
    /// <summary>
    /// Chooses a random of frame of a random clip for a game object
    /// </summary>
    [Serializable]
    [AddRandomizerMenu("Perception/Custom Animation Randomizer")]
    public class CustomAnimationRandomizer : Randomizer
    {
        FloatParameter m_FloatParameter = new FloatParameter { value = new UniformSampler(0, 1) };

        const string k_ClipName = "PlayerIdle";
        const string k_StateName = "Base Layer.RandomState";

        void RandomizeAnimation(CustomAnimationRandomizerTag tag)
        {
            var animator = tag.gameObject.GetComponent<Animator>();
            animator.applyRootMotion = tag.applyRootMotion;

            //AnimatorClipInfo[] m_AnimatorClipInfo;

            var overrider = tag.animatorOverrideController;
            if (overrider != null && tag.animationClips.GetCategoryCount() > 0)
            {
                overrider[k_ClipName] = tag.animationClips.Sample();
                animator.Play(k_StateName, 0, m_FloatParameter.Sample());

                ////// Debug Animation name:

                ///// name of selected animation
                //Debug.Log(overrider[k_ClipName]);

                ///// Get the animator clip information from the Animator Controller
                //m_AnimatorClipInfo = animator.GetCurrentAnimatorClipInfo(0);
                ///// Output the name of the starting clip
                //Debug.Log("Starting clip : " + m_AnimatorClipInfo[0].clip);
            }
        }

        /// <inheritdoc/>
        protected override void OnIterationStart()
        {
            if (m_FloatParameter == null) m_FloatParameter = new FloatParameter { value = new UniformSampler(0, 1) };

            var taggedObjects = tagManager.Query<CustomAnimationRandomizerTag>();
            foreach (var taggedObject in taggedObjects)
            {
                RandomizeAnimation(taggedObject);
            }
        }
    }
}
