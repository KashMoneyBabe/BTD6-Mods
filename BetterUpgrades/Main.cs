using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Mods;
using Assets.Scripts.Models.Towers.Projectiles;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

[assembly: MelonInfo(typeof(BetterUpgrades.Main), "Better Upgrades", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BetterUpgrades
{
    public class Main : BloonsTD6Mod
    {
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            // Berserker Brew 75% discount
            var berserkBrew = gameModel.GetUpgrade("Berserker Brew");
            berserkBrew.cost = (berserkBrew.cost * 25 / 100) - ((berserkBrew.cost * 25 / 100) % 5);

            // Stronger Stimulant 75% discount
            var strongerStim = gameModel.GetUpgrade("Stronger Stimulant");
            strongerStim.cost = (strongerStim.cost * 25 / 100) - ((strongerStim.cost * 25 / 100) % 5);

            // Permanent Brew 75% discount
            var permBrew = gameModel.GetUpgrade("Permanent Brew");
            permBrew.cost = (permBrew.cost * 25 / 100) - ((permBrew.cost * 25 / 100) % 5);

            // Overclock 75% discount
            var overclock = gameModel.GetUpgrade("Overclock");
            overclock.cost = (overclock.cost * 25 / 100) - ((overclock.cost * 25 / 100) % 5);

            // Ultraboost 75% discount
            var ultraboost = gameModel.GetUpgrade("Ultraboost");
            ultraboost.cost = (ultraboost.cost * 25 / 100) - ((ultraboost.cost * 25 / 100) % 5);

            // Superstorm 25% discount
            var superstorm = gameModel.GetUpgrade("Superstorm");
            superstorm.cost = (superstorm.cost * 75 / 100) - ((superstorm.cost * 75 / 100) % 5);


            // Sniper damage increased
            foreach (var towerModel in gameModel.GetTowersWithBaseId(TowerType.SniperMonkey))
            {
                var damageModel = towerModel.GetWeapon().projectile.GetDamageModel();
                damageModel.damage += (towerModel.appliedUpgrades.Count + 1);
            }

            // Ultravision increased range and see through walls
            foreach (var towerModel in gameModel.GetTowersWithBaseId(TowerType.SuperMonkey))
            {
                if (towerModel.appliedUpgrades.Contains("Ultravision"))
                {
                    towerModel.range += 9;
                    towerModel.ignoreBlockers = true;

                    foreach (var attackModel in towerModel.GetAttackModels())
                    {
                        attackModel.range += 9;
                        attackModel.attackThroughWalls = true;
                        foreach (var weapon in attackModel.weapons)
                        {
                            weapon.projectile.ignoreBlockers = true;
                        }
                    }
                }
            }

            // Superstorm increased range and see through walls
            foreach (var towerModel in gameModel.GetTowersWithBaseId(TowerType.Druid))
            {
                if (towerModel.appliedUpgrades.Contains("Superstorm"))
                {
                    towerModel.range += 12;
                    towerModel.ignoreBlockers = true;

                    foreach (var attackModel in towerModel.GetAttackModels())
                    {
                        attackModel.range += 12;
                        attackModel.attackThroughWalls = true;
                        foreach (var weapon in attackModel.weapons)
                        {
                            weapon.projectile.ignoreBlockers = true;
                        }
                    }

                    foreach (var proj in towerModel.GetDescendants<ProjectileModel>().ToList())
                    {
                        if (proj.display == "2a1d60690a632f543b80280219205247")
                        {
                            proj.pierce += 80000f;
                        }
                    }
                }
            }

            // Night Vision Goggles see through walls
            foreach (var towerModel in gameModel.GetTowersWithBaseId(TowerType.SniperMonkey))
            {
                if (towerModel.appliedUpgrades.Contains("Night Vision Goggles"))
                {
                    towerModel.ignoreBlockers = true;

                    foreach (var attackModel in towerModel.GetAttackModels())
                    {
                        attackModel.attackThroughWalls = true;
                        foreach (var weapon in attackModel.weapons)
                        {
                            weapon.projectile.ignoreBlockers = true;
                        }
                    }
                }
            }

            // Laser Cannon pops lead
            foreach (var towerModel in gameModel.GetTowersWithBaseId(TowerType.DartlingGunner))
            {
                if (towerModel.appliedUpgrades.Contains("Laser Cannon") && !towerModel.appliedUpgrades.Contains("Plasma Accelerator"))
                {
                    towerModel.GetWeapon().projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
                }
            }

            // Armor Piercing Darts hits all
            foreach (var towerModel in gameModel.GetTowersWithBaseId(TowerType.MonkeySub))
            {
                if (towerModel.appliedUpgrades.Contains("Armor Piercing Darts"))
                {
                    towerModel.GetWeapon().projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                }
            }
        }
    }
}