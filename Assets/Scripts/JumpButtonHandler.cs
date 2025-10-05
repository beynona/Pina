using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButtonHandler : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private CharacterJumpHandler _characterJumpHandler;
    public void OnPointerDown(PointerEventData eventData)
    {
        _characterJumpHandler.HandleJump();
    }
}
