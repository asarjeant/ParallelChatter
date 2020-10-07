/*
 CURRENT BUGS: -None found!

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxCode : MonoBehaviour {

	public GameObject CurrDialogTextPrefab;
	public Queue<string> lines;
	public bool fade;
	public float fadeAfter = 5;
	public float fadeSpeed = 0.25f;
	public Queue<GameObject> handledBoxes;
	private float TimeSinceAdvance = 0;
	public bool textFadeOldest;

	void Start () {
		lines = new Queue<string>();
		handledBoxes = new Queue<GameObject>();
	}

	void Update(){
		//fader code
		CanvasGroup thisCanvasGroup = this.GetComponent<CanvasGroup>();
		if (fade == true && TimeSinceAdvance > fadeAfter) {
			thisCanvasGroup.alpha -= (thisCanvasGroup.alpha * fadeSpeed);
		} else {
			thisCanvasGroup.alpha = 1;
		}
		TimeSinceAdvance += Time.deltaTime;

		AdjustAlphas ();
	}

	void AdjustAlphas(){
		if (this.GetComponentInParent<DialogBoxCode> ().textFadeOldest== true) {
			float tempf = handledBoxes.Count;
			float counterf = 0;
			foreach (GameObject child in handledBoxes) {
				counterf += 1f;
				child.GetComponentInChildren<CanvasRenderer>().SetAlpha (counterf / tempf);
			}
		}
	}

	public void addLine(string newline){
		lines.Enqueue (newline);
	}

	void addLines(string[] newLines){
		foreach(string x in newLines){lines.Enqueue (x);}
	}

	void adjustHeights(){
		float totalHeight = 0f;
		float checkHeight = 0f;

		foreach (GameObject x in handledBoxes) {
			checkHeight += x.GetComponentInChildren<RectTransform>().rect.height;
		}

		while (checkHeight > this.GetComponentInChildren<RectTransform>().rect.height) {
			checkHeight -= handledBoxes.Peek ().GetComponentInChildren<RectTransform>().rect.height;
			DestroyImmediate (handledBoxes.Dequeue ());
		}
	
		foreach (Transform child in transform) {
			child.GetComponentInChildren<DialogTextPrefab_HeightAdjuster>().yTarget = totalHeight;
			totalHeight += child.GetComponentInChildren<RectTransform>().rect.height;
		}
	}

	public void advance() {
		TimeSinceAdvance = 0;
		if (lines.Count > 0){
			GameObject newBox = (Instantiate (CurrDialogTextPrefab, this.transform, false));
			Text newBoxText = newBox.GetComponentInChildren<Text> ();
			handledBoxes.Enqueue(newBox);
			newBoxText.text = lines.Dequeue();
			Canvas.ForceUpdateCanvases ();
			adjustHeights ();
		}
	}

	public void advance(int advanceCount){
		for (int i = 0; i < advanceCount; i++){
			advance();
		}
	}

	void skipLine(){
		lines.Dequeue ();
	}

	void clearAll(){
		lines.Clear ();
		foreach (GameObject x in handledBoxes) {
			Destroy (x);
		}
		handledBoxes.Clear();
	}
		
}
