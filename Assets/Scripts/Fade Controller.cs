using Spine.Unity;
using UnityEngine;

public class FadeController : MonoBehaviour
{
    [Range(0, 1)]
    public float Alpha = 1f;

    private SkeletonRenderer skeletonRenderer;

    private void Start()
    {
        skeletonRenderer = GetComponent<SkeletonRenderer>();
    }

    private void Update()
    {
        float remapAlpha = Remap(Alpha, 1f, 0f, 1f, 0.5f);
        skeletonRenderer.skeleton.SetColor(new Color(1, 1, 1, remapAlpha));
    }

    private static float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
