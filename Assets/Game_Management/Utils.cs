using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {

	public static IEnumerator MoveRoutine2(Transform target, Vector2 start, Vector2 end, float d, AnimationCurve c, Action callback = null) {
		float t = 0f;
		while (t < d) {
			yield return null;
			t += Time.deltaTime;
			target.position = Vector2.Lerp (start, end, c.Evaluate (t / d));
		}
		if (callback != null) callback ();
	}
}
