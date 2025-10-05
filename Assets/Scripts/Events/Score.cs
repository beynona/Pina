using System;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int _score;
    [SerializeField] private ScoreView scoreView;

    private void Awake()
    {
        // AddListener - подписка на unity евент
        EventManager.CoinPickedUp.AddListener(Increase);
    }

    void Start()
    {
        _score = 0;
    }
    
    private void Increase(int value)
    {
        _score += value;
        scoreView.SetScore(_score);
    }
}
