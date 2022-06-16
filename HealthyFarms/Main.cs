using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;


using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.TowerFilters;
using UnhollowerBaseLib;

[assembly: MelonInfo(typeof(HealthyFarms.Main), "Healthy Farms", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace HealthyFarms
{
    public class Main : BloonsTD6Mod
    {
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            foreach (var towerModel in gameModel.GetTowersWithBaseId(TowerType.BananaFarm))
            {
                if (towerModel.tier >= 5)
                {
                    if (towerModel.HasBehavior<BonusLivesPerRoundModel>())
                    {
                        towerModel.GetBehavior<BonusLivesPerRoundModel>().amount += 100;
                    }
                    if (!towerModel.HasBehavior<BonusLivesPerRoundModel>())
                    {
                        var bonusLives = new BonusLivesPerRoundModel("BonusLivesPerRoundModel_" + towerModel.baseId + towerModel.tiers[0] + towerModel.tiers[1] + towerModel.tiers[2], 100, 1.25f, "eb70b6823aec0644c81f873e94cb26cc");
                        towerModel.AddBehavior(bonusLives);
                    }
                }
                else
                {
                    if (towerModel.HasBehavior<BonusLivesPerRoundModel>())
                    {
                        towerModel.GetBehavior<BonusLivesPerRoundModel>().amount += towerModel.appliedUpgrades.Count*2;
                    }
                    if (!towerModel.HasBehavior<BonusLivesPerRoundModel>())
                    {
                        var bonusLives = new BonusLivesPerRoundModel("BonusLivesPerRoundModel_" + towerModel.baseId + towerModel.tiers[0] + towerModel.tiers[1] + towerModel.tiers[2], towerModel.appliedUpgrades.Count*2, 1.25f, "eb70b6823aec0644c81f873e94cb26cc");
                        towerModel.AddBehavior(bonusLives);
                    }
                }
            }
        }
    }
}