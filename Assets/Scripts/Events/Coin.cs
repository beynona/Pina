using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Coin : MonoBehaviour
{
    private int _reward;
    [SerializeField] private int maxReward;
    [SerializeField] private int minReward;
    
    void Start()
    {
        _reward = Random.Range(minReward, maxReward);
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay Coin");
        if (other.TryGetComponent(out CharacterMovement _))
        {
            Debug.Log("OnTriggerStay Coin - try get component");
            EventManager.CallCoinPickedUp(_reward);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter Coin");
        if (other.TryGetComponent(out CharacterMovement _))
        {
            Debug.Log("OnTriggerEnter Coin - try get component");
            EventManager.CallCoinPickedUp(_reward);
            Destroy(gameObject);
        }
    }
}
