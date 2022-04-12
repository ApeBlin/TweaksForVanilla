using Terraria;
using Terraria.ModLoader;

namespace TweaksForVanilla.Tweaks
{
  public class AccessorySocial : GlobalItem
  {
    static bool loadTweak = ModContent.GetInstance<ClientConfig>().SocializeAccessories;
    public override void SetDefaults(Item item)
    {
      if (item.accessory && loadTweak)
      {
        item.canBePlacedInVanityRegardlessOfConditions = true;
      }
    }
  }
}
