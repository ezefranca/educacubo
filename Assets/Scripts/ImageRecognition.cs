using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class ImageRecognition : MonoBehaviour
{

    [SerializeField] private ARTrackedImageManager _arTrackedImageManager;

    [SerializeField]
    private GameObject welcomePanel;

    [SerializeField]
    private Button dismissButton;

    [SerializeField]
    private Text imageTrackedText;

    [SerializeField]
    private GameObject[] arObjectsToPlace;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();

    private void Awake()
    {
        dismissButton.onClick.AddListener(Dismiss);
        _arTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        Debug.Log("ImageRecognition Awake");

        // setup all game objects in dictionary
        foreach (GameObject arObject in arObjectsToPlace)
        {
            GameObject newARObject = Instantiate(arObject, Vector3.zero, Quaternion.identity);
            newARObject.name = arObject.name;
            arObjects.Add(arObject.name, newARObject);
        }
    }

    private void OnEnable()
    {
        _arTrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        _arTrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void Dismiss() => welcomePanel.SetActive(false);

    //public void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    //{
      
    //    foreach (var trackedImage in args.updated)
    //    {
    //        Debug.Log(trackedImage.name);
    //       //trackedImage.referenceImage.name;
    //    }
    //   // imageTrackedText.text = args.ToString();
    //}

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added)
        {
            UpdateARImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.updated)
        {
            UpdateARImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventArgs.removed)
        {
            arObjects[trackedImage.name].SetActive(false);
        }
    }

    private void UpdateARImage(ARTrackedImage trackedImage)
    {

        imageTrackedText.text = "Detectado: " + trackedImage.referenceImage.name;

        AssignGameObject(trackedImage.referenceImage.name, trackedImage.transform.position);
        Debug.Log($"ImageRecognition: {trackedImage.referenceImage.name}");
    }

    void AssignGameObject(string name, Vector3 newPosition)
    {
        if (arObjectsToPlace != null)
        {
            GameObject arObject = arObjects[name];
            arObject.SetActive(true);
            arObject.transform.position = newPosition;
            arObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            foreach (GameObject go in arObjects.Values)
            {
                Debug.Log($"Go in Arobjects.Values: {go.name}");
                if(go.name != name)
                {
                    go.SetActive(false);
                }
            }
        }
    }

}
