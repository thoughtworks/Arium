using UnityEngine;
using UnityEngine.UI;

namespace AriumFramework.Plugins.UnityCore.Extensions
{
    public static class TextUtils
    {
        public static string GetText(this GameObject gameObject)
        {
            return new GameObjectWrapper(gameObject).GetComponent<Text>().text;
        }
    }
}