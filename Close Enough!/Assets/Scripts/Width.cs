using UnityEngine;
namespace CloseEnough
{
    public class Width : MonoBehaviour
    {
        TrailRenderer swipe;

        void Start()
        {
            swipe = GetComponent<TrailRenderer>();
            var curve = new AnimationCurve();
            var size = SizeManager.singleton.GetStrokeSize();
            curve.AddKey(size, size);

            swipe.widthCurve = curve;
        }
    }
}