using Interfaces;
using UnityEngine;

public class PlayerController : MonoBehaviour, ITransformComponent
{
    [SerializeField]
    private float _turnSpeed;
    [SerializeField]
    private float _movementSpeed;

    private bool _isMoving;

    public Transform TransformComponent { get; set; }

    private void Awake()
    {
        (this as ITransformComponent).Init();
    }

    private void Update()
    {
        UpdateTurnAngle();
        UpdateMovementTranslation();
    }

    private void UpdateTurnAngle()
    {
        // If we are not moving, we can't turn
        if (!_isMoving)
        {
            return;
        }
        
        // Calculate and apply turn angle
        var axis = GetInputAxis(true);
        var turnAngle = GetTurnAngle(axis);
        
        TransformComponent.Rotate(Vector3.up, turnAngle);
    }

    private static float GetInputAxis(bool isHorizontal)
    {
        const string verticalAxis = "Vertical";
        const string horizontalAxis = "Horizontal";
        
        var axisName = isHorizontal
            ? horizontalAxis
            : verticalAxis;
        
        return Input.GetAxis(axisName);
    }
    
    private float GetTurnAngle(float axis)
    {
        return axis * _turnSpeed * Time.deltaTime;
    }

    private void UpdateMovementTranslation()
    {
        // If we are not moving, we can't calculate movement
        const float minimalMovementValue = 0.1f;
        var axis = GetInputAxis(false);
        _isMoving = Mathf.Abs(axis) > minimalMovementValue;
        
        if (!_isMoving)
        {
            return;
        }
        
        // Calculate and apply movement
        var movementTranslation = GetMovementTranslation(axis);
        
        TransformComponent.Translate(movementTranslation);
    }

    private Vector3 GetMovementTranslation(float axis)
    {
        return Vector3.forward * (axis * _movementSpeed * Time.deltaTime);
    }
}