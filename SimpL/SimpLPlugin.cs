using BepInEx;
using BepInEx.IL2CPP;
using HarmonyLib;
using Reactor;

namespace SimpL
{
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    [BepInPlugin(Id, "SimpL Mod", "1.0.0")]
    public class SimpLPlugin : BasePlugin
    {
        public const string Id = "org.bepinex.plugins.SimpLMod";

        public static BepInEx.Logging.ManualLogSource log;
        private readonly Harmony harmony;

        public SimpLPlugin()
        {
            log = Log;

            this.harmony = new Harmony("SimpL Mod");
        }

        public override void Load()
        {
            SimplBundle.LoadBundle();

            this.harmony.PatchAll();
        }
    }
}