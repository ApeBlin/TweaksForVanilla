using Terraria;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.ModLoader;

namespace TweaksForVanilla.Tweaks
{
  public class Nurse : GlobalNPC
  { 
    static readonly int[] townNPCs = { 22, 17, 38, 207, 369, 633, 20, 227, 588, 19, 550, 353, 107, 228, 54, 124, 208, 108, 441, 160, 229, 178, 209, 142, 663 };
    public override void SetDefaults(NPC npc)
    {
      if(npc.type == NPCID.Nurse && Config.Instance.NurseHappiness)
      {
        // Sets Nurse to love all biomes
        // Will do shorter if I find a way to go through all biomes :)
        npc.Happiness.SetBiomeAffection<CorruptionBiome>(AffectionLevel.Love);
        npc.Happiness.SetBiomeAffection<CrimsonBiome>(AffectionLevel.Love);
        npc.Happiness.SetBiomeAffection<DesertBiome>(AffectionLevel.Love);
        npc.Happiness.SetBiomeAffection<DungeonBiome>(AffectionLevel.Love);
        npc.Happiness.SetBiomeAffection<ForestBiome>(AffectionLevel.Love);
        npc.Happiness.SetBiomeAffection<HallowBiome>(AffectionLevel.Love);
        npc.Happiness.SetBiomeAffection<JungleBiome>(AffectionLevel.Love);
        npc.Happiness.SetBiomeAffection<MushroomBiome>(AffectionLevel.Love);
        npc.Happiness.SetBiomeAffection<OceanBiome>(AffectionLevel.Love);
        npc.Happiness.SetBiomeAffection<SnowBiome>(AffectionLevel.Love);
        npc.Happiness.SetBiomeAffection<UndergroundBiome>(AffectionLevel.Love);

        // Sets Nurse to love all town NPCs
        foreach (var townNPC in townNPCs)
        {
          npc.Happiness.SetNPCAffection(townNPC,AffectionLevel.Love);
        }
      }
    }
  }
}
