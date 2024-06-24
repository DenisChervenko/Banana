using TMPro;
using UnityEngine;
using DG.Tweening;
using Zenject;
using System.Text;
public class TapController : MonoBehaviour
{
    [Header("Banana Option")]
    [SerializeField] private GameObject _bananaSprite;
    [SerializeField] private float _durationScale;
    [SerializeField] private float _scaleFactor;

    [SerializeField] private TMP_Text _scoreCounter;
    private StringBuilder _stringBuilder;
    private int _score;



    [Inject] private EventController _eventController;

    private void Start() => _stringBuilder = new StringBuilder();

    public void OnClickScreen()
    {
        _score = _eventController.onBananaTap.Invoke();

        _stringBuilder.Clear();
        _stringBuilder.Append(_score);
        _scoreCounter.text = _stringBuilder.ToString();

        _bananaSprite.transform.DOScale(_scaleFactor, _durationScale).OnComplete(() => 
        _bananaSprite.transform.DOScale(1, _durationScale));

        if(_score % 10 == 0)
            if(Random.Range(0, 100) > 70)
                _eventController.onBananaReward?.Invoke();

        if(_score % 100 == 0)
            _eventController.onYGshowAds?.Invoke();
    }
}
