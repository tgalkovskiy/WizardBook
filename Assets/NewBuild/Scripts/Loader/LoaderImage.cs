using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LoaderImage : MonoBehaviour
{
    private string urlGeneralMap = "https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1t2UDTyehhxDD1UCUmgjD9Yu8iCjur6Ko";
    public Image image;
    public Sprite b;
    public GameObject c;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        //var a = Resources.Load<Sprite>("Mapppp");

        //b = a;
        //c = (Resources.Load<GameObject>("Image"));
        //StartCoroutine(DownlandAndCache());
        //urlGeneralMap = Path.Combine(Application.persistentDataPath, "spritsmap");
        StartCoroutine(DownlandAndCache());
        //if (File.Exists(urlGeneralMap))
        //{
            
        //}
        //byte[] a = File.ReadAllBytes(urlGeneralMap);
        //var tex = new Texture2D(2,2);
        //ex.LoadImage(a);
        //var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
        //image.sprite = sprite;
        //image.sprite.texture = map.texture;

    }

    IEnumerator DownlandAndCache()
    {
        WWW map = WWW.LoadFromCacheOrDownload(urlGeneralMap, 0);
        yield return map;
        Debug.Log(map.isDone);
        var asset = map.assetBundle;
        Debug.Log(asset.name);
        var sprirec = asset.LoadAssetAsync("Mapppp.png", typeof(Sprite));
        yield return sprirec;
        if (sprirec.isDone)
        {
            Debug.Log(sprirec.asset.name);
        }
        image.sprite = sprirec.asset as Sprite;


    }
    
}
