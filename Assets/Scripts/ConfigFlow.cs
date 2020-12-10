using Unity;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConfigFlow : MonoBehaviour
{

    public void ChangeScene(string cubeFace)
    {
        print("click config");
        PlayerPrefs.SetString("CubeFace", cubeFace);
        SceneManager.LoadScene(6);
    }
}