using HarmonyLib;

namespace SimpL
{
    [HarmonyPatch(typeof(EndGameManager), "SetEverythingUp")]
    class EndgamePatch
    {
        public static void Postfix(EndGameManager __instance)
        {
            System.Console.WriteLine("endgame");

            if (!TempData.DidHumansWin(TempData.EndReason))
            {
                System.Console.WriteLine("play sound");

                SoundManager.Instance.StopAllSound();
                SoundManager.Instance.StopNamedSound("Stinger");
                SoundManager.Instance.PlaySound(SimplBundle.amongUsDrip, false, 1f);
            }
        }
    }
}