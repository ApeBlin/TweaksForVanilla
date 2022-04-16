using System.ComponentModel;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader.Config;


namespace TweaksForVanilla
{
  public class Config : ModConfig
  {
    public override ConfigScope Mode => ConfigScope.ServerSide;

    public static Config Instance;

    // Accessories
    [Header("[i:3097] Accessories")]
    [DefaultValue(true)]
    [Label("Accessories social slottable.")]
    [Tooltip("Allows all accessories to be equipped in social slots. Requires a reload.")]
    [ReloadRequired]
    public bool SocialSlotAccessories { get; set; }

    // NPCs
    [Header("[i:267] NPCs")]
    [DefaultValue(true)]
    [Label("Make nurse always happy.")]
    [Tooltip("Sets nurse to love all npcs and biomes. Requires a reload.")]
    [ReloadRequired]
    public bool NurseHappiness { get; set; }
    [DefaultValue(true)]
    [Label("Use modded variables for nurse pricing.")]
    [Tooltip("Modded variables can be changed below NOT DONE YET")]
    public bool ModdedNursePricing { get; set; }

    // Tombstones
    [Header("[i:321] Tombstones")]
    [DefaultValue(true)]
    [Label("No more tombstones.")]
    [Tooltip("Disables the dropping of a tombstone on death.")]
    public bool DontDropTombstones { get; set; }
    [DefaultValue(true)]
    [Label("Add recipes for tombstones.")]
    [Tooltip("Useful if you disable the drops. (For graveyard biome)")]
    public bool AddTombstonesRecipes { get; set; }

    public override bool AcceptClientChanges(ModConfig pendingConfig, int whoAmI, ref string message)
    {
      if (!IsPlayerLocalServerOwner(whoAmI))
      {
        message = "Sorry, config settings can only be changed by the server owner.";
        return false;
      }
      return true;
    }

    public static bool IsPlayerLocalServerOwner(int whoAmI)
    {
      if (Main.netMode == NetmodeID.MultiplayerClient)
      {
        return Netplay.Connection.Socket.GetRemoteAddress().IsLocalHost();
      }

      for (int i = 0; i < Main.maxPlayers; i++)
      {
        RemoteClient client = Netplay.Clients[i];
        if (client.State == 10 && i == whoAmI && client.Socket.GetRemoteAddress().IsLocalHost())
        {
          return true;
        }
      }
      return false;
    }
  }
}
