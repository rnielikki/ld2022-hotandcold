using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.codes
{
    public class PlayerStatus : MonoBehaviour
    {
        bool _isFire;
        public bool IsFire => _isFire;
        [SerializeField]
        PlayerInput _playerInput;
        InputAction _action;
        [SerializeField]
        LifeCalculator _lifeCalculator;
        [Header("Status change")]
        [SerializeField]
        SpriteRenderer _renderer;
        [SerializeField]
        Color _fireColor;
        [SerializeField]
        Color _iceColor;
        [SerializeField]
        Animator _animator;
        [SerializeField]
        ParticleSystem _particle;
        bool _staying;
        bool _isChangeEnabled;
        private int _iceHash;
        private int _fireHash;
        [Header("Sound")]
        [SerializeField]
        AudioSource _audioSource;
        [SerializeField]
        AudioClip _changeSound;
        [SerializeField]
        AudioClip _hurtSound;

        // Use this for initialization
        void Start()
        {
            _renderer.color = _fireColor;
            _isFire = true;
            _action = _playerInput.actions.FindAction("Player/Switch");
            _fireHash = Animator.StringToHash("player-fire");
            _iceHash = Animator.StringToHash("player-ice");
            var particleMain = _particle.main;
            particleMain.useUnscaledTime = true;
            EnableChange();
        }
        void Change(InputAction.CallbackContext context)
        {
            if (_staying) return;
            _isFire = !_isFire;
            _renderer.color = _isFire?_fireColor:_iceColor;
            _animator.Play(_isFire ? _fireHash : _iceHash);
            _audioSource.PlayOneShot(_changeSound);
        }
        public void EnableChange()
        {
            if (_isChangeEnabled || _action == null) return;
            _action.performed += Change;
            _isChangeEnabled = true;
        }
        public void DisableChange()
        {
            _action.performed -= Change;
            _isChangeEnabled = false;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            bool isWallFire = collision.gameObject.CompareTag("Fire");
            bool isWallIce = collision.gameObject.CompareTag("Ice");
            if ((_isFire && isWallIce)
                || (!IsFire && isWallFire)
                )
            {
                _particle.Play();
                _audioSource.PlayOneShot(_hurtSound);
                _lifeCalculator.LoseLife();
            }
            else if(isWallFire || isWallIce) _staying = true;
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Fire") || collision.gameObject.CompareTag("Ice"))
            {
                _staying = false;
            }
        }
    }
}