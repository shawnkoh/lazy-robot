using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

namespace LazyRobot
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
      Log = Logger;
      _harmony = new Harmony(GUID);
      Logger.LogInfo("LazyRobot Awake() called");
    }

    private void OnDestroy()
    {
      Logger.LogInfo("LazyRobot OnDestroy() called");
      _harmony?.UnpatchSelf();
      Log = null;
    }
  }
}
