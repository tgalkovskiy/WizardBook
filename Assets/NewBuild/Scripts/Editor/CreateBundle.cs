using UnityEditor;

public class CreateBundle 
{
    
    [MenuItem("Create Assets/Creat Asset for PC")]
    static void CreatAssetFromPC()
    {
        BuildPipeline.BuildAssetBundles("Assets/NewBuild/AssetsDowland/AssetPC", BuildAssetBundleOptions.None,
            BuildTarget.StandaloneWindows);
    }
    [MenuItem("Create Assets/Creat Asset for Android")]
    static void CreatAssetFromAndroid()
    {
        BuildPipeline.BuildAssetBundles("Assets/NewBuild/AssetsDowland/AssetAndroid", BuildAssetBundleOptions.None,
            BuildTarget.Android);
    }
}
