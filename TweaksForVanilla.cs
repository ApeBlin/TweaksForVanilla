using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using TweaksForVanilla.Tweaks;

namespace TweaksForVanilla
{
  public class TweaksForVanilla : Mod
  {
    public override void Load()
    {
      Tombstones.ApplyNoTombstones();
    }

    private Recipe TombstoneRecipe(int graveId, int baseMaterialId)
    {
      return ((Mod)this).CreateRecipe(graveId, 1).AddIngredient(baseMaterialId, 20).AddTile(283);
    }

    public override void AddRecipes()
    {
      if (Config.Instance.AddTombstonesRecipes)
      {
        //  Tombstone
        TombstoneRecipe(321, 3).Register();
        //  Grave Marker
        TombstoneRecipe(1173, 9).AddIngredient(62, 1).Register();
        // Cross Grave Marker
        TombstoneRecipe(1174, 9).Register();
        // Headstone
        TombstoneRecipe(1175, 129).Register();
        // Gravestone
        TombstoneRecipe(1176, 129).AddIngredient(62, 1).Register();
        // Obelisk
        TombstoneRecipe(1177, 173).Register();
        // Golden Tombstone
        TombstoneRecipe(3230, 173).AddIngredient(73, 5).Register();
        // Golden Grave Marker
        TombstoneRecipe(3231, 173).AddIngredient(73, 5).Register();
        // Golden Cross Grave Marker
        TombstoneRecipe(3229, 173).AddIngredient(73, 5).Register();
        // Golden Headstone
        TombstoneRecipe(3233, 173).AddIngredient(73, 5).Register();
        // Golden Gravestone
        TombstoneRecipe(3232, 173).AddIngredient(73, 5).Register();
      }
    }
  }
}