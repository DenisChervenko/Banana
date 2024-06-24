using UnityEngine;
using Zenject;

public class OnInventoryOpen : MonoBehaviour
{
    [Inject] private EventController _eventController;

    public void OnInventoryOpened() => _eventController.onBananaStopNotice.Invoke();
}
