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

[assembly: MelonInfo(typeof(BetterVillage.Main), "Better Village", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BetterVillage
{
    public class Main : BloonsTD6Mod
    {
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            foreach (var towerModel in gameModel.GetTowersWithBaseId(TowerType.MonkeyVillage))
            {
                towerModel.range *= 1.5f;
                foreach (var attack in towerModel.GetAttackModels())
                {
                    attack.range *= 1.5f;
                }
                if (towerModel.HasBehavior<RangeSupportModel>())
                {
                    foreach (var behavior in towerModel.GetBehaviors<RangeSupportModel>())
                    {
                        behavior.maxStackSize = 999;
                        behavior.isUnique = false;
                    }
                }
                if (towerModel.HasBehavior<RateSupportModel>())
                {
                    foreach (var behavior in towerModel.GetBehaviors<RateSupportModel>())
                    {
                        behavior.maxStackSize = 999;
                        behavior.isUnique = false;
                    }
                }

                float income = towerModel.appliedUpgrades.Count * 100f;
                if (towerModel.tier == 5) income += 2000f;
                if (towerModel.tier == 0) income += 50f;

                var cashGeneration = new PerRoundCashBonusTowerModel("PerRoundCashBonusTowerModel_" + towerModel.baseId + towerModel.tiers[0] + towerModel.tiers[1] + towerModel.tiers[2], income, 0.0f, 1.0f, "80178409df24b3b479342ed73cffb63d", false);
                towerModel.AddBehavior(cashGeneration);

            }
        }
    }
}