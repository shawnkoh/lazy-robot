using System.Security;
using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

[module: UnverifiableCode]

namespace LazyRobot
{
    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInProcess("DSPGAME.exe")]
    public class AutoStationConfigPlugin : BaseUnityPlugin
    {
    public const string GUID = "sg.shawnkoh.LazyRobot";
    public const string NAME = "LazyRobot";
    public const string VERSION = "1.0.0";
        // ReSharper disable once MemberCanBePrivate.Global
        public new static ManualLogSource Logger;

        // ReSharper disable once ArrangeTypeMemberModifiers
        void Start()
        {
            Logger = base.Logger;
            AspConfig.Init(Config);
            var harmony = new Harmony(GUID);
            harmony.PatchAll(typeof(PlanetTransportPatch));
            harmony.PatchAll(typeof(BuildingParametersPatch));
            if(AspConfig.General.PatchWarperConfigOnSaveLoad.Value)
                harmony.PatchAll(typeof(GameSavePatch));
            Logger.LogInfo("Loaded!");
        }
    }
}
