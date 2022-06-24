using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using BTD_Mod_Helper.Api.ModOptions;

[assembly: MelonInfo(typeof(BiggerManaShield.Main), "Bigger Mana Shield", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BiggerManaShield
{
    public class Main : BloonsTD6Mod
    {
        public static ModSettingBool enabledChimps = new ModSettingBool(false) { displayName = "Enabled in Impoppable/Chimps" };

        public static ModSettingInt ManaShield = new ModSettingInt(50)
        {
            displayName = "Mana Shield Value",
            minValue = 0,
            maxValue = 1000,
            isSlider = false
        };
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            if (!enabledChimps)
            {
                if (gameModel.startingShield > 0)
                {
                    gameModel.maxShield = ManaShield;
                    gameModel.startingShield = ManaShield;
                }
            }
            else
            {
                gameModel.maxShield = ManaShield;
                gameModel.startingShield = ManaShield;
            }
        }
    }
}