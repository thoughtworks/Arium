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
        public static bool IsGameObejectColliderEnabled(this GameObject gameObject)
        {
            return new GameObjectWrapper(gameObject).GetComponent<BoxCollider>().enabled;
        }
        
        public static string GetImageSourceName(this GameObject gameObject)
        {
            return new GameObjectWrapper(gameObject).GetComponent<Image>().sprite.name;
        }
    }
}