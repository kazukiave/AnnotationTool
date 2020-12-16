using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainSystem : MonoBehaviour
{
    [SerializeField] string srcPath;
    [SerializeField] string extension;
    [SerializeField] GameObject content;

    private Image[] images;
    private Slider[] sliders;
    private ForJsonObj[] forJsonObjs;
    private List<string> imagePaths;
    private List<string> imageNames;

    private int currentImage = 0;
    private bool isInitial = false;

    private string jsonStr = "";
    // Start is called before the first frame update
    void Start()
    {
        imagePaths = new List<string>();
        imageNames = new List<string>();

        images = content.GetComponentsInChildren<UnityEngine.UI.Image>();
        sliders = content.GetComponentsInChildren<Slider>();

        var tempImages = new List<Image>();
        foreach(var i in images)
        {
            if (i.gameObject.name == "Image")
                tempImages.Add(i);
        }
        images = tempImages.ToArray();
        forJsonObjs = new ForJsonObj[images.Length];
        for(int i = 0; i < forJsonObjs.Length; i++)
        {
            forJsonObjs[i] = new ForJsonObj();
        }

        //
        imagePaths = PathUtility.GetImgPaths(srcPath, extension, true);
        foreach(var i in imagePaths)
        {
            imageNames.Add(Path.GetFileName(i));
        }
        Debug.Log(images.Length + " " + sliders.Length + " " + forJsonObjs.Length + " " + imagePaths.Count + " " + imageNames.Count);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ImageLoad();
        }
    }

    private void ImageLoad()
    {
        if (!isInitial)
        {
            isInitial = true;
        }
        else
        {
            for (int i = 0; i < images.Length; i++)
            {
                forJsonObjs[i].sliderValue = Mathf.RoundToInt(sliders[i].value);
            }
            foreach(var i in forJsonObjs)
            {
                Debug.Log(i.imageName + " " + i.sliderValue);
            }

           // jsonStr = JsonHelper.ToJson(forJsonObjs, true);


            string path = Application.dataPath + "/jsonOut.txt";
            Debug.Log(path);

            foreach (var i in forJsonObjs)
            {
                jsonStr = JsonUtility.ToJson(i, true);
                File.AppendAllText(path, jsonStr);
            }
            Debug.Log(jsonStr);
        }

        for (int i = 0; i < images.Length; i++)
        {
            ImageUtility.LoadImage(images[i], imagePaths[currentImage]);
            forJsonObjs[i].imageName = imageNames[currentImage];
            currentImage++;
        }
    }

}

public class ForJsonObj
{
    public string imageName;
    public int sliderValue;

    public ForJsonObj()
    {
        imageName = "";
        sliderValue = 0;
    }
}