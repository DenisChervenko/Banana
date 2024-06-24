using UnityEngine;
using YG;
using Zenject;

public class YGadsClick : MonoBehaviour
{
    [Inject] private EventController _eventController;

    private void ShowAds() => YandexGame.FullscreenShow();

    private void OnEnable() => _eventController.onYGshowAds += ShowAds;
    private void OnDisable() => _eventController.onYGshowAds -= ShowAds;
}
