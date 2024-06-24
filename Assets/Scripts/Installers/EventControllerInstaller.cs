using UnityEngine;
using Zenject;

public class EventControllerInstaller : MonoInstaller
{
    [SerializeField] private EventController _eventController;
    public override void InstallBindings()
    {
        Container.Bind<EventController>().FromInstance(_eventController).AsSingle().NonLazy();
    }
}