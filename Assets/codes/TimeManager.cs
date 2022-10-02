using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    UnityEvent _onTime;
    [SerializeField]
    RectTransform _transform;
    //Relliable for "acutally counting time"
    private float _timeLeft = 10;
    // Start is called before the first frame update
    private void Update()
    {
        _timeLeft -= Time.deltaTime;
        if (_timeLeft <= 0)
        {
            _timeLeft += 10;
            _onTime.Invoke();
        }
        UpdateAnchor();
    }
    public void ResetTimer()
    {
        _timeLeft = 10;
        UpdateAnchor();
    }
    private void UpdateAnchor()
    {
        var anc = _transform.anchorMax;
        anc.x = _timeLeft * 0.1f;
        _transform.anchorMax = anc;
    }
}
