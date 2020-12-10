using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{

    [SerializeField]
    public Sprite[] images = null;

    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        string imgName = PlayerPrefs.GetString("CubeFace");
        imgName.Replace("Button", "");
        PlayerPrefs.DeleteAll();

        foreach (Sprite sp in images)
        {
            if (sp.name == imgName)
            {
                image.sprite = sp;
                break;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
