using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(CharacterMovement))]
public class CharacterJumpHandler : MonoBehaviour
{
    [Header("Jump Stats")] 
    [SerializeField] private float maxJumpTime; // Время прыжка
    [SerializeField] private float maxJumpHeight; // Максимальная высота прыжка
    private float startJumpVelocity; // Начальная скорость
    
    [Header("Character Components")] 
    private CharacterMovement _characterMovement;
    private CharacterController _characterController;

    void Start()
    {
        _characterMovement = GetComponent<CharacterMovement>();
        _characterController = GetComponent<CharacterController>();

        // Время в котором прыжок достигает максимума
        float maxHeightTime = maxJumpTime / 2;
        // Рассчитываем силу гравитации
        _characterMovement.GravityForce = (2 * maxJumpHeight) / Mathf.Pow(maxHeightTime, 2);
        // Начальная скорость при прыжке
        startJumpVelocity = (2 * maxJumpHeight) / maxHeightTime;
    }

    // Вызываем по нажатию кнопки
    public void HandleJump() 
    {
        Debug.Log("HandleJump");
        if (_characterController.isGrounded)
        {
            _characterMovement.velocityDirection.y = startJumpVelocity;

            _characterController.Move(_characterMovement.velocityDirection * Time.deltaTime);
        }
    }
}
