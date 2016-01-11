using System;
using UnityEngine;
using UnityInjector;
using UnityInjector.Attributes;

namespace CM3D2.MirrorFloor.Plugin
{
    [PluginFilter("CM3D2x64"),
    PluginFilter("CM3D2x86"),
    PluginFilter("CM3D2VRx64"),
    PluginName("Mirror Floor"),
    PluginVersion("1.0.0.0")]
    public class MirrorFloor : PluginBase
    {
        private enum TargetLevel
        {
            //ダンス:ドキドキ☆Fallin' Love
            SceneDance_DDFL = 4,

            // エディット
            SceneEdit = 5,

            // ダンス:entrance to you
            SceneDance_ETYL = 20,

            // ダンス:scarlet leap
            SceneDance_SCLP = 22
        }

        private GameObject mirror;
        private GameObject mirror2;
        private GameObject mirror3;
        private GameObject mirror4;
        // private float speed = 0.01f;

        private bool isDanceScene(int level){
            if(  level == (int)TargetLevel.SceneDance_DDFL
              || level == (int)TargetLevel.SceneDance_ETYL
              || level == (int)TargetLevel.SceneDance_SCLP
            )
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        private void Awake()
        {
            GameObject.DontDestroyOnLoad(this);
        }

        private void OnLevelWasLoaded(int level)
        {
            if (Enum.IsDefined(typeof(TargetLevel), level))
            {
                Material mirrorMaterial = new Material(Shader.Find("Mirror"));

                mirror = GameObject.CreatePrimitive(PrimitiveType.Plane);
                // もっとスマートに書きたいけど今はべたうち
                if(isDanceScene(level))
                {
                    mirror.transform.localScale = new Vector3(0.6f, 1f, 0.5f);
                }
                else
                {
                    mirror.transform.localScale = new Vector3(0.3f, 1f, 0.3f);
                }

                mirror.renderer.material = mirrorMaterial;
                //mirror.layer = 4;
                mirror.AddComponent<MirrorReflection2>();
                MirrorReflection2 mirrorRefleftion2 = mirror.GetComponent<MirrorReflection2>();
                mirrorRefleftion2.m_TextureSize = 2048;
                mirrorRefleftion2.m_ClipPlaneOffset = 0f;
                mirror.renderer.enabled = false;
                //mirror.renderer.enabled = true;

                if(isDanceScene(level)){

                    // ２枚目書いてみゆ
                    mirror2 = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    mirror2.transform.localScale = new Vector3(0.6f, 1f, 0.5f);
                    mirror2.transform.localPosition = new Vector3(-2.5f, 0f, 0f);
                    mirror2.transform.localEulerAngles = new Vector3(0,0,-90);
                    mirror2.renderer.material = mirrorMaterial;
                    //mirror2.layer = 4;
                    mirror2.AddComponent<MirrorReflection2>();
                    MirrorReflection2 mirrorRefleftion2_2 = mirror.GetComponent<MirrorReflection2>();
                    mirrorRefleftion2_2.m_TextureSize = 2048;
                    mirrorRefleftion2_2.m_ClipPlaneOffset = 0f;
                    mirror2.renderer.enabled = false;
                    //mirror2.renderer.enabled = true;
                // ３枚目
                    mirror3 = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    mirror3.transform.localScale = new Vector3(0.6f, 1f, 0.5f);
                    mirror3.transform.localPosition = new Vector3(2.5f, 0f, 0f);
                    mirror3.transform.localEulerAngles = new Vector3(0,0,90);
                    mirror3.renderer.material = mirrorMaterial;
                    //mirror3.layer = 4;
                    mirror3.AddComponent<MirrorReflection2>();
                    MirrorReflection2 mirrorRefleftion2_3 = mirror.GetComponent<MirrorReflection2>();
                    mirrorRefleftion2_3.m_TextureSize = 2048;
                    mirrorRefleftion2_3.m_ClipPlaneOffset = 0f;
                    mirror3.renderer.enabled = false;
                    //mirror3.renderer.enabled = true;
                // ４枚目
                    mirror4 = GameObject.CreatePrimitive(PrimitiveType.Plane);
                    mirror4.transform.localScale = new Vector3(0.6f, 1f, 0.5f);
                    mirror4.transform.localPosition = new Vector3(0f, 2.8f, 0f);
                    mirror4.transform.localEulerAngles = new Vector3(180,0,0);
                    mirror4.renderer.material = mirrorMaterial;
                    //mirror4.layer = 4;
                    mirror4.AddComponent<MirrorReflection2>();
                    MirrorReflection2 mirrorRefleftion2_4 = mirror.GetComponent<MirrorReflection2>();
                    mirrorRefleftion2_4.m_TextureSize = 2048;
                    mirrorRefleftion2_4.m_ClipPlaneOffset = 0f;
                    mirror4.renderer.enabled = false;
                    //mirror4.renderer.enabled = true;

                }

            }
        }

        private void Update()
        {
            if (!Enum.IsDefined(typeof(TargetLevel), Application.loadedLevel))
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                mirror.renderer.enabled = !mirror.renderer.enabled;
                mirror2.renderer.enabled = !mirror2.renderer.enabled;
                mirror3.renderer.enabled = !mirror3.renderer.enabled;
                mirror4.renderer.enabled = !mirror4.renderer.enabled;
            }

            //if (Input.GetKey(KeyCode.Keypad4))
            //{
            //    mirror.transform.localScale -= Vector3.right * Time.deltaTime * speed;
            //}
            //if (Input.GetKey(KeyCode.Keypad6))
            //{
            //    mirror.transform.localScale += Vector3.right * Time.deltaTime * speed;
            //}
            //if (Input.GetKey(KeyCode.Keypad2))
            //{
            //    mirror.transform.localScale -= Vector3.forward * Time.deltaTime * speed;
            //}
            //if (Input.GetKey(KeyCode.Keypad8))
            //{
            //    mirror.transform.localScale += Vector3.forward * Time.deltaTime * speed;
            //}
            //if (Input.GetKey(KeyCode.Keypad3))
            //{
            //    mirror.transform.position -= Vector3.up * Time.deltaTime * speed;
            //    Console.WriteLine(mirror.transform.position.ToString("F4"));
            //}
            //if (Input.GetKey(KeyCode.Keypad9))
            //{
            //    mirror.transform.position += Vector3.up * Time.deltaTime * speed;
            //    Console.WriteLine(mirror.transform.position.ToString("F4"));
            //}
        }
    }
}