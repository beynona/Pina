using UnityEngine;

public class JoystickForMovement : JoystickHandler
{
    [SerializeField] private CharacterMovement characterMovement;

    private void Update()
    {
        if (InputVector.x != 0 || InputVector.y != 0)
        {
            characterMovement.MoveCharacter(new Vector3(InputVector.x, 0, InputVector.y));
            characterMovement.RotateCharacter(new Vector3(InputVector.x, 0, InputVector.y));
        }
        else
        {
            characterMovement.MoveCharacter(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
            characterMovement.RotateCharacter(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));
        }
    }
}
