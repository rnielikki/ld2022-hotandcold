using UnityEngine;

namespace Assets.codes
{
    public class LifeCalculator : MonoBehaviour
    {
        [SerializeField]
        GameObject _life;
        [SerializeField]
        RectTransform _attachTarget;
        [SerializeField]
        int _amountOfLife;
        int _currentLife;
        GameObject[] _lives;
        [SerializeField]
        GameObject _gameOverScreen;
        [SerializeField]
        UnityEngine.UI.Button _restartButton;
        [SerializeField]
        LevelLoader _levelLoader;
        private void Start()
        {
            _lives = new GameObject[_amountOfLife];
            for (int i = 0; i < _amountOfLife; i++)
            {
                _lives[i] = Instantiate(_life, _attachTarget);
            }
            RestoreLife();
            _restartButton.onClick.AddListener(()=>_gameOverScreen.SetActive(false));
        }
        public void RestoreLife()
        {
            _currentLife = _amountOfLife;
            for (int i = 0; i < _amountOfLife; i++)
            {
                _lives[i].SetActive(true);
            }
        }
        public void LoseLife()
        {
            if (_currentLife <= 0) return;
            _currentLife--;
            _lives[_currentLife].gameObject.SetActive(false);
            if (_currentLife <= 0)
            {
                //game over;
                _restartButton.Select();
                _levelLoader.GameOver();
                StartCoroutine(nameof(ShowGameOverScreen));
            }
        }
        private System.Collections.IEnumerator ShowGameOverScreen()
        {
            yield return new WaitForSecondsRealtime(2);
            _gameOverScreen.SetActive(true);
        }
    }
}