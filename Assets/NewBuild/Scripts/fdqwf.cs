using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class fdqwf : MonoBehaviour
{
    private string urlmap = "https://www.google.com/search?q=%D0%BA%D0%B0%D1%80%D1%82%D0%B8%D0%BD%D0%BA%D0%B0+%D0%B3%D1%83%D0%B3%D0%BB&sxsrf=ALeKk00IhZ832ejf-Dg8wZipfY34a2Ya3w:1624777190703&source=lnms&tbm=isch&sa=X&ved=2ahUKEwixzKnanrfxAhURgf0HHb9mAEIQ_AUoAXoECAEQAw&biw=1920&bih=937#imgrc=H2b5aDtjJ9b7uM";
    public Image a;
    void Start() {
        /*WebClient webClient = new WebClient();
        string Path = System.IO.Path.Combine(Application.persistentDataPath, "Foto.png");
        webClient.DownloadFile(urlmap, Path);*/

        StartCoroutine(GetImage());
    }

    IEnumerator GetImage() {
        var img = new WWW(urlmap);
        yield return img;
        if (img.isDone)
        {
            GetComponent<Renderer>().sharedMaterial.mainTexture = img.texture;
            //Debug.Log(img.texture.name);
            //Texture2D tex = img.texture;
            //a.sprite = Sprite.Create((Texture2D)tex, new Rect(0,0, tex.width,tex.height), Vector2.zero);
        }
        
        /*var assets = img.assetBundle;
        string File = "spritsmap.png";
        var imgerec = assets.LoadAssetAsync(File, typeof(Sprite));
        a.sprite = imgerec.asset as Sprite;*/
    }
}

