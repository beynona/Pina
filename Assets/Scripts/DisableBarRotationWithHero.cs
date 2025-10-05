using UnityEngine;

public class DisableBarRotationWithHero : MonoBehaviour
{
    private Camera _camera;
    private void Start()
    {
        _camera = Camera.main;
    }

    private void LateUpdate()
    {
        Vector3 cameraPosition = _camera.transform.position;
        // Реализовано в LateUpdate для фикса при резких поворотов, так как LateUpdate срабатывает после обычного Update
        // Хп-бар подстраивается под камеру и повороты персонажа по оси y и z
        transform.LookAt(new Vector3(transform.position.x, cameraPosition.y, cameraPosition.z));
        transform.Rotate(0, 180, 0);
    }
}
