using Terraria;
using Terraria.ModLoader;

namespace TweaksForVanilla
{
  public class AccessorySocial : GlobalItem
  {
    public override void SetDefaults(Item item)
    {
      if (item.accessory && Config.Instance.SocialSlotAccessories)
      {
        item.canBePlacedInVanityRegardlessOfConditions = true;
      }
    }
  }
}
