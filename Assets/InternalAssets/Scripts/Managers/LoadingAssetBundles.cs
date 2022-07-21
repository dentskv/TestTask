using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingAssetBundles : MonoBehaviour
{
    public IEnumerator LoadAssetBundle()
    { 
        var bundleLoadRequest = AssetBundle.LoadFromFileAsync(Path.Combine(Application.dataPath, Path.Combine("AssetBundles", "gamescene")));
        yield return bundleLoadRequest;

        if(bundleLoadRequest == null) Debug.Log("Failed to load AssetBundle");

        var assetLoadRequest = bundleLoadRequest.assetBundle.LoadAsset<GameObject>("gamescene");
        yield return assetLoadRequest;

        var scene = assetLoadRequest.scene;
        SceneManager.LoadScene(scene.name);
    }
}
