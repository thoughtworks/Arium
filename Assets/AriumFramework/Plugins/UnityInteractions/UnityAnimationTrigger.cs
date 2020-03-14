using UnityEngine;

namespace AriumFramework.Plugins.UnityInteractions
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