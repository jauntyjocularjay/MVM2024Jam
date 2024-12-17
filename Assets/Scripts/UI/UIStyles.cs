using UnityEngine;
using UnityEngine.UI;

public class UIStyles : MonoBehaviour
{
    float r = 154.0f;
    float g = 76.0f;
    float b = 0.0f;
    float a = 255.0f;
    public Color color;
    Image[] images;
    Text[] texts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        r /= 255.0f;
        g /= 255.0f;
        b /= 255.0f;
        a /= 255.0f;
        color = new Color(r,g,b,a);
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
}
