using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;
using Terraria.ModLoader.Config.UI;
using Terraria.UI;

namespace TweaksForVanilla
{
  public class Config : ModConfig
  {
    public override ConfigScope Mode => ConfigScope.ServerSide;

    public static Config Instance;

    [DefaultValue(true)]
    [Label("Accessories social slottable.")]
    [Tooltip("Allows all accessories to be equipped in social slots. Requires a reload.")]
    [ReloadRequired]
    public bool SocialSlotAccessories { get; set; }

    [DefaultValue(true)]
    [Label("Make nurse always happy.")]
    [Tooltip("Sets nurse to love all npcs and biomes. Requires a reload.")]
    [ReloadRequired]
    public bool NurseHappiness { get; set; }

    [DefaultValue(true)]
    [Label("No tombstones.")]
    [Tooltip("Disables the dropping of a tombstone on death.")]
    public bool DontDropTombstones { get; set; }

    [DefaultValue(true)]
    [Label("Add tombstone recipes.")]
    [Tooltip("Adds recipes for tombstones.")]
    public bool AddTombstonesRecipes { get; set; }

    //[DefaultValue(true)]
    //[Label("")]
    //[Tooltip("")]

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
