using System.Linq;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Mods;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using Assets.Scripts.Models.Towers.TowerFilters;
using UnhollowerBaseLib;

[assembly: MelonInfo(typeof(DartClub.Main), "Dart Club", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace DartClub
{
    public class Main : BloonsTD6Mod
    {
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            foreach (var towerModel in gameModel.GetTowersWithBaseId(TowerType.DartMonkey))
            {
                float income = towerModel.appliedUpgrades.Count * 25f;
                if (towerModel.tier == 5) income += 500f;
                if (towerModel.tier == 0) income += 15f;

                var cashGeneration = new PerRoundCashBonusTowerModel("PerRoundCashBonusTowerModel_" + towerModel.baseId + towerModel.tiers[0] + towerModel.tiers[1] + towerModel.tiers[2], income, 0.0f, 1.0f, "80178409df24b3b479342ed73cffb63d", false);
                towerModel.AddBehavior(cashGeneration);
            }
        }
    }
}