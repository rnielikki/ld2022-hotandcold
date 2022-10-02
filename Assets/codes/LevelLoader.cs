using UnityEngine;
using UnityEngine.Events;

namespace Assets.codes
{
    public class LevelLoader : MonoBehaviour
    {
        [SerializeField]
        GameObject[] _levels;
        private GameObject _current;
        private ITileManager[] _tileManagers;
        [SerializeField]
        Transform _player;
        Vector3 _playerDefaultPosition;
        float _clearTime;
        private int _currentLevel;
        [SerializeField]
        ResultDisplay _resultDisplay;
        [SerializeField]
        UnityEvent<bool> _onLevelEnded;
        [SerializeField]
        UnityEvent _onLevelStarted;
        // Use this for initialization
        void Start()
        {
            _playerDefaultPosition = _player.transform.position;
            LoadLevel(0);
        }
        public void ShowResult()
        {
            Time.timeScale = 0;
            _resultDisplay.DisplayResult(_clearTime, _currentLevel + 1 < _levels.Length);
            _onLevelEnded.Invoke(true);
        }
        public void GameOver()
        {
            Time.timeScale = 0;
            _onLevelEnded.Invoke(false);
        }
        public void RestartLevel() => LoadLevel(_currentLevel);
        public void NexttLevel()
        {
            if (_currentLevel + 1 < _levels.Length)
            {
                LoadLevel(_currentLevel + 1);
            }
        }
        private void LoadLevel(int levelIndex)
        {
            if (levelIndex >= 0 && levelIndex < _levels.Length)
            {
                _resultDisplay.gameObject.SetActive(false);
                Time.timeScale = 1;
                _clearTime = 0;
                _player.transform.position = _playerDefaultPosition;
                if (_current != null) Destroy(_current);
                _current = Instantiate(_levels[levelIndex]);
                _tileManagers = _current.GetComponentsInChildren<ITileManager>();
                _currentLevel = levelIndex;
                var trigger = _current.GetComponentInChildren<GoalTrigger>();
                trigger.Init(this);
                _onLevelStarted.Invoke();
            }
        }
        public void ChangeTileStatuses()
        {
            if (_current == null) return;
            foreach (var tileManager in _tileManagers)
            {
                tileManager.ChangeStatus();
            }
        }
        private void Update()
        {
            _clearTime += Time.deltaTime;
            if (_clearTime < 0)
            {
                _clearTime = float.MaxValue;
            }
        }
    }
}