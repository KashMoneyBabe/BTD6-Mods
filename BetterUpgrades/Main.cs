using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Mods;
using Assets.Scripts.Models.Towers.Projectiles;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using BTD_Mod_Helper.Api.ModOptions;

[assembly: MelonInfo(typeof(BetterUpgrades.Main), "Better Upgrades", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BetterUpgrades
{
    public class Main : BloonsTD6Mod
    {
        public static ModSettingBool cheaperAlch = new ModSettingBool(true)
        {
            displayName = "Cheaper Alchemist Upgrades"
        };
        public static ModSettingBool cheaperEng = new ModSettingBool(true)
        {
            displayName = "Cheaper Engineer Upgrades"
        };
        public static ModSettingDouble alchMultiplier = new ModSettingDouble(0.25)
        {
            displayName = "Alchemist Upgrades Prices Multiplier",
            minValue = 0,
            maxValue = 1,
            isSlider = true
        };
        public static ModSettingDouble engMultiplier = new ModSettingDouble(0.25)
        {
            displayName = "Engineer Upgrades Prices Multiplier",
            minValue = 0,
            maxValue = 1,
            isSlider = true
        };

        public static ModSettingBool ultravisionBuff = new ModSettingBool(true)
        {
            displayName = "Ultravision Buff"
        };
        public static ModSettingBool superstormBuffs = new ModSettingBool(true)
        {
            displayName = "Superstorm Buffs"
        };
        public static ModSettingBool sniperBuffs = new ModSettingBool(true)
        {
            displayName = "Sniper Buffs"
        };
        public static ModSettingBool laserBuffs = new ModSettingBool(true)
        {
            displayName = "Laser Buffs"
        };
        public static ModSettingBool armorPiercingBuffs = new ModSettingBool(true)
        {
            displayName = "Armor Piercing Buffs"
        };


        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            if (cheaperAlch)
            {
                // Berserker Brew discount
                var berserkBrew = gameModel.GetUpgrade("Berserker Brew");
                berserkBrew.cost = (int)(berserkBrew.cost * (float)alchMultiplier);

                // Stronger Stimulant discount
                var strongerStim = gameModel.GetUpgrade("Stronger Stimulant");
                strongerStim.cost = (int)(strongerStim.cost * (float)alchMultiplier);

                // Permanent Brew discount
                var permBrew = gameModel.GetUpgrade("Permanent Brew");
                permBrew.cost = (int)(permBrew.cost * (float)alchMultiplier);
            }

            if (cheaperEng)
            {
                // Overclock discount
                var overclock = gameModel.GetUpgrade("Overclock");
                overclock.cost = (int)(overclock.cost * (float)engMultiplier);

                // Ultraboost discount
                var ultraboost = gameModel.GetUpgrade("Ultraboost");
                ultraboost.cost = (int)(ultraboost.cost * (float)engMultiplier);
            }

            if (superstormBuffs)
            {
                // Superstorm 25% discount
                var superstorm = gameModel.GetUpgrade("Superstorm");
                superstorm.cost = (superstorm.cost * 75 / 100) - ((superstorm.cost * 75 / 100) % 5);
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
            }

            if (ultravisionBuff)
            {
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
            }

            if (sniperBuffs)
            {
                // Sniper damage increased
                foreach (var towerModel in gameModel.GetTowersWithBaseId(TowerType.SniperMonkey))
                {
                    var damageModel = towerModel.GetWeapon().projectile.GetDamageModel();
                    damageModel.damage += towerModel.appliedUpgrades.Count;

                    if (towerModel.tiers[0] == 3)
                    {
                        damageModel.damage += 20; // 20->40
                    }
                    if (towerModel.tiers[0] == 4)
                    {
                        damageModel.damage += 70; // 30->100
                    }
                    if (towerModel.tiers[0] == 5)
                    {
                        damageModel.damage += 160; // 80->240
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
            }

            if (laserBuffs)
            {
                // Laser Cannon pops lead
                foreach (var towerModel in gameModel.GetTowersWithBaseId(TowerType.DartlingGunner))
                {
                    if (towerModel.appliedUpgrades.Contains("Laser Cannon") && !towerModel.appliedUpgrades.Contains("Plasma Accelerator"))
                    {
                        towerModel.GetWeapon().projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
                    }
                }
                // Laser Blasts pops lead
                foreach (var towerModel in gameModel.GetTowersWithBaseId(TowerType.SuperMonkey))
                {
                    if (towerModel.appliedUpgrades.Contains("Laser Blasts") && !towerModel.appliedUpgrades.Contains("Plasma Blasts"))
                    {
                        towerModel.GetWeapon().projectile.GetDamageModel().immuneBloonProperties = BloonProperties.Purple;
                    }
                }
            }

            if (armorPiercingBuffs)
            {
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
}