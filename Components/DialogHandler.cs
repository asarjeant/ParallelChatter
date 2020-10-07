
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for "Conversation"s, which consist of a list of dialogue lines, and a list of macros for switching between DialogBoxes in which lines are displayed
public class Conversation {
	
	public DialogBoxCode currentDialogBox;
	private TextAsset textAsset;
	private string[] linesArray;
	public Queue<string> lines = new Queue<string>();
	public List<Macro> macros = new List<Macro>();

	//Constructor
	public Conversation(string inputFileLocation, DialogBoxCode defaultDialogBox) {

		if (currentDialogBox != null) {
			currentDialogBox = defaultDialogBox;
		}

		textAsset = Resources.Load (inputFileLocation) as TextAsset;
		if (textAsset != null) {
			linesArray = textAsset.text.Split ('\n');
			lines = new Queue<string> (linesArray);
		} else {
			MonoBehaviour.print ("Not able to import from: " + inputFileLocation);
		}
	}

	public Conversation(TextAsset inputFile, DialogBoxCode defaultDialogBox){
		if (currentDialogBox != null) {
			currentDialogBox = defaultDialogBox;
		}
		if (inputFile != null) {
			linesArray = inputFile.text.Split ('\n');
			lines = new Queue<string> (linesArray);
		} else {
			MonoBehaviour.print ("No TextAsset Detected.");
		}
	}

	public void addLinesFromFile(TextAsset inputFile){
		if (inputFile != null) {
			linesArray = inputFile.text.Split ('\n');
			foreach(string x in linesArray){lines.Enqueue (x);}
		} else {
			MonoBehaviour.print ("No TextAsset Detected.");
		}
	}

	public bool skipLine(){
		if (lines.Count > 0) {
			lines.Dequeue ();
			return true;
		}
		else {return false;}
	}

	public void DefineMacro(string speakername, DialogBoxCode dialogbox){
		//BUG: dialogbox is returning as a NullObject Reference
		macros.Add (new Macro (speakername, dialogbox));
	}

	//Moves the oldest (first) line from the "lines" queue to the Dialog Box at "currentDialogBox", then advances it once.
	public void Advance(){
		if (lines.Count > 0) {
			//searches for macro, then removes changes to the macro's dialogbox and deletes the macro from the line.
			string lineHolder = lines.Dequeue();
			if (macros.Count > 0) {
				foreach (Macro m in macros) {
					if (lineHolder.Contains ("<" + m.speakername + ">")) {
						currentDialogBox = m.dialogBox;
						lineHolder = lineHolder.Replace ("<" + m.speakername + ">", "");
					}
				}
			}
			if (currentDialogBox != null) {
				currentDialogBox.addLine (lineHolder);
				currentDialogBox.advance ();
			} else {
				MonoBehaviour.print ("No assigned dialogBox for line: " + lines.Dequeue ());
			}
		} else {
			MonoBehaviour.print ("No lines in queue.");
		}
	}
}

//Class for macros ("character names," etc.) that cause switching between DialogBox-es
public class Macro {
	
	public string speakername;
	public DialogBoxCode dialogBox;

	public Macro(string inSpeakername, DialogBoxCode inDialogBox){
		if (inSpeakername != null && inDialogBox != null) {
			speakername = inSpeakername;
			dialogBox = inDialogBox;
		} else {
			MonoBehaviour.print("Macro Constructor missing valid String or DialogBoxCode");
		}
	}
}