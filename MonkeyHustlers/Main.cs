using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using BTD_Mod_Helper.Api.ModOptions;

[assembly: MelonInfo(typeof(MonkeyHustlers.Main), "Monkey Hustlers", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace MonkeyHustlers
{
    public class Main : BloonsTD6Mod
    {

        public static ModSettingBool enabledTowers = new ModSettingBool(false)
        {
            displayName = "Enabled For Towers"
        };
        public static ModSettingDouble multiplierTowers = new ModSettingDouble(0.02)
        {
            displayName = "Multiplier For Towers",
            minValue = 0.001,
            maxValue = 1,
            isSlider = true
        };
        public static ModSettingBool enabledHeroes = new ModSettingBool(false)
        {
            displayName = "Enabled For Heroes"
        };
        public static ModSettingDouble multiplierHeroes = new ModSettingDouble(0.02)
        {
            displayName = "Multiplier For Heroes",
            minValue = 0.001,
            maxValue = 1,
            isSlider = true
        };
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            if (enabledHeroes || enabledTowers)
            {
                foreach (var towerModel in gameModel.towers)
                {
                    if (towerModel.HasBehavior<PerRoundCashBonusTowerModel>())
                    {
                        if (!towerModel.IsHero() && enabledTowers)
                        {
                            float totalCost = towerModel.cost;
                            foreach (var appliedUpgrade in towerModel.appliedUpgrades)
                            {
                                totalCost += gameModel.GetUpgrade(appliedUpgrade).cost;
                            }
                            towerModel.GetBehavior<PerRoundCashBonusTowerModel>().cashPerRound += totalCost * (float)multiplierTowers;
                        }
                        if (towerModel.IsHero() && enabledHeroes)
                        {
                            towerModel.GetBehavior<PerRoundCashBonusTowerModel>().cashPerRound += towerModel.cost * (float)multiplierHeroes;
                        }
                    }
                    if (!towerModel.HasBehavior<PerRoundCashBonusTowerModel>())
                    {
                        if (!towerModel.IsHero() && enabledTowers)
                        {
                            float totalCost = towerModel.cost;
                            foreach (var appliedUpgrade in towerModel.appliedUpgrades)
                            {
                                totalCost += gameModel.GetUpgrade(appliedUpgrade).cost;
                            }
                            float income = totalCost * (float)multiplierTowers;
                            var cashGeneration = new PerRoundCashBonusTowerModel("PerRoundCashBonusTowerModel_" + towerModel.baseId + towerModel.tiers[0] + towerModel.tiers[1] + towerModel.tiers[2], income, 0.0f, 1.0f, "80178409df24b3b479342ed73cffb63d", false);
                            towerModel.AddBehavior(cashGeneration);
                        }
                        if (towerModel.IsHero() && enabledHeroes)
                        {
                            float income = towerModel.cost * (float)multiplierHeroes;
                            var cashGeneration = new PerRoundCashBonusTowerModel("PerRoundCashBonusTowerModel_" + towerModel.baseId + towerModel.tiers[0] + towerModel.tiers[1] + towerModel.tiers[2], income, 0.0f, 1.0f, "80178409df24b3b479342ed73cffb63d", false);
                            towerModel.AddBehavior(cashGeneration);
                        }
                    }
                }
            }
        }
    }
}