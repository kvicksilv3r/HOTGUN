using UnityEngine;

public class DebugUtility : MonoBehaviour
{
	public static void DebugCross(Vector3 position, float size = 0.5f, float duration = 1f)
	{
		Debug.DrawLine(position + Vector3.left * size, position + Vector3.right * size, Color.red, duration);

		Debug.DrawLine(position + Vector3.forward * size, position + Vector3.back * size, Color.blue, duration);

		Debug.DrawLine(position + Vector3.up * size, position + Vector3.down * size, Color.green, duration);
	}
}
