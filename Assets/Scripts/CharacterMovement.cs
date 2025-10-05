using UnityEngine;
using UnityEngine.Serialization;

// Обязательное наличие на объекте CharacterController
[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Character movement stats")] 
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    
    [HideInInspector] 
    public Vector3 velocityDirection;
    
    private CharacterController _characterController;

    private float _gravityForce = 9.8f; // Сила притяжения

    public float GravityForce
    {
        set
        {
            if (value > 0) _gravityForce = value;
        }
    }
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        GravityHandling();
    }

    public void MoveCharacter(Vector3 moveDirection)
    {
        velocityDirection.x = moveDirection.x * _moveSpeed;
        velocityDirection.z = moveDirection.z * _moveSpeed;
        _characterController.Move(velocityDirection * Time.deltaTime);
    }

    public void RotateCharacter(Vector3 moveDirection)
    {
        if (Vector3.Angle(transform.forward, moveDirection) > 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, moveDirection, _rotateSpeed, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }

    private void GravityHandling()
    {
        if (!_characterController.isGrounded)
        {
            velocityDirection.y -= _gravityForce * Time.deltaTime;
        }
        else
        {
            // С маленькой силой притягиваемся к земле, чтобы быть уверенными, что мы точно на земле
            velocityDirection.y = -0.5f;
        }
    }
}
