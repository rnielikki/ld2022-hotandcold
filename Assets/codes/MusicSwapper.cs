using UnityEngine;

namespace Assets.codes
{
    public class MusicSwapper : MonoBehaviour
    {
        [SerializeField]
        AudioSource _musicSource;
        [SerializeField]
        AudioClip _music1;
        [SerializeField]
        AudioClip _music2;
        bool _isMusic1;
        private void Start()
        {
            ResetMusic();
        }
        public void ChangeMusic()
        {
            _isMusic1 = !_isMusic1;
            _musicSource.clip = _isMusic1 ? _music1 : _music2;
            _musicSource.Play();
        }
        public void ResetMusic()
        {
            _musicSource.clip = _music1;
            _isMusic1 = true;
            _musicSource.Play();
        }
    }
}