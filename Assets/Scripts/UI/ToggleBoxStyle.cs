using UnityEngine;
using UnityEngine.UI;

public class UIStyles : MonoBehaviour
{
    public Color color;
    Image[] images;
    Text[] texts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        images = GetComponentsInChildren<Image>();
        texts = GetComponentsInChildren<Text>();

        foreach(Image img in images)
        {
            img.color = color;
        }

        foreach(Text txt in texts)
        {
            txt.color = color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
