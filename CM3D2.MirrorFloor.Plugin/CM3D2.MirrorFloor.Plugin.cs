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
    PluginVersion("1.0.0.6")]
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
            SceneDance_RYFU = 28,

            // ダンス:
            SceneDance_HAPY = 30,

            // ダンス6:happy!happy!スキャンダル 豪華版
            SceneDance_HAPYDX = 31,

            // ダンス7:Can Know Two Close
            SceneDance_CKTC = 32

        }

        private GameObject mirror;
        private int level;

        private bool isDanceScene(int level){
            if(  level == (int)TargetLevel.SceneDance_DDFL
              || level == (int)TargetLevel.SceneDance_ETYL
              || level == (int)TargetLevel.SceneDance_SCLP
              || level == (int)TargetLevel.SceneDance_STMT
              || level == (int)TargetLevel.SceneDance_RYFU
              || level == (int)TargetLevel.SceneDance_HAPY
              || level == (int)TargetLevel.SceneDance_HAPYDX
              || level == (int)TargetLevel.SceneDance_CKTC
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
            this.level = level;
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
                    else if(  level == (int)TargetLevel.SceneDance_HAPY ||
                              level == (int)TargetLevel.SceneDance_HAPYDX){
                        mirror.transform.localScale = new Vector3(0.85f, 1f, 0.85f);
                        mirror.transform.localPosition = new Vector3(0f, -0.012f, 0f);
                    }
//                    else if(  level == (int)TargetLevel.SceneDance_HAPYDX){
//                        mirror.transform.localScale = new Vector3(0.85f, 1f, 0.85f);
//                        mirror.transform.localPosition = new Vector3(0f, -0.01357f, 0f);
//                    }
                    else{
                        mirror.transform.localScale = new Vector3(0.55f, 1f, 0.5f);
                        mirror.transform.localPosition = new Vector3(0f, -0.03f, 0.3f);
                    }
                }
                else
                {
                    mirror.transform.localScale = new Vector3(0.3f, 1f, 0.3f);
                }

                mirror.GetComponent<Renderer>().material = mirrorMaterial;
                //mirror.layer = 4;
                mirror.AddComponent<MirrorReflection2>();
                MirrorReflection2 mirrorRefleftion2 = mirror.GetComponent<MirrorReflection2>();
                mirrorRefleftion2.m_TextureSize = 2048;
                mirrorRefleftion2.m_ClipPlaneOffset = 0.5f;
                mirror.GetComponent<Renderer>().enabled = false;

                if(isDanceScene(level)){


                }

            }
        }

        private void Update()
        {
            if (!Enum.IsDefined(typeof(TargetLevel), level))
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.N))
            {
                mirror.GetComponent<Renderer>().enabled = !mirror.GetComponent<Renderer>().enabled;
            }

        }
    }
}