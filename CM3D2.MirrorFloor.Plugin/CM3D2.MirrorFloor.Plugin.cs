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
    PluginVersion("1.0.0.3")]
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
            SceneDance_SCLP = 22,

            // ダンス:stellar my tears
            SceneDance_STMT = 26,

            // ダンス:
            SceneDance_RYFU = 28
        }

        private GameObject mirror;

        private bool isDanceScene(int level){
            if(  level == (int)TargetLevel.SceneDance_DDFL
              || level == (int)TargetLevel.SceneDance_ETYL
              || level == (int)TargetLevel.SceneDance_SCLP
              || level == (int)TargetLevel.SceneDance_STMT
              || level == (int)TargetLevel.SceneDance_RYFU
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
                if(isDanceScene(level))
                {
                    if(  level == (int)TargetLevel.SceneDance_DDFL){
                        mirror.transform.localScale = new Vector3(0.85f, 1f, 0.85f);
                        mirror.transform.localPosition = new Vector3(0f, -0.02f, 0f);
                    }
                    else{
                        mirror.transform.localScale = new Vector3(0.55f, 1f, 0.5f);
                        mirror.transform.localPosition = new Vector3(0f, -0.03f, 0.3f);
                    }
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
            }

        }
    }
}