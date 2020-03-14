using UnityEngine.UI;

namespace AriumFramework
{
    public static class TextUtils
    {
        public static string GetText(this GameObjectWrapper objectWrapper)
        {
            return objectWrapper.GetComponent<Text>().text;
        }
    }
}