using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace DysonSphereProgram.Modding.StarterTemplate
{
  [BepInPlugin(GUID, NAME, VERSION)]
  [BepInProcess("DSPGAME.exe")]
  public class Plugin : BaseUnityPlugin
  {
    public const string GUID = "sg.shawnkoh.LazyRobot";
    public const string NAME = "LazyRobot";
    public const string VERSION = "1.0.0";

    private Harmony _harmony;
    internal static ManualLogSource Log;

    private void Awake()
    {
      Plugin.Log = Logger;
      _harmony = new Harmony(GUID);
      Logger.LogInfo("StarterTemplate Awake() called");
    }

    private void OnDestroy()
    {
      Logger.LogInfo("StarterTemplate OnDestroy() called");
      _harmony?.UnpatchSelf();
      Plugin.Log = null;
    }
  }
}
