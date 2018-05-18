using UnityEngine;
namespace CloseEnough
{
	/// <summary>
	/// Handles the width of the drawing brush.
	/// </summary>
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