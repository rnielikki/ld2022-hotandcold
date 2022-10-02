using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    PlayerInput _input;
    [SerializeField]
    Rigidbody2D _body;
    InputAction _action;
    InputAction _jumpAction;
    [SerializeField]
    float _power;
    [SerializeField]
    float _maxSpeed;
    [SerializeField]
    float _jumpPower;
    int _jumpCount;
    const int _maxJumpCount = 2;
    [Header("Sound")]
    [SerializeField]
    AudioSource _audioSource;
    [SerializeField]
    AudioClip _jumpSound;
    // Start is called before the first frame update
    void Start()
    {
        _action = _input.actions.FindAction("Player/Move");
        _jumpAction = _input.actions.FindAction("Player/Jump");
        _input.actions.Enable();
        _action.Enable();
        _jumpAction.Enable();
        _jumpAction.performed += Jump;
    }

    private void Jump(InputAction.CallbackContext obj)
    {
        if (_jumpCount < _maxJumpCount)
        {
            _jumpCount++;
            _body.AddForce(_jumpPower * Vector2.up);
            _audioSource.PlayOneShot(_jumpSound);
        }
    }

    private void AddForce(float val)
    {
        if (Mathf.Abs(_body.velocity.magnitude) < _maxSpeed)
        {
            _body.AddForce(val * _power * Vector2.right);
            _body.velocity = Vector2.ClampMagnitude(_body.velocity, _maxSpeed);
        }
        //transform.position += val * Time.deltaTime * Vector3.right;
    }
    private void FixedUpdate()
    {
        if (_action.IsPressed())
        {
            AddForce(_action.ReadValue<float>());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _jumpCount = 0;
    }
    private void OnDestroy()
    {
        _jumpAction.performed -= Jump;
    }
}
