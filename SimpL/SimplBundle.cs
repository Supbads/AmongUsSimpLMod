using HarmonyLib;
using Reactor.Extensions;
using Reactor.Unstrip;
using System.IO;
using UnityEngine;

namespace SimpL
{
    [HarmonyPatch]
    public static class SimplBundle
    {
        public static AssetBundle bundle;
        public static AudioClip amongUsDrip;


        public static void LoadBundle()
        {
            bundle = AssetBundle.LoadFromFile(Directory.GetCurrentDirectory() + "\\Assets\\mybundle");
            amongUsDrip = bundle.LoadAsset<AudioClip>("drip").DontUnload();
        }
    }
}