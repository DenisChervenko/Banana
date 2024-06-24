using UnityEngine;
using System.Text;
using TMPro;
using Zenject;
using System.Collections;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreCounter;
    [SerializeField] private int _tapModifier;
    [Inject] private EventController _eventController;
    private int _score;

    private StringBuilder _stringBuilder;

    private void Start() => _stringBuilder = new StringBuilder();

    public void SaleAddScore(int modifier)
    {
        _score += modifier;

        _stringBuilder.Clear();
        _stringBuilder.Append(_score);
        _scoreCounter.text = _stringBuilder.ToString();
    } 
    public int TapAddScore() 
    {
        _score += _tapModifier;
        return _score;
    } 

    public bool RemoveScore(int modifier)
    {
        if(modifier > _score)
            return false;
        else
            return true;
    }

    private void OnEnable() 
    {
        _eventController.onBananaSale += SaleAddScore;
        _eventController.onBananaTap += TapAddScore;
    }
    private void OnDisable()
    {
        _eventController.onBananaSale -= SaleAddScore;
        _eventController.onBananaTap -= TapAddScore;
    }
}
