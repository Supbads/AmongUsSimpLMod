using HarmonyLib;

namespace SimpL
{
    //function called on start of game. write version text on menu
    [HarmonyPatch(typeof(VersionShower), nameof(VersionShower.Start))]
    public static class VersionStartPatch
    {
        static void Postfix(VersionShower __instance)
        {
            __instance.text.Text = "Among Us SimpL Mod";
        }
    }

    [HarmonyPatch(typeof(PingTracker), nameof(PingTracker.Update))]
    public static class PingPatch
    {
        public static void Postfix(PingTracker __instance)
        {
            __instance.text.Text += "\nAmong Us SimpL Mod";
        }
    }
}
