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
  //public class ServerConfig : ModConfig
  //{
  //  public override ConfigScope Mode => ConfigScope.ServerSide;

  //}

  public class ClientConfig : ModConfig
  {
    public override ConfigScope Mode => ConfigScope.ClientSide;

    [DefaultValue(true)]
    [Label("Socialize Accessories")]
    [Tooltip("Allows all accessories to be equipped in social slots. Requires a reload")]
    [ReloadRequired]
    public bool SocializeAccessories { get; set; }

    [Label("No tombstones")]
    [Tooltip("Disables the dropping of a tombstone on death")]
    public bool TombstonesDrop { get; set; }

    [Label("Tombstone recipes")]
    [Tooltip("Adds recipes for tombstones")]
    public bool TombstonesRecipe { get; set; }
  }
}
