using UnityEngine;
using Zenject;

public class BananaReward : MonoBehaviour
{
    [SerializeField] private BananaBase[] _bananaCommon;
    [SerializeField] private BananaBase[] _bananaUncommon;
    [SerializeField] private BananaBase[] _bananaRare;
    [SerializeField] private BananaBase[] _bananaEpic;
    [SerializeField] private BananaBase[] _bananaLegendary;

    [Inject] private EventController _eventController;


    private void GiveReward()
    {
        float chance = Random.Range(0, 101);

        if (chance > 99.5f)
            _eventController.onBananaGet?.Invoke(_bananaLegendary[Random.Range(0, _bananaLegendary.Length)]);
        else if (chance > 95)
            _eventController.onBananaGet?.Invoke(_bananaEpic[Random.Range(0, _bananaEpic.Length)]);
        else if (chance > 85)
            _eventController.onBananaGet?.Invoke(_bananaRare[Random.Range(0, _bananaRare.Length)]);
        else if (chance > 75)
            _eventController.onBananaGet?.Invoke(_bananaUncommon[Random.Range(0, _bananaUncommon.Length)]);
        else
            _eventController.onBananaGet?.Invoke(_bananaCommon[Random.Range(0, _bananaCommon.Length)]);
    }

    private void OnEnable() => _eventController.onBananaReward += GiveReward;
    private void OnDisable() => _eventController.onBananaReward -= GiveReward;
}
