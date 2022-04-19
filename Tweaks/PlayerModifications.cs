using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Personalities;

namespace TweaksForVanilla.Tweaks
{
  public class PlayerModifications : ModPlayer
  {
    // IF I GET THIS WORKING, MIGHT AS WELL REMOVE THE NURSE HAPPINESS THANG
    public override void ModifyNursePrice(NPC nurse, int health, bool removeDebuffs, ref int price)
    {
      bool UseVanilla = !Config.Instance.ModdedNursePricing;
      bool HappinessAdjustsPrice = Config.Instance.HappinessChangesPrice;
      int BasePricePerHealthPoint = 1;
      int MaxPrice = 100000;
      int RemoveDebuffPrice = 100;
      NPCHappiness nurseHappiness = NPCHappiness.Get(NPCID.Nurse);
      int[] vanillaDebuffs = {20,21,22,23,24,25,30,31,32,33,35,36,37,
                              38,39,44,46,47,67,68,69,70,72,80,86,88,
                              94,103,119,120,137,144,145,148,149,153,
                              156,160,163,164,169,183,186,189,192,194,
                              195,196,197,199,203,204,307,309,310,313,
                              315,316,319,320,323,324,326,332,333,334,337};

      if (Player.statLife == Player.statLifeMax)  // Dont do anything if life is full
      {
        return;
      }

      // Vanilla pricing as far as I can tell
      if (UseVanilla)
      {
        health = Player.statLifeMax - Player.statLife;  // Heal for how much life is missing
        price = 1 * health; // Price of healing 1 life point
        removeDebuffs = true;

        foreach (int debuff in vanillaDebuffs)
          // 86(Potion sickness),199(Water Candle),21(Creative Shock)
          // are not removable debuffs and thus cost no extra
          if (Player.HasBuff(debuff) && debuff != 86 && debuff != 199 && debuff != 21)
            price += 100;

        if (!HappinessAdjustsPrice)
        {
          // This does nothing, find a way to make it do something
          if (false)// nurse happiness == hate
          {
            price = (int)(price * 1.12f);
          }
          if (false)// nurse happiness == dislike
          {
            price = (int)(price * 1.06f);
          }
          if (false)// nurse happiness == like
          {
            price = (int)(price * 0.94f);
          }
          if (false)// nurse happiness == love
          {
            price = (int)(price * 0.88f);
          }
        }

        if (NPC.downedGolemBoss)
          price *= 200;
        else if (NPC.downedPlantBoss)
          price *= 150;
        else if (NPC.downedMechBossAny)
          price *= 100;
        else if (Main.hardMode)
          price *= 60;
        else if (NPC.downedBoss3 || NPC.downedQueenBee)
          price *= 25;
        else if (NPC.downedBoss2)
          price *= 10;
        else if (NPC.downedBoss1)
          price *= 3;
      }


      // Modded pricing
      if (!UseVanilla)
      {
        health = Player.statLifeMax - Player.statLife;  // Heal for how much life is missing
        price = BasePricePerHealthPoint * health; // Price of healing 1 life point
        removeDebuffs = true;
        foreach (int debuff in vanillaDebuffs)
        {
          if (Player.HasBuff(debuff))
          {
            price += RemoveDebuffPrice;
          }
        }
      }

      // Set max price for healing
      if (price > MaxPrice)
      {
        price = MaxPrice;
      }
    }
  }
}
