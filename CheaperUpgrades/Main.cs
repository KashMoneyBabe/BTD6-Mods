using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using BTD_Mod_Helper.Api.ModOptions;

[assembly: MelonInfo(typeof(CheaperUpgrades.Main), "Cheaper Upgrades", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace CheaperUpgrades
{
    public class Main : BloonsTD6Mod
    {

        public static ModSettingBool cheaperTowers = new ModSettingBool(true)
        {
            displayName = "Cheaper Towers"
        };
        public static ModSettingBool cheaperUpgrades = new ModSettingBool(true)
        {
            displayName = "Cheaper Upgrades"
        };
        public static ModSettingBool cheaperTier5Upgrades = new ModSettingBool(true)
        {
            displayName = "Cheaper Tier 5 Upgrades"
        };

        public static ModSettingDouble towersMultiplier = new ModSettingDouble(0.9)
        {
            displayName = "Tower Price Multiplier",
            minValue = 0,
            maxValue = 1,
            isSlider = true
        };
        public static ModSettingDouble upgradesMultiplier = new ModSettingDouble(0.9)
        {
            displayName = "Upgrade Price Multiplier",
            minValue = 0,
            maxValue = 1,
            isSlider = true
        };
        public static ModSettingDouble tier5UpgradesMultiplier = new ModSettingDouble(0.7)
        {
            displayName = "Tier 5 Upgrade Price Multiplier",
            minValue = 0,
            maxValue = 1,
            isSlider = true
        };
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {

            foreach (var towerModel in gameModel.towers)
            {
                towerModel.cost = towerModel.cost * (float)towersMultiplier;
            }

            foreach (var upgradeModel in gameModel.upgrades)
            {
                if (upgradeModel.tier == 4)
                {
                    upgradeModel.cost = (int)(upgradeModel.cost * (float)tier5UpgradesMultiplier);
                }
                if (upgradeModel.tier == 3)
                {
                    upgradeModel.cost = (int)(upgradeModel.cost * (float)upgradesMultiplier);
                }
                if (upgradeModel.tier == 2)
                {
                    upgradeModel.cost = (int)(upgradeModel.cost * (float)upgradesMultiplier);
                }
                if (upgradeModel.tier == 1)
                {
                    upgradeModel.cost = (int)(upgradeModel.cost * (float)upgradesMultiplier);
                }
                if (upgradeModel.tier == 0)
                {
                    upgradeModel.cost = (int)(upgradeModel.cost * (float)upgradesMultiplier);
                }
            }
        }
    }
}
