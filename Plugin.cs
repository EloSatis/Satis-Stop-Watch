using BepInEx;


using HarmonyLib;
using Loading;
using System;
using System.Diagnostics;
using UnityEngine;
using static stopWatch.Plugin;
using Object = UnityEngine.Object;

namespace stopWatch
{
    [BepInPlugin(Name, GUID, Version)]
    public class Plugin : BaseUnityPlugin
    {
        public const string Name = "Satis Stop watch";
        public const string GUID = "org.Satis.Stop.Watch";
        public const string Version = "1.0";

        private bool patchedHarmony = false;
        private static GameObject Gameobject;
        [System.Serializable]
        public class LoginData
        {
            public string license;

        }
        void Awake()
        {
            if (!patchedHarmony && Loader.loaded == false)
            {
                Harmony harmony = new Harmony(GUID);
                harmony.PatchAll();
                patchedHarmony = true;
                Loader.loaded = true;

            }
        }
    }
    [HarmonyPatch(typeof(GorillaLocomotion.Player), "FixedUpdate")]
    internal class UpdatePatch
    {
        private static bool alreadyInit;
        public static GameObject Gameobject;

        static void Postfix()
        {
           
            if (!alreadyInit)
            {
                alreadyInit = true;
                Gameobject = new GameObject();
                
                Object.DontDestroyOnLoad(Gameobject);
            }
        }
    }
}
