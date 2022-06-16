using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

[assembly: MelonInfo(typeof(DruidLuck.Main), "Druid Luck", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace DruidLuck
{
    public class Main : BloonsTD6Mod
    {
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            foreach (var towerModel in gameModel.GetTowersWithBaseId(TowerType.Druid))
            {
                float income = towerModel.appliedUpgrades.Count * 32f;
                if (towerModel.tier == 5) income += 1500f;
                if (towerModel.tier == 0) income += 20;

                var cashGeneration = new PerRoundCashBonusTowerModel("PerRoundCashBonusTowerModel_" + towerModel.baseId + towerModel.tiers[0] + towerModel.tiers[1] + towerModel.tiers[2], income, 0.0f, 1.0f, "80178409df24b3b479342ed73cffb63d", false);
                towerModel.AddBehavior(cashGeneration);
            }
        }
    }
}