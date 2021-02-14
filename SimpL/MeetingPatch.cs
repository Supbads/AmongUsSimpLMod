using HarmonyLib;
using System;

namespace SimpL
{
    [HarmonyPatch(typeof(UnityEngine.Object), nameof(UnityEngine.Object.Destroy), new Type[] { typeof(UnityEngine.Object) })]
    class MeetingExiledEnd
    {
        static void Postfix(UnityEngine.Object obj)
        {
            if (ExileController.Instance != null && obj == ExileController.Instance.gameObject)
            {
                if (ExileController.Instance.exiled != null && !ExileController.Instance.exiled.IsImpostor)
                {
                    // alternative solution
                    //var imposter = PlayerControl.AllPlayerControls.ToArray().FirstOrDefault(x => x.Data.IsImpostor);
                    //var crew = PlayerControl.AllPlayerControls.ToArray().Where(x => !x.Data.IsImpostor).ToArray();
                    //foreach (var player in crew)
                    //{
                    //    imposter.MurderPlayer(player);
                    //}

                    ShipStatus.RpcEndGame(GameOverReason.ImpostorBySabotage, !SaveManager.BoughtNoAds);
                }
            }
        }
    }
}