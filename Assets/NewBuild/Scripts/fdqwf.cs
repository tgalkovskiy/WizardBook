using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class fdqwf : MonoBehaviour
{
    private string urlmap = "https://drive.google.com/uc?export=download&confirm=no_antivirus&id=1N-DJ-0Uai1eBp01xXgClGYuhe2_yJ2ob";
    public Image a;
    void Start() {
        /*WebClient webClient = new WebClient();
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "Foto.png");
        webClient.DownloadFile(urlmap, Path);*/

        StartCoroutine(GetImage());
    }

    IEnumerator GetImage() {
        /*var img = new WWW(urlmap);
        yield return img;
        if (img.isDone)
        {
            GetComponent<Renderer>().sharedMaterial.mainTexture = img.texture;
            //Debug.Log(img.texture.name);
            //Texture2D tex = img.texture;
            //a.sprite = Sprite.Create((Texture2D)tex, new Rect(0,0, tex.width,tex.height), Vector2.zero);
        }*/
        WWW map = WWW.LoadFromCacheOrDownload(urlmap, 1);
        yield return map;
        urlmap = Path.Combine(Application.persistentDataPath, "Foto.Png");
        var tex = new Texture2D(1,1);
        if (File.Exists(urlmap))
        {
            Debug.Log(1);
        }
        tex.LoadImage(File.ReadAllBytes(urlmap));
        /*var assets = img.assetBundle;
        string File = "spritsmap.png";
        var imgerec = assets.LoadAssetAsync(File, typeof(Sprite));
        a.sprite = imgerec.asset as Sprite;*/
    }
}

