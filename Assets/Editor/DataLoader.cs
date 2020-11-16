using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace Editor
{
    public class DataLoader : MonoBehaviour
    {
        private static readonly int MainTex = Shader.PropertyToID("_MainTex");
        private static readonly int BumpMap = Shader.PropertyToID("_BumpMap");

        [MenuItem("Tools/Load Data")]
        public static void LoadData()
        {
            const string outPath = "Test/settings.zip";
            const string unzipDirectory = "Test/Settings";
            const string texturePngPath = "Test/Settings/texture.png";
            const string uri = "https://dminsky.com/settings.zip";

            try
            {
                throw new UriFormatException();
                var uwr = UnityWebRequest.Get(uri);
                uwr.downloadHandler = new DownloadHandlerFile(outPath);
                var op = uwr.SendWebRequest();

                op.completed += (ao) =>
                {
                    if (uwr.isNetworkError || uwr.isHttpError)
                    {
                        Debug.Log("Some Error");
                    }
                    else
                    {
                        ZipFile.ExtractToDirectory(outPath, unzipDirectory);
                        var jsonFileName = Directory.GetFiles(unzipDirectory)[0];

                        var data = JsonUtility.FromJson<Data>(File.ReadAllText(jsonFileName));

                        var textureBase64Bytes = Convert.FromBase64String(data.base64Texture);
                        File.WriteAllBytes(texturePngPath, textureBase64Bytes);

                        var myTex = new Texture2D(2, 2);
                        var texData = File.ReadAllBytes(texturePngPath);
                        myTex.LoadImage(texData);

                        var myMat = GameObject.Find("floor").GetComponent<MeshRenderer>().sharedMaterial;
                        myMat.SetTexture(BumpMap, myTex);
                        myMat.EnableKeyword("_NORMALMAP");

                        PlayerPrefs.SetFloat("speed", data.speed);

                    }
                };
            }

            catch (UriFormatException e)
            {
                //Console.WriteLine(e);
                EditorUtility.DisplayDialog("UriFormatException", e.Message, "OK");
                //EditorGUILayout.HelpBox("UriFormatException: " + e.Message, MessageType.Error);
            }
            catch (WebException e)
            {
                EditorUtility.DisplayDialog("WebException", e.Message, "OK");
            }
            catch (DirectoryNotFoundException e)
            {
                EditorUtility.DisplayDialog("DirectoryNotFoundException", e.Message, "OK");
            }
            catch (PathTooLongException e)
            {
                EditorUtility.DisplayDialog("PathTooLongException", e.Message, "OK");
            }
            catch (FileNotFoundException e)
            {
                EditorUtility.DisplayDialog("FileNotFoundException", e.Message, "OK");
            }
            catch (NullReferenceException e)
            {
                EditorUtility.DisplayDialog("NullReferenceException", e.Message, "OK");
            }
            catch (Exception e)
            {
                EditorUtility.DisplayDialog("Exception", e.Message, "OK");
            }
        }
    }

    [Serializable]
    public class Data
    {
        public float speed;
        public int health;
        public string fullName;
        public string base64Texture;
    }
}
