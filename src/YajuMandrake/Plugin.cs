using BepInEx;
using BepInEx.Logging;
using HarmonyLib;

// ReSharper disable InconsistentNaming

namespace YajuMandrake;

[BepInAutoPlugin]
public partial class Plugin : BaseUnityPlugin
{
    internal static ManualLogSource Log { get; private set; } = null!;

    private void Awake()
    {
        Log = Logger;
        new Harmony(Info.Metadata.GUID).PatchAll();
        Log.LogInfo($"Plugin {Name} is loaded!");
    }
}

[HarmonyPatch(typeof(Mandrake), nameof(Mandrake.Awake))]
internal static class MandrakeAwakePatch
{
    [HarmonyPostfix]
    private static void Postfix(Mandrake __instance)
    {
        __instance.screamWaitTime = 14.9f;
        Plugin.Log.LogInfo("Mandrake.screamWaitTime modified to 14.9f");
    }
}