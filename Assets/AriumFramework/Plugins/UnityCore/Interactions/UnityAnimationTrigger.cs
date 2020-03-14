using UnityEngine;

namespace AriumFramework.Plugins.UnityCore.Interactions
{
    public class UnityAnimationTrigger: Interaction<Animator>
    {
        public string ParameterName;
        
        public UnityAnimationTrigger(string parameterName)
        {
            ParameterName = parameterName;
            SetAction(Trigger);
        }

        private void Trigger(Animator animator)
        {
            animator.SetTrigger(ParameterName);
        }
    }
}