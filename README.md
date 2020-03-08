# Logger

Allows to log content into files.

For the **Log method**, the default destination folder is ".../Assets/Logs/".

# Format

    bool Log(in string nameFile, in string content, in bool shouldAppend = true)
    
    bool LogAbsolute(in string absoluteFilePath, in string content, in bool shouldAppend = true)
    
A boolean is returned to show the operation status *(true = success, false = fail)*

# Usage

    Logger.Log("Network", "Connected to server");

    Logger.LogAbsolute(Path.Combine(Application.dataPath, "Logs/", "Network"), "Disconnected from server");

Output

> File Network.txt *(create if not exist)*

    [14:20:26] Connected to server
    [14:20:26] Disconnected from server

# Project Information

Made with **Unity 2019.3**

License **MIT**
