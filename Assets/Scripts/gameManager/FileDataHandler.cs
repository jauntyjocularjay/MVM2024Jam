using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class FileDataHandler
{


    private string dataFileName;

    public FileDataHandler(string FileName)
    {
        dataFileName = FileName;
    }


    string saveName()
    {
        string fullPath = Application.persistentDataPath + "/" + dataFileName + ".json";
        return fullPath;
    }

    public EventFlags Load()
    {
        string fullPath = saveName();
        EventFlags loadedFlags = null;

        if (File.Exists(fullPath))
        {
            try
            {
                //Load the serialized data from the file.
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //parse it into usable C# Code.
                loadedFlags = JsonUtility.FromJson<EventFlags>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.LogError("Cannot read data from the file! " + fullPath + "\n" + e);
            }
        }


        return loadedFlags;
    }

    public void Save(EventFlags flags)
    {
        string fullPath = saveName();

        string dataToStore = JsonUtility.ToJson(flags, true);

        try
        {
            Directory.CreateDirectory(dataFileName);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
               using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        } catch (Exception e)
        {
            Debug.Log(e);
        }
    }
}
