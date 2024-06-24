using DG.Tweening;
using UnityEngine;
using Zenject;

public class CanvasChanger : MonoBehaviour
{
    [SerializeField] private CanvasGroup _currentCanvas;
    [SerializeField] private CanvasGroup _targetCanvas;

    [SerializeField] private float _durationFade;
    public void ChangeCanvas()
    {
        _currentCanvas.interactable = false;
        _currentCanvas.blocksRaycasts = false;
        _currentCanvas.DOFade(0, _durationFade).OnComplete(() => _targetCanvas.DOFade(1, _durationFade));
        _targetCanvas.interactable = true;
        _targetCanvas.blocksRaycasts = true;
    } 
}
