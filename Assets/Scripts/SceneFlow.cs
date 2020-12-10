using Unity;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFlow : MonoBehaviour {

    public void ChangeScene(int scene)
    {
        print("click");
        SceneManager.LoadScene(scene);
    }
}