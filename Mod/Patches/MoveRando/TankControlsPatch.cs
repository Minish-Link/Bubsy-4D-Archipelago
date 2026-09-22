using Il2CppFabraz.PlayerCharacter.Bubsy;
using HarmonyLib;
using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubsyArchipelagoMod.Patches.MoveRando;

[HarmonyPatch(typeof(BubsyPlayerSystemsController), nameof(BubsyPlayerSystemsController.HandleTankControl))]
public static class TankControlsPatch
{
    //public static void Prefix()
    //{
    //    MelonLogger.Msg("Tankin");
    //}
}