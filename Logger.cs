using System;
using System.IO;
using UnityEngine;

/// <summary>
/// Allows to log content into files
/// </summary>
public static class Logger
{
    private const string FILE_EXTENSION = ".txt";
    private const string LOG_FORMAT = "[{0}] {1}";
    private const string TIME_FORMAT = "HH:mm:ss";
    private static readonly string LOGS_FOLDER_PATH = Path.Combine(Application.dataPath, "Logs");

    /// <summary>
    /// Logs content into nameFile and stores it in .../Assets/Logs/nameFile
    /// </summary>
    /// <returns>The operation status</returns>
    public static bool Log(in string nameFile, in string content, in bool shouldAppend = true)
    {
        if ( string.IsNullOrEmpty(nameFile) )
        {
            Debug.LogError("[Logger - Log] nameFile is empty or null!");
            return false;
        }
        Directory.CreateDirectory(LOGS_FOLDER_PATH);
        return LogAbsolute(Path.Combine(LOGS_FOLDER_PATH, nameFile), in content, in shouldAppend);
    }

    /// <summary>
    /// Logs content into absoluteFilePath
    /// </summary>
    /// <returns>The operation status</returns>
    public static bool LogAbsolute(in string absoluteFilePath, in string content, in bool shouldAppend = true)
    {
        if ( string.IsNullOrEmpty(absoluteFilePath) )
        {
            Debug.LogError("[Logger - LogAbsolute] absoluteFilePath is empty or null!");
            return false;
        }
        try
        {
            string filePathWithExtension = Path.ChangeExtension(absoluteFilePath, FILE_EXTENSION);
            FileStream fileStream = TryCreateFile(in filePathWithExtension, in shouldAppend);
            using (StreamWriter streamWriter = new StreamWriter(fileStream))
            {
                streamWriter.WriteLine(LOG_FORMAT, DateTime.Now.ToString(TIME_FORMAT), content);
            }
        }
        catch ( Exception exception )
        {
            Debug.LogException(exception);
            return false;
        }
        return true;
    }

    private static FileStream TryCreateFile(in string filePath, in bool shouldAppend)
    {
        if ( shouldAppend )
        {
            return File.Open(filePath, FileMode.Append);
        }
        return File.Open(filePath, FileMode.OpenOrCreate | FileMode.Truncate);
    }
}
