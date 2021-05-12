using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] float score;
    [SerializeField] UIManager UIManager;


    private void Start()
    {
        instance = this;
    }

    public void AddScore(float _value)
    {
        score += _value;
    }

    public int GetScore()
    {
        return Mathf.FloorToInt(score);
    }

    private GameManager()
    {}
}
