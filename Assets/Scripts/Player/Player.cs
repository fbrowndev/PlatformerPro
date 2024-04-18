using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Player Variables
    [Header("Movement Settings")]
    [SerializeField]private float _moveSpeed = 2f;

    //Components
    private CharacterController _characterController;

    #endregion



    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    #region Movement Logic
    //Player Movement method
    void PlayerMovement()
    {
        //horizontal input
        float _horizontalInput = Input.GetAxis("Horizontal");
        Vector3 _moveDirection = new Vector3(_horizontalInput, 0,0);
        Vector3 _playerVelocity = _moveDirection * _moveSpeed;

        _characterController.Move(_playerVelocity * Time.deltaTime);

    }
    #endregion

}
