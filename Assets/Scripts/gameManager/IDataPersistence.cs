using UnityEngine;

public interface IDataPersistence
{
    //This is a set of methods which interface with various classes, providing an easy and consistent framework

    //For more information about how these work, check this page out: https://learn.unity.com/tutorial/interfaces#

    void LoadData(EventFlags data);

    void SaveData(ref EventFlags data);
}
