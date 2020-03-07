using UnityEngine;
using UnityEngine.Events;

namespace AriumFramework.Plugins.UnityInteractions
{
    public class UnityPushObject : Interaction<Rigidbody>
    {
        public static Vector3 Force;
        
        public UnityPushObject() : base(Push)
        {
        }

        private static void Push(Rigidbody body)
        {
            body.AddForce(Force);
        }
    }
}