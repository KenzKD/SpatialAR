using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ButtonActions : MonoBehaviour
{

    private void Add_ImageTarget(Texture2D texture)
    {
        Debug.Log("Image Added");
    }

    public void Select_NewImageTarget()
    {
        Debug.Log("Image Path Selected");
        string link = "https://cdn.vox-cdn.com/thumbor/ly-R6GjjcIu88IIgZQ969tLzQlg=/100x0:1180x720/1200x800/filters:focal(100x0:1180x720)/cdn.vox-cdn.com/uploads/chorus_image/image/13583269/unity-logo-black_1280.0.jpg";

        StartCoroutine(Download_Texture(link));
    }

    public void Download_NewImageTarget(string link)
    {
        StartCoroutine(Download_Texture(link));
    }

    IEnumerator Download_Texture(string link)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(link);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.Log(request.error);
        }
        Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        Debug.Log("Image Downloaded");

        Add_ImageTarget(texture);
    }
}
