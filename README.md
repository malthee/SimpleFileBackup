# SimpleFileBackup
Simple C# program for copying multiple files to multiple locations at once

![Image of SimpleFileBackup UI](https://i.imgur.com/8520Ob0.png)

## Download
https://github.com/malthee/SimpleFileBackup/releases

## General
Select files by pressing the first "Browse" button on the right. You can select multiple files at once or open the browse window multiple times. After pressing OK the file locations will be saved in the drop down list. You can also add files by typing the path in the textbox and pressing enter. If you made a wrong selection, you can delete single items by selecting them in the drop down list and pressing "Delete Item". You can clear the list by pressing "Clear List".

The "Backup Destitination" selection works the same way.

## Settings

### Override idenetical files in directory
If you want to replace your old files with the new files enable the "Override identical files in directory" option. This way, if a file called 123.jpg is already in the directory, it will be replaced. Same goes for ZIP files.

### Put files in given directory
Copies the files into the selected directories.

![List of files](https://i.imgur.com/6DghufZ.png)

### Create a subfolder in directory
Creates a subfolder in every given directory.

### Create a .zip file in directory
Create a .zip from the given files and copy it to every listed directory.

### Name Folder/.zip
Only works when "Create a subfolder in directory" or "Create a .zip file in directory" is selected.
You can name your folder or .zip file with a maximum of 20 characters. The characters have to be compatible with the windows filesystem.

### Add date to Folder/.zip name
Adds your local date to the folder/.zip name in the format name_10-10-2010.

### Save Default File Paths & Save Default Backup Paths
Saves your file/backup locations as a list in a text file, that is located in the program folder. This list is loaded when the program is launched and inserted in the drop down list.

### Save Custom File Paths & Save Custom Backup Paths
Saves your file/backup locations in a text file you can choose the location of.

### Open File Paths & Open Backup Paths
You can open a text file that contains paths to files or directories. These paths will be inserted into the drop down list.

This is my first publicly released program. I made it because I needed a tool to backup files to more locations at once and I wanted to code something in my summer holidays. I do not expect much from this program but any feedback or criticism is appreciated. 
