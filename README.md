# ParallelChatter
A CSV-based multi-use text dialog system for Unity 5.5. Designed as a scrappy, small-scale alternative to Yarnspinner and other feature-rich but inflexible dialog implementations.<br/>
Want to see it in action? Check out "Woods", a short dialog driven game built with this ParallelChatter! https://archie-sarjeant.itch.io/woods-in-browser

Features:<br/>
Read dialog from a CSV - no need for external applications or inflexible workflow systems<br/>
Code free implementation...<br/>
Or, code only implementation!<br/>
Supports multiple simultaneous conversations, textboxes and UI objects<br/>
No required third party assets - only uses assets which ship with Unity 5.5<br/>
Custom macros allow your dialog writer to shift between dialog boxes<br/>
Dialog boxes with elegant animations and optional history<br/>

Planned Features:<br/>
Macros generate event calls<br/>

 v 2.1 Oct 4-2020:<br/>
 -Import text file by string FileLocation not currently working<br/>
<br/>

# Creating a Conversation as a .txt:<br/>
-create a .txt where each line of dialog is on a seperate line
-add "<NameMacro>", where "NameMacro" is a character name or etc. to be associated with a given dialog box, to a line whenever you want to change to a different DialogBox<br/>
 
# How to Implement (Easy Conversation object / code-free):<br/>
<br/>
Setting Up:<br/>
-add DialogSystem folder to your Assets folder for the current scene <br/>
<br/>
Creating Your Dialog Boxes and EasyConversation Objects:<br/>
-drag prefab "EasyConversation" into scene and rename<br/>
-drag prefab "DialogBox" into scene and rename (make sure it has DialogBoxCode attached)<br/>
-create a copy of "dtTextBox", rename it, and change any text properties<br/>
-drag the above "dtTextBox" object into the "Curr Dialog Text Prefab" value under "DialogBoxCode"<br/>
<br/>
Setting Up the EasyConversation Object:<br/>
-add the textfile created above to "scriptFile"<br/>
-add all dialogBoxes to be used to "dialogBoxes"<br/>
-add names (the ones used in the <NameMacro> command) to each dialogBox by adding them to "speakerNames" at the index corresponding to their dialogBox in "dialogBoxes"<br/>
<br/>
-use command "(this EasyConversation object).GetComponent<EasyConversation>().conversation.advance();" whenever you wish to send the next line to its corresponding DialogBox<br/>
<br/>

# How to Implement (Code only):<br/>
-create a .txt where each line of dialog is on a seperate line<br/>
-add <characterNameMacro> to a line whenever you want to change to a different DialogBox<br/>
<br/>
-add the .txt file containing the dialog to your assets<br/>
-add DialogSystem folder to your Assets folder for the current scene<br/>
-drag prefab "DialogBox" into scene and rename (make sure it has DialogBoxCode attached)<br/>
-create a copy of "dtTextBox", rename it, and change any text properties<br/>
-drag the above "dtTextBox" object into the "Curr Dialog Text Prefab" value under "DialogBoxCode"<br/>
-create an object of class "Conversation" with appropriate constructors ("new Conversation(TextAsset inputFile, DialogBoxCode defaultDialogbox) BubbyandJodey")<br/>
-use conversation.DefineMacro(speakername, DialogBoxCode) to assign the macros to dialogBoxes<br/>
-use conversation.Advance() to pass the next line of text to the currently active DialogBox, and automatically display it<br/>
<br/>
-to change text box properties, copy DialogBoxTextPrefab 1 -> dtTextBox, alter the copy, then drag the copy into "Curr Dialog Text Prefab" variable in DialogBoxCode<br/>
-alter the canvas of an instance of DialogBox to change the background, alpha, or etc. of the box<br/>
<br/>
 
# Important Notes<br/>
<br/>
-"null" is an acceptable value for "defaultDialogBox" when initializing a "Conversation"-class object<br/>
-use double, NOT single backslashes in all file paths!<br/>
