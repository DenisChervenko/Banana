using UnityEngine.Events;
using UnityEngine;
public class EventController : MonoBehaviour
{
    public UnityAction onYGshowAds;

    public UnityAction onBananaStartNotice;
    public UnityAction onBananaStopNotice;

    public UnityAction onBananaReward;
    public UnityAction onBananaSort;

    public delegate int OnBananaTap();
    public OnBananaTap onBananaTap;

    public delegate void OnBananaGet(BananaBase banana);
    public OnBananaGet onBananaGet;

    public delegate void OnBananaSale(int bananaPrice);
    public OnBananaSale onBananaSale;

    public delegate void OnBananShow(BananaBase bananaBase);
    public OnBananShow onBananaShow;
}
