using HarmonyLib;

namespace SimpL
{
    [HarmonyPatch(typeof(EndGameManager), "SetEverythingUp")]
    class EndgamePatch
    {
        public static void Postfix(EndGameManager __instance)
        {
            if (!TempData.DidHumansWin(TempData.EndReason))
            {
                SoundManager.Instance.StopAllSound();
                SoundManager.Instance.StopNamedSound("Stinger");
                SoundManager.Instance.PlaySound(SimplBundle.amongUsDrip, false, 1f);
            }
        }
    }
}