using TMPro;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    // Игрок
    [SerializeField] private GameObject _player;
    // Расстояние для обнаружения
    [SerializeField, Range(5,15)] private float _minimalDistanceDetection = 10.0f;
    // Расстояние до игрока
    private float _distanceToPlayer;

    private Vector3 _enemyPosition;
    private Vector3 _directionToPlayer;
    
    [SerializeField] private TextMeshProUGUI distanceDisplay;
    
    void Start()
    {
        // Враг стоит на месте
        _enemyPosition = transform.position;
    }


    void Update()
    {
        // Направление на игрока (вычесть из положения игрока позицию противника)
        _directionToPlayer = _player.transform.position - _enemyPosition;
        // Модуль этого вектора
        _distanceToPlayer = _directionToPlayer.magnitude;

        distanceDisplay.text = _distanceToPlayer.ToString("0.0" + "m");
        

        if (_distanceToPlayer < _minimalDistanceDetection)
        {
            distanceDisplay.color = Color.red;
        }
        else
        {
            distanceDisplay.color = Color.green;
        }

    }
}
