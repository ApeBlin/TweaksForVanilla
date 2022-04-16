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
      int BasePricePerHealthPoint = 1;
      int MaxPrice = 10000;
      int RemoveDebuffPrice = 100;
      bool UseVanilla = !Config.Instance.ModdedNursePricing;
      int[] vanillaDebuffs = {20,21,22,23,24,25,30,31,32,33,35,36,37,   // Definetly didn't do this by hand
                              38,39,44,46,47,67,68,69,70,72,80,86,88,   // Send help
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
        price = BasePricePerHealthPoint * health; // Price of healing 1 life point
        removeDebuffs = true;
        foreach (int debuff in vanillaDebuffs)
        {
          if (Player.HasBuff(debuff))
          {
            price += RemoveDebuffPrice;
          }
        }
        //  THE CODE BELOW DOESNT ACTUALLY DO SHIT!
        //  NEED TO FIND A WAY TO DO THAT BUT ACTUALLY MAKE IT DO SHIT
        if (nurse.Happiness.ToString() == "Hate")
        {
          price = (int)(price * 1.12f);
        }
        if (nurse.Happiness.ToString() == "Dislike")
        {
          price = (int)(price * 1.06f);
        }
        if (nurse.Happiness.ToString() == "Like")
        {
          price = (int)(price * 0.94f);
        }
        if (nurse.Happiness.ToString() == "Love")
        {
          price = (int)(price * 0.88f);
        }
        //  FIND A WAY TO PROPERLY DO THE ABOVE!!!

        //  NEXT IS THE CHECKING IF A BOSS IS KILLED AND THEN APPLYING THE MULTIPLIER TO PRICE
        //  Eye of Cthulhu beaten 3×
        //  Eater of Worlds / Brain of Cthulhu beaten 10×
        //  Skeletron or Queen Bee beaten 25×
        //  Hardmode entered  60×
        //  Any mechanical boss beaten  100×
        //  Plantera beaten 150×
        //  Golem beaten  200×
        //  NO THIS DOES NOT EQUAL TO MILLIARDS OF COPPER/HEALTH IDIOT!
        //  THE MULTIPLIER APPLIES TO THE PRICE AFTER HAPPINESS
        //  EG. BRAIN OF CTHULU KILLED ITS priceAfterHappinnesMultipliers*10
        //  AND GOLEM KILLED ITS priceAfterHappinnessMultiplieres*200
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
