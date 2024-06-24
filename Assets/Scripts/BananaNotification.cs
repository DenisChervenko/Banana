using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BananaNotification : MonoBehaviour
{
    [SerializeField] private Image _notificationMark;
    [Inject] private EventController _eventController;

    private void NotificationActive() => _notificationMark.enabled = true;
    private void NotificationDisable() => _notificationMark.enabled = false;

    private void OnEnable()
    {
        _eventController.onBananaStartNotice += NotificationActive;
        _eventController.onBananaStopNotice += NotificationDisable;
    } 
    private void OnDisable()
    {
        _eventController.onBananaStartNotice -= NotificationActive;
        _eventController.onBananaStopNotice -= NotificationDisable;
    }
}
