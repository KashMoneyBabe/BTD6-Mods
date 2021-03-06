using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;


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
                if (towerModel.tiers[0] == 5)
                {
                    foreach (var attack in towerModel.GetAttackModels())
                    {
                        foreach (var weapon in attack.weapons)
                        {
                            attack.RemoveWeapon(weapon);
                        }
                    }
                }

                if (towerModel.HasBehavior<RangeSupportModel>())
                {
                    foreach (var behavior in towerModel.GetBehaviors<RangeSupportModel>())
                    {
                        behavior.filters = null;
                        behavior.maxStackSize = 999;
                        behavior.isUnique = false;
                    }
                }
                if (towerModel.HasBehavior<RateSupportModel>())
                {
                    foreach (var behavior in towerModel.GetBehaviors<RateSupportModel>())
                    {
                        behavior.filters = null;
                        behavior.maxStackSize = 999;
                        behavior.isUnique = false;
                    }
                }
                if (towerModel.HasBehavior<PierceSupportModel>())
                {
                    foreach (var behavior in towerModel.GetBehaviors<PierceSupportModel>())
                    {
                        behavior.filters = null;
                        behavior.maxStackSize = 999;
                        behavior.isUnique = false;
                        behavior.pierce += towerModel.tier;
                    }
                }
                if (towerModel.HasBehavior<ProjectileSpeedSupportModel>())
                {
                    foreach (var behavior in towerModel.GetBehaviors<ProjectileSpeedSupportModel>())
                    {
                        behavior.filters = null;
                        behavior.maxStackSize = 999;
                        behavior.isUnique = false;
                        behavior.multiplier = 0.5f;

                    }
                }
                if (towerModel.HasBehavior<AbilityCooldownScaleSupportModel>())
                {
                    foreach (var behavior in towerModel.GetBehaviors<AbilityCooldownScaleSupportModel>())
                    {
                        behavior.filters = null;
                        behavior.maxStackSize = 999;
                        behavior.isUnique = false;
                        behavior.abilityCooldownSpeedScale += 0.15f;
                    }
                }
                if (towerModel.HasBehavior<FreeUpgradeSupportModel>())
                {
                    foreach (var behavior in towerModel.GetBehaviors<FreeUpgradeSupportModel>())
                    {
                        behavior.filters = null;
                        behavior.upgrade += 1;
                    }
                }
            }
        }
    }
}