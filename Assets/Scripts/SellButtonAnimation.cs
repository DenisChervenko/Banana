using DG.Tweening;
using UnityEngine;

public class SellButtonAnimation : MonoBehaviour
{
    private void OnEnable() => gameObject.transform.DOScale(0.8f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
}
