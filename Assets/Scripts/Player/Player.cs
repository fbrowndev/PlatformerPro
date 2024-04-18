using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Player Variables
    [Header("Movement Settings")]
    [SerializeField] private float _moveSpeed = 2f;
    [SerializeField] private float _jumpHeight = 15f;
    [SerializeField] private float _doubleJumpMultiplier = 1.5f;
    [SerializeField] private float _gravity = 1.0f;

    private bool _canDoubleJump;

    //Cached values
    private float _yVelocity;

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

        if(_characterController.isGrounded)
        {
            //player jump
            if(Input.GetKeyDown(KeyCode.Space))
            {
                _yVelocity = _jumpHeight;
                _canDoubleJump = true;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                if (_canDoubleJump == true)
                {
                    _yVelocity += _jumpHeight * _doubleJumpMultiplier;
                    _canDoubleJump = false;
                }    
            }
            _yVelocity -= _gravity;
        }

        _playerVelocity.y = _yVelocity;
        _characterController.Move(_playerVelocity * Time.deltaTime);
    }
    #endregion

}