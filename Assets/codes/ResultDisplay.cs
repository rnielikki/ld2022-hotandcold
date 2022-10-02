using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.codes
{
    public class ResultDisplay : MonoBehaviour
    {
        [SerializeField]
        TextMeshProUGUI _timeText;
        [SerializeField]
        private Button _restartButton;
        [SerializeField]
        private Button _nextLevelButton;

        public void DisplayResult(float time, bool isLastLevel)
        {
            _timeText.text = System.TimeSpan.FromSeconds(time).ToString(@"hh\:mm\:ss");
            gameObject.SetActive(true);
            if (isLastLevel)
            {
                _nextLevelButton.gameObject.SetActive(true);
                _nextLevelButton.Select();
            }
            else
            {
                _nextLevelButton.gameObject.SetActive(false);
                _restartButton.Select();
            }
        }
    }
}