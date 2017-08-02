using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using Facebook.Unity;
using System;

public class ShareImage : MonoBehaviour
{

    private bool isProcessing = false;

    private string shareText = "Can you help me solve this word puzzle?\n";
    private string gameLink = "Download the game on play store at " + "\nhttps://play.google.com/store/apps/details?id=com.TGC.guessthemovie&pcampaignid=GPC_shareGame";
    private string subject = "Word Bridges";
    private string imageName = "test"; 

    public void shareImage()
    {

        if (!isProcessing)
            StartCoroutine(ShareScreenshot());

    }

    private IEnumerator ShareScreenshot()
    {
        isProcessing = true;
        yield return new WaitForEndOfFrame();

        Texture2D screenTexture = new Texture2D(1920, 1080, TextureFormat.RGB24, true);
        screenTexture.Apply();

        byte[] dataToSave = Resources.Load<TextAsset>(imageName).bytes;

        string destination = Path.Combine(Application.persistentDataPath, System.DateTime.Now.ToString("yyyy-MM-dd-HHmmss") + ".png");
        Debug.Log(destination);
        File.WriteAllBytes(destination, dataToSave);

        if (!Application.isEditor)
        {

            AndroidJavaClass intentClass = new AndroidJavaClass("android.content.Intent");
            AndroidJavaObject intentObject = new AndroidJavaObject("android.content.Intent");
            intentObject.Call<AndroidJavaObject>("setAction", intentClass.GetStatic<string> ("ACTION_SEND"));
            AndroidJavaClass uriClass = new AndroidJavaClass("android.net.Uri");
            AndroidJavaObject uriObject = uriClass.CallStatic<AndroidJavaObject>("parse", "file://" + destination);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_STREAM"), uriObject);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), shareText + gameLink);
            intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
            intentObject.Call<AndroidJavaObject>("setType", "image/jpeg");
            AndroidJavaClass unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity");

            currentActivity.Call("startActivity", intentObject);

        }

        isProcessing = false;

    }

    private void OnMouseDown()
    {
        //shareImage();
        FB.Init();
        FB.ShareLink(
               new Uri("https://developers.facebook.com/"),
               callback: ShareCallback
           );
    }

    private void ShareCallback(IShareResult result)
    {
        if (result.Cancelled || !String.IsNullOrEmpty(result.Error))
        {
            Debug.Log("ShareLink Error: " + result.Error);
        }
        else if (!String.IsNullOrEmpty(result.PostId))
        {
            // Print post identifier of the shared content
            Debug.Log(result.PostId);
        }
        else
        {
            // Share succeeded without postID
            Debug.Log("ShareLink success!");
        }
    }
 }
