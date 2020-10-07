/*
 HOW TO USE:
 -create a .txt where each line of dialog is on a seperate line
 -add <characterNameMacro> to a line whenever you want to change to a different DialogBox

 -drag prefab "EasyConversation" into scene
 -add the textfile created above to "scriptFile"
 -add all dialogBoxes to be used to "dialogBoxes"
 -add names (the ones used in the <characterNameMacro> command) to each dialogBox by adding them to "speakerNames" at the index corresponding to their dialogBox in "dialogBoxes"

 -use command "(this object).GetComponent<EasyConversation>().conversation.advance();" whenever you wish to send the next line to its corresponding DialogBox
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyConversation : MonoBehaviour {

	public DialogBoxCode defaultDialogBox;
	public DialogBoxCode[] dialogBoxes;
	public string[] speakerNames;
	public TextAsset scriptFile;
	public Conversation conversation;
	public bool repeat = false;

	void Start () {
		if (dialogBoxes.Length != 0 && speakerNames.Length == dialogBoxes.Length && scriptFile != null) { 
			conversation = new Conversation (scriptFile, defaultDialogBox);
			int x = 0;
			foreach (string n in speakerNames) {
				conversation.DefineMacro (n, dialogBoxes [x]);
				x++;
			}
		} else {
			print ("Error. DialogBoxes, speakernames and scriptFile must all have valid values.");
		}
	}
	void Update(){
		print (conversation.lines.Count);
		if (repeat == true && conversation.lines.Count < 3) {
			conversation.addLinesFromFile (scriptFile);
			print ("repeated!");
		}
	}
}
