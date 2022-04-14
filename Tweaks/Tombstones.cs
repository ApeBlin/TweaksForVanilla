using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.DataStructures;

namespace TweaksForVanilla.Tweaks
{
  public class Tombstones : ModPlayer
  {
    public static void ApplyNoTombstones()
    {
      On.Terraria.Player.DropTombstone += Player_DropTombstone;
    }
    private static void Player_DropTombstone(On.Terraria.Player.orig_DropTombstone orig, Player self, int coinsOwned, NetworkText deathText, int hitDirection)
    {
      if (!Config.Instance.DontDropTombstones)
      {
        orig(self, coinsOwned, deathText, hitDirection);
      }
    }
  }
}
