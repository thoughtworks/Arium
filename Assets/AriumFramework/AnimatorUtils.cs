using UnityEngine;

namespace AriumFramework
{
    public static class AnimatorUtils
    {
        public static bool IsInAnimationState(this GameObjectWrapper gameObject, string animationState,
            int layerIndex = 0)
        {
            return gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(layerIndex).IsName(animationState);
        }
    }
}