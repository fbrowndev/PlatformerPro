using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    #region Coin Variables
    [Header("Coin Settings")]
    [SerializeField] private int _coinValue;

    #endregion


    //will handle giving the player a coin
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.AddCoins(_coinValue);
            }

            Destroy(this.gameObject);
        }
    }
}
