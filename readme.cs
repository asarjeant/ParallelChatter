/*
 BUG LOG:
 -Import text file by string FileLocation not currently working
*/

/*
HOW TO IMPLEMENT (EASYCONVERSATION GAME OBJECT):
Creating the dialog lines as a .txt:
-create a .txt where each line of dialog is on a seperate line
-add "<NameMacro>", where "NameMacro" is a character name or etc. to be associated with a given dialog box, to a line whenever you want to change to a different DialogBox

Setting Up:
-add DialogSystem folder to your Assets folder for the current scene 

Creating Your Dialog Boxes and EasyConversation Objects:
-drag prefab "EasyConversation" into scene and rename
-drag prefab "DialogBox" into scene and rename (make sure it has DialogBoxCode attached)
-create a copy of "dtTextBox", rename it, and change any text properties
-drag the above "dtTextBox" object into the "Curr Dialog Text Prefab" value under "DialogBoxCode"

Setting Up the EasyConversation Object:
-add the textfile created above to "scriptFile"
-add all dialogBoxes to be used to "dialogBoxes"
-add names (the ones used in the <NameMacro> command) to each dialogBox by adding them to "speakerNames" at the index corresponding to their dialogBox in "dialogBoxes"

-use command "(this EasyConversation object).GetComponent<EasyConversation>().conversation.advance();" whenever you wish to send the next line to its corresponding DialogBox

------

HOW TO IMPLEMENT (CODE ONLY):
-create a .txt where each line of dialog is on a seperate line
-add <characterNameMacro> to a line whenever you want to change to a different DialogBox

-add the .txt file containing the dialog to your assets
-add DialogSystem folder to your Assets folder for the current scene
-drag prefab "DialogBox" into scene and rename (make sure it has DialogBoxCode attached)
-create a copy of "dtTextBox", rename it, and change any text properties
-drag the above "dtTextBox" object into the "Curr Dialog Text Prefab" value under "DialogBoxCode"
-create an object of class "Conversation" with appropriate constructors ("new Conversation(TextAsset inputFile, DialogBoxCode defaultDialogbox) BubbyandJodey")
-use conversation.DefineMacro(speakername, DialogBoxCode) to assign the macros to dialogBoxes
-use conversation.Advance() to pass the next line of text to the currently active DialogBox, and automatically display it

-to change text box properties, copy DialogBoxTextPrefab 1 -> dtTextBox, alter the copy, then drag the copy into "Curr Dialog Text Prefab" variable in DialogBoxCode
-alter the canvas of an instance of DialogBox to change the background, alpha, or etc. of the box

------

IMPORTANT NOTES: 
	-"null" is an acceptable value for "defaultDialogBox" when initializing a "Conversation"-class object
	-use double, NOT single backslashes in all file paths!
*/