using UnityEngine;

namespace AriumFramework.Plugins.UnityCore.Extensions
{
    public static class AnimatorUtils
    {
        public static bool IsInAnimationState(this GameObject gameObject, string animationState,
            int layerIndex = 0)
        {
            return new GameObjectWrapper(gameObject).GetComponent<Animator>().GetCurrentAnimatorStateInfo(layerIndex).IsName(animationState);
        }
    }
}