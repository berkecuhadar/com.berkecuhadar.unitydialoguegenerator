# Unity Dialogue Generator [![License](https://img.shields.io/badge/License-MIT-lightgrey.svg?style=flat)](http://mit-license.org)

This repository is a Unity Package for generating texts in a Unity game.

The tool has been verified on the following versions of Unity:
- 2023.3

*  *  *  *  *

## Setup
##### Option A) Clone or download the repository and drop it in your Unity project.
##### Option B) Add the repository to the package manifest (go in YourProject/Packages/ and open the "manifest.json" file and add "com..." line in the depenencies section). If you don't have Git installed, Unity will require you to install it.
```
{
  "dependencies": {
      ...
      "com.berkecuhadar.unitydialoguegenerator": "https://github.com/berkecuhadar/com.berkecuhadar.dialoguegenerator.git"
      ...
  }
}
```
##### Option C) Add the repository to the Unity Package Manager using the Package Manager dropdown.

*  *  *  *  *

## Requirements for developers
* Python 3.11.7
## Before usage of package
* Please create your custom fine tuned gpt2 model [for more info](https://github.com/berkecuhadar/GPT2-FineTuning) or use [direct gpt2 model](https://huggingface.co/openai-community/gpt2)
* For communication with model and unity use python tcp socket server [for more info](https://github.com/berkecuhadar/python-gpt2-server)

* **Important**  Bundle your server file so that players  can use that package without installing Python.


## Using the package
### Step 01 of 03
Create a empty folder named StreamingAssets in Assets folder and  move your bundled server file to Assets/StreamingAssets [For More Info](https://docs.unity3d.com/Manual/StreamingAssets.html)
### Step 02 of 03
Create a empty game object in scene and add the example test component in package_directory. Start the game and check debug log.

### NOTE FOR USAGE
There are only 2 functions. The init function should be started first (in Unity Start func) and then the generate function can be used where necessary. generate function **returns string**. If necessary you must change ip and port values.