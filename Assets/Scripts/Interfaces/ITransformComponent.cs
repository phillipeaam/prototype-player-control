using UnityEngine;

namespace Interfaces
{
    public interface ITransformComponent
    {
        public void Init()
        {
            TransformComponent ??= (this as MonoBehaviour)?.transform;
        }

        public Transform TransformComponent { get; set; }
    }
}