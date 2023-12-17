using UnityEngine;
using DG.Tweening;

public class Explosion : MonoBehaviour
{
    public float explodeDuration = 3;
    public Ease explodeEase = Ease.OutElastic;

    public float implosionDuration = 0.3f;
    public Ease implosionEase = Ease.OutExpo;

    void Start()
    {

        transform
        .DOScale(Vector3.one * 5, explodeDuration)
        .ChangeStartValue(Vector3.zero)
        .SetEase(explodeEase)
        .OnComplete(
            () => transform
                .DOScale(Vector3.zero, implosionDuration)
                .SetEase(implosionEase)
                .OnComplete(() => Destroy(gameObject))
        );
    }

}
