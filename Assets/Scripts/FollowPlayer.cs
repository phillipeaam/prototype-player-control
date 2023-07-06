using Interfaces;
using UnityEngine;

public class FollowPlayer : MonoBehaviour, ITransformComponent
{
    [SerializeField]
    private Vector3 _positionOffset;
    [SerializeField]
    private PlayerController _playerController;

    public Transform TransformComponent { get; set; }

    private void Awake()
    {
        (this as ITransformComponent).Init();
    }

    private void LateUpdate()
    {
        UpdateRelativeToPlayerPosition();
    }

    private void UpdateRelativeToPlayerPosition()
    {
        TransformComponent.position = _playerController.TransformComponent.position + _positionOffset;
    }
}