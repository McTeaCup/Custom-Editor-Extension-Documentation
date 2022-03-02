# Custom-Editor-Extension-Documentation (CEED)
A tool that show most (if not all) objects you can create to your editor in Unity

## How to install
If you wish to install this tool quickly use "Quick install". This is just one cs file that must be put in the editor folder. If you do not have an editor folder yet, create one wherever you please in the project.

## How to use
This tool is made primarly to speed up the custom editor workflow by geting a look how the items will be displayed before writing it or looking up the documentation. If the button "Copy Template" is pressed it will copy the skeleton of the code nessesary to your clipboard that you can paste in your editor script. Of course you will have to add your own overload properties to get it working properly, but comments will guide you to what is needed. Some items like Icons might need to be cased/converted as image to work with most items. Any documentation can be found either on the item themselves or by pressing the title of each category.

If you want to add your own items you can do so, but I recommed using the "Open Source" option due to it splitting up the collection of Unity's documentation and overall text that is used for the tool.

## EditorGUILayout
Depending on what variables you may need and want to use, you migt need to use different kinds of field. You can preview all fields that are avalable in the EditorGUILayout class before you add them to your editor. Remember though that all fields may will return a specific kind of value. Links to the official Unity documentation is avalable for each feild through the editor. 

## GUIStyles
Even though the fields might return values their apperance can be alterd to create a more uniform and/or better look based on the editor you're working on. Using styles you can alter the look of field.

## Icons
Sometimes you might want to deliver a message of a button or window without having to write what they do. Using the built in icons you can do that. You can preview almost all built in icons that comes with Unity by default and pick the one you want. 
![Icon_Preview](https://user-images.githubusercontent.com/69859445/156437696-eee0b715-9eed-4613-af46-d9d716b40ad1.PNG)

Hope this will help you out!

*Daniel Redelius*

