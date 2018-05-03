using UnityEngine;
namespace CloseEnough
{
    public class Width : MonoBehaviour
    {
        void Start()
        {
            var lineRenderer = GetComponent<LineRenderer>();
            var curve = new AnimationCurve();
            var size = SizeManager.singleton.GetStrokeSize();
            curve.AddKey(size, size);

            lineRenderer.widthCurve = curve;
        }
    }
}