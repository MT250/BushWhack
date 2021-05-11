using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreValueTMP;

    private void Update()
    {
        var score = GameManager.instance.GetScore();
        ScoreValueTMP.text = score.ToString("0,000,000");
    }
}
