using UnityEngine;

public class FolowingCamera : MonoBehaviour
{
    [Header("Object for following")] 
    [SerializeField] private GameObject _mainCharacter;
    
    [Header("Camera properties")] 
    // Скорость следования
    [SerializeField] private float _returnSpeed;
    // Высота
    [SerializeField] private float _height;
    // Приближение
    [SerializeField] private float _rearDistance;

    void Start()
    {
        var heroPosition = _mainCharacter.transform.position;

        var cameraPosition = new Vector3(heroPosition.x,heroPosition.y + _height, heroPosition.z - _rearDistance);
        transform.rotation = Quaternion.LookRotation(heroPosition - cameraPosition);
    }
    
    void Update()
    {
        var position = _mainCharacter.transform.position;
        Vector3 currentVector = new Vector3(position.x,position.y + _height, position.z - _rearDistance);
        transform.position = Vector3.Lerp(transform.position,currentVector,_returnSpeed * Time.deltaTime);
    }
}
