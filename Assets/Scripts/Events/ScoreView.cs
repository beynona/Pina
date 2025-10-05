using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;
    // Шаблон текста
    [SerializeField] private string template;

    private void Awake()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void SetScore(int value)
    {
        _scoreText.text = string.Format(template, value);
    }
}
