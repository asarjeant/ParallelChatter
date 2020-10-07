using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Systemtester : MonoBehaviour {

	public DialogBoxCode inputbox1;
	public DialogBoxCode inputbox2;
	public TextAsset dialogText;
	public string[] linedisplayer;
	private Conversation testConversation;
	public EasyConversation testEasyConversation;

	void Start () {
		testConversation = new Conversation (dialogText, null);
		linedisplayer = testConversation.lines.ToArray();
		testConversation.DefineMacro ("dialogbox1", inputbox1);
		testConversation.DefineMacro ("dialogbox2", inputbox2);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			testConversation.Advance ();
		}
		if (Input.GetKeyDown (KeyCode.LeftAlt)) {
			testConversation.skipLine ();
		}
		if (Input.GetKeyDown (KeyCode.KeypadEnter)){
			testEasyConversation.GetComponent<EasyConversation> ().conversation.Advance ();
		}
	}
}
