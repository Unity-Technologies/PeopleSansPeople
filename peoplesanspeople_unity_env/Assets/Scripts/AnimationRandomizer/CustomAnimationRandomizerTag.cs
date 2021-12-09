using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.GroundTruth;

namespace UnityEngine.Perception.Randomization.Randomizers.SampleRandomizers.Tags
{
    /// <summary>
    /// Used in conjunction with a <see cref="CustomAnimationRandomizer"/> to select a random animation frame for
    /// the tagged game object
    /// </summary>
    [RequireComponent(typeof(Animator))]
    [AddComponentMenu("Perception/RandomizerTags/Custom Animation Randomizer Tag")]
    public class CustomAnimationRandomizerTag : RandomizerTag
    {
        /// <summary>
        /// A list of animation clips from which to choose
        /// </summary>
        public AnimationClipParameter animationClips;

        /// <summary>
        /// Apply the root motion to the animator. If true, if an animation has a rotation translation and/or rotation
        /// that will be applied to the labeled model, which means that the model maybe move to a new position.
        /// If false, then the model will stay at its current position/rotation.
        /// </summary>
        public bool applyRootMotion = false;

        /// <summary>
        /// Gets the animation override controller for an animation randomization. The controller is loaded from
        /// resources.
        /// </summary>
        public AnimatorOverrideController animatorOverrideController
        {
            get
            {
                if (m_Controller == null)
                {
                    var animator = gameObject.GetComponent<Animator>();
                    var runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("AnimationRandomizerController");
                    m_Controller = new AnimatorOverrideController(runtimeAnimatorController);
                    animator.runtimeAnimatorController = m_Controller;
                }

                return m_Controller;
            }
        }

        AnimatorOverrideController m_Controller;
    }
}
