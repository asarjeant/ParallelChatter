using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTextPrefab_WidthAdjuster : MonoBehaviour {


	public static GameObject FindParentWithTag(GameObject childObject, string tag)
	{
		Transform t = childObject.transform;
		while (t.parent != null)
		{
			if (t.parent.tag == tag)
			{
				return t.parent.gameObject;
			}
			t = t.parent.transform;
		}
		return null; // Could not find a parent with given tag.
	}


	void Start () {
		float xfl = FindParentWithTag (this.gameObject, "Dialogbox").GetComponent<RectTransform> ().rect.width;
		this.GetComponent<RectTransform> ().sizeDelta = new Vector2 (xfl, 0f);
	}
}
