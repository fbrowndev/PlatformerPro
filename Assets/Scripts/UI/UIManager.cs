using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] private TMPro.TMP_Text _scoreText;
    [SerializeField] private TMPro.TMP_Text _healthText;
    

    public void UpdateCoinDisplay(int coins)
    {
        _scoreText.text = coins.ToString();
    }

    public void UpdateHealthDisplay(int health)
    {
        _healthText.text = health.ToString();
    }
}
