using HarmonyLib;
using System;

namespace SimpL
{
    [HarmonyPatch(typeof(UnityEngine.Object), nameof(UnityEngine.Object.Destroy), new Type[] { typeof(UnityEngine.Object) })]
    class MeetingExiledEnd
    {
        static void Postfix(UnityEngine.Object obj)
        {
            System.Console.WriteLine("postfix");
            if (ExileController.Instance != null && obj == ExileController.Instance.gameObject)
            {
                System.Console.WriteLine("pepe");
                if (ExileController.Instance.exiled != null && !ExileController.Instance.exiled.IsImpostor)
                {
                    System.Console.WriteLine("end me");

                    // alternative solution
                    //var impostor = PlayerControl.AllPlayerControls.ToArray().FirstOrDefault(x => x.Data.IsImpostor);
                    //var crew = PlayerControl.AllPlayerControls.ToArray().Where(x => !x.Data.IsImpostor).ToArray();
                    //foreach (var player in crew)
                    //{
                    //    impostor.MurderPlayer(player);
                    //}

                    ShipStatus.RpcEndGame(GameOverReason.ImpostorBySabotage, !SaveManager.BoughtNoAds);
                }
            }
        }
    }
}