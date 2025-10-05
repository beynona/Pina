using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayDamage : MonoBehaviour
{
    // Заранее приготовленный префаб текста
    [SerializeField] private TextMesh textPrefab;
    // Точка где создаём наш текст
    [SerializeField] private Transform spawnPoint;
    // Смещение для отображение текста
    private float _offset;
    [SerializeField] private float minOffset;
    [SerializeField] private float maxOffset;

    public void SetDamage(int value)
    {
        _offset = Random.Range(minOffset, maxOffset);

        var position = spawnPoint.position;
        var textPosition = new Vector3(position.x + _offset, position.y + _offset, position.z + _offset);

        var _text = Instantiate(textPrefab, textPosition, Quaternion.identity);

        _text.text = value.ToString();
    }
}
