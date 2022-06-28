using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;
using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Bloons.Behaviors;
using System.Linq;


[assembly: MelonInfo(typeof(CustomizerMod.Main), "Customizer Mod", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace CustomizerMod
{
    // see challenge editor and put as many configurations as possible in this mod
    public class Main : BloonsTD6Mod
    {
        // Global Switch
        public static ModSettingBool globalEnabled = new ModSettingBool(true)
        {
            displayName = "Enabled Global"
        };

        // Game Stuff
        // Starting Cash Switch
        public static ModSettingBool startingCashEnabled = new ModSettingBool(false)
        {
            displayName = "Starting Cash Enabled"
        };
        // Starting Cash Multiplier
        public static ModSettingDouble startingCashMultiplier = new ModSettingDouble(1)
        {
            displayName = "Starting Cash Multiplier",
            minValue = 0,
            maxValue = 100,
            isSlider = true
        };
        // Starting Lives Switch
        public static ModSettingBool startingLivesEnabled = new ModSettingBool(false)
        {
            displayName = "Starting Lives Enabled"
        };
        // Starting Lives Multiplier
        public static ModSettingDouble startingLivesMultiplier = new ModSettingDouble(1)
        {
            displayName = "Starting Lives Multiplier",
            minValue = 0,
            maxValue = 100,
            isSlider = true
        };
        // Removable Switch
        public static ModSettingBool removableEnabled = new ModSettingBool(false)
        {
            displayName = "Removable Enabled"
        };
        // Removable Multiplier
        public static ModSettingDouble removableMultiplier = new ModSettingDouble(1)
        {
            displayName = "Removable Multiplier",
            minValue = 0,
            maxValue = 100,
            isSlider = true
        };

        // Tower Stuff
        // Ability Switch
        public static ModSettingBool towerAbilityEnabled = new ModSettingBool(false)
        {
            displayName = "Tower Ability Cooldown Enabled"
        };
        // Ability Multiplier
        public static ModSettingDouble towerAbilityMultiplier = new ModSettingDouble(1)
        {
            displayName = "Tower Ability Cooldown Multiplier",
            minValue = 0,
            maxValue = 100,
            isSlider = true
        };
        // Tower Fire Rate Switch
        public static ModSettingBool towerFireRateEnabled = new ModSettingBool(false)
        {
            displayName = "Tower Fire Rate Enabled"
        };
        // Tower Fire Rate Multiplier
        public static ModSettingDouble towerFireRateMultiplier = new ModSettingDouble(1)
        {
            displayName = "Tower Fire Rate Multiplier",
            minValue = 0.01,
            maxValue = 100,
            isSlider = true
        };



        // Tower Damage Switch
        public static ModSettingBool towerDamageEnabled = new ModSettingBool(false)
        {
            displayName = "Tower Damage Enabled"
        };
        // Tower Damage Multiplier
        public static ModSettingDouble towerDamageMultiplier = new ModSettingDouble(1)
        {
            displayName = "Tower Damage Multiplier",
            minValue = 0.01,
            maxValue = 100,
            isSlider = true
        };


        // Tower Pierce Switch
        public static ModSettingBool towerPierceEnabled = new ModSettingBool(false)
        {
            displayName = "Tower Pierce Enabled"
        };
        // Tower Pierce Multiplier
        public static ModSettingDouble towerPierceMultiplier = new ModSettingDouble(1)
        {
            displayName = "Tower Pierce Multiplier",
            minValue = 0.01,
            maxValue = 100,
            isSlider = true
        };


        // Tower Range Switch
        public static ModSettingBool towerRangeEnabled = new ModSettingBool(false)
        {
            displayName = "Tower Range Enabled"
        };
        // Tower Range Multiplier
        public static ModSettingDouble towerRangeMultiplier = new ModSettingDouble(1)
        {
            displayName = "Tower Range Multiplier",
            minValue = 0.01,
            maxValue = 100,
            isSlider = true
        };
        // Tower Projectile Switch
        public static ModSettingBool towerProjectileEnabled = new ModSettingBool(false)
        {
            displayName = "Projectile Speed Enabled"
        };
        // Tower Projectile Multiplier
        public static ModSettingDouble towerProjectileMultiplier = new ModSettingDouble(1)
        {
            displayName = "Projectile Speed Multiplier",
            minValue = 0.01,
            maxValue = 100,
            isSlider = true
        };


        // Tower Bomb Radius Switch
        public static ModSettingBool towerBombRadiusEnabled = new ModSettingBool(false)
        {
            displayName = "Tower Bomb Radius Enabled"
        };
        // Tower Bomb Radius Multiplier
        public static ModSettingDouble towerBombRadiusMultiplier = new ModSettingDouble(1)
        {
            displayName = "Tower Bomb Radius Multiplier",
            minValue = 0.01,
            maxValue = 100,
            isSlider = true
        };

        // Tower Price Switch
        public static ModSettingBool towerPriceEnabled = new ModSettingBool(false)
        {
            displayName = "Tower Price Enabled"
        };
        // Tower Price Multiplier
        public static ModSettingDouble towerPriceMultiplier = new ModSettingDouble(1)
        {
            displayName = "Tower Price Multiplier",
            minValue = 0.0,
            maxValue = 100,
            isSlider = true
        };

        // Tower Upgrade Price Switch
        public static ModSettingBool towerUpgradePriceEnabled = new ModSettingBool(false)
        {
            displayName = "Tower Upgrades Price Enabled"
        };
        // Tower Upgrade Price Multiplier
        public static ModSettingDouble towerUpgradePriceMultiplier = new ModSettingDouble(1)
        {
            displayName = "Tower Upgrades Price Multiplier",
            minValue = 0.0,
            maxValue = 100,
            isSlider = true
        };

        // Tower Sell Multiplier Switch
        public static ModSettingBool towerSellMultiplierEnabled = new ModSettingBool(false)
        {
            displayName = "Tower Sell Multiplier Enabled"
        };
        // Tower Sell Multiplier
        public static ModSettingDouble towerSellMultiplier = new ModSettingDouble(0.7)
        {
            displayName = "Tower Sell Multiplier",
            minValue = 0.05,
            maxValue = 0.95,
            isSlider = true
        };



        // Bloon Stuff
        // Ceramic Health Switch
        public static ModSettingBool bloonCeramicHealthEnabled = new ModSettingBool(false)
        {
            displayName = "Ceramic Health Enabled"
        };
        // Ceramic Health Multiplier
        public static ModSettingDouble bloonCeramicHealthMultiplier = new ModSettingDouble(1)
        {
            displayName = "Ceramic Health Multiplier",
            minValue = 0.001,
            maxValue = 1000,
            isSlider = true
        };

        // Moab Health Switch
        public static ModSettingBool bloonMoabHealthEnabled = new ModSettingBool(false)
        {
            displayName = "Moab Health Enabled"
        };
        // Moab Health Multiplier
        public static ModSettingDouble bloonMoabHealthMultiplier = new ModSettingDouble(1)
        {
            displayName = "Moab Health Multiplier",
            minValue = 0.001,
            maxValue = 1000,
            isSlider = true
        };

        // Bloon Speed Switch
        public static ModSettingBool bloonSpeedEnabled = new ModSettingBool(false)
        {
            displayName = "Bloon Speed Enabled"
        };
        // Bloon Speed Multiplier
        public static ModSettingDouble bloonSpeedMultiplier = new ModSettingDouble(1)
        {
            displayName = "Bloon Speed Multiplier",
            minValue = 0.01,
            maxValue = 100,
            isSlider = true
        };
        // Moab Speed Switch
        public static ModSettingBool bloonMoabSpeedEnabled = new ModSettingBool(false)
        {
            displayName = "Moab Speed Enabled"
        };
        // Moab Speed Multiplier
        public static ModSettingDouble bloonMoabSpeedMultiplier = new ModSettingDouble(1)
        {
            displayName = "Moab Speed Multiplier",
            minValue = 0.01,
            maxValue = 100,
            isSlider = true
        };
        // Bloon Regrow Switch
        public static ModSettingBool bloonRegrowEnabled = new ModSettingBool(false)
        {
            displayName = "Bloon Regrow Enabled"
        };
        // Bloon Regrow Multiplier
        public static ModSettingDouble bloonRegrowMultiplier = new ModSettingDouble(1)
        {
            displayName = "Bloon Regrow Multiplier",
            minValue = 0.01,
            maxValue = 100,
            isSlider = true
        };

        // Bloon Density Switch
        public static ModSettingBool bloonDensityEnabled = new ModSettingBool(false)
        {
            displayName = "Bloon Density Enabled"
        };
        // Bloon Density Multiplier
        public static ModSettingInt bloonDensityMultiplier = new ModSettingInt(1)
        {
            displayName = "Bloon Density Multiplier",
            minValue = 1,
            maxValue = 100,
            isSlider = true
        };

        // Bloon Camo Switch
        public static ModSettingBool bloonAllCamoEnabled = new ModSettingBool(false)
        {
            displayName = "Bloon All Camo Enabled"
        };
        // Bloon Regrow Switch
        public static ModSettingBool bloonAllRegrowEnabled = new ModSettingBool(false)
        {
            displayName = "Bloon All Regrow Enabled"
        };
        // Bloon Fortified Switch
        public static ModSettingBool bloonAllFortifiedEnabled = new ModSettingBool(false)
        {
            displayName = "Bloon All Fortified Enabled"
        };



        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            if (globalEnabled)
            {
                if (startingCashEnabled)
                    gameModel.cash *= (float)startingCashMultiplier;
                if (startingLivesEnabled)
                    gameModel.startingHealth *= (float)startingLivesMultiplier;
                if (towerSellMultiplierEnabled)
                    gameModel.sellMultiplier = (float)towerSellMultiplier;

                if (removableEnabled)
                {
                    foreach (var removable in gameModel.map.removeables)
                    {
                        removable.removealCost = (int)((float)removable.removealCost * (float)removableMultiplier);
                    }
                }
                if (towerUpgradePriceEnabled)
                {
                    foreach (var upgrade in gameModel.upgrades)
                    {
                        upgrade.cost = (int)((float)upgrade.cost * (float)towerUpgradePriceMultiplier);
                    }
                }

                if (towerRangeEnabled || towerPriceEnabled || towerAbilityEnabled || towerFireRateEnabled || towerDamageEnabled || towerPierceEnabled || towerBombRadiusEnabled || towerProjectileEnabled)
                {
                    foreach (var tower in gameModel.towers)
                    {
                        if (towerRangeEnabled)
                            tower.range *= (float)towerRangeMultiplier;
                        if (towerPriceEnabled)
                            tower.cost *= (float)towerPriceMultiplier;

                        if (towerAbilityEnabled)
                        {
                            foreach (var ability in tower.GetAbilites())
                            {
                                ability.Cooldown *= (float)towerAbilityMultiplier;
                            }
                        }
                        if (towerRangeEnabled)
                        {
                            foreach (var attack in tower.GetAttackModels())
                            {
                                attack.range *= (float)towerRangeMultiplier;
                            }
                        }
                        if (towerFireRateEnabled)
                        {
                            foreach (var weapon in tower.GetWeapons())
                            {
                                weapon.rate *= 1f / (float)towerFireRateMultiplier;
                            }
                        }
                        if (towerDamageEnabled || towerPierceEnabled || towerBombRadiusEnabled || towerProjectileEnabled)
                        {
                            foreach (var proj in tower.GetDescendants<ProjectileModel>().ToList())
                            {
                                if (towerDamageEnabled)
                                    if (proj.HasBehavior<DamageModel>())
                                        proj.GetBehavior<DamageModel>().damage *= (float)towerDamageMultiplier;
                                if (towerPierceEnabled)
                                    proj.pierce *= (float)towerPierceMultiplier;
                                if (towerProjectileEnabled)
                                    if (proj.HasBehavior<TravelStraitModel>())
                                        proj.GetBehavior<TravelStraitModel>().Speed *= (float)towerProjectileMultiplier;

                                if (towerBombRadiusEnabled)
                                    if (proj.id == "Explosion")
                                        proj.radius *= (float)towerBombRadiusMultiplier;
                            }
                        }
                    }
                }


                if (bloonCeramicHealthEnabled || bloonMoabHealthEnabled || bloonSpeedEnabled || bloonMoabSpeedEnabled || bloonRegrowEnabled)
                {
                    foreach (var bloon in gameModel.bloons)
                    {
                        if (bloonCeramicHealthEnabled)
                            if (bloon.name.Contains("Ceramic"))
                                bloon.maxHealth *= (float)bloonCeramicHealthMultiplier;
                        if (bloonMoabHealthEnabled)
                            if (bloon.isMoab)
                                bloon.maxHealth *= (float)bloonMoabHealthMultiplier;
                        if (bloonSpeedEnabled)
                            if (!bloon.isMoab)
                                bloon.speed *= (float)bloonSpeedMultiplier;
                        if (bloonMoabSpeedEnabled)
                            if (bloon.isMoab)
                                bloon.speed *= (float)bloonMoabSpeedMultiplier;
                        if (bloonRegrowEnabled)
                            if (bloon.HasBehavior<GrowModel>())
                                bloon.GetBehavior<GrowModel>().rate *= 1f / (float)bloonRegrowMultiplier;
                    }
                }

                if (bloonDensityEnabled)
                {
                    foreach (var roundSet in gameModel.roundSets)
                    {
                        for (int i = 0; i < roundSet.rounds.Count; i++)
                        {
                            foreach (var group in roundSet.rounds[i].groups)
                            {
                                group.count *= bloonDensityMultiplier;
                            }
                            roundSet.rounds[i] = new RoundModel("", roundSet.rounds[i].groups);
                        }
                    }
                }

                if (bloonAllCamoEnabled || bloonAllRegrowEnabled || bloonAllFortifiedEnabled)
                {
                    if (mods[1].name != "Sandbox")
                    {
                        string[] isCamoDisabled = new string[] { "Bad", "BadFortified", "Bfb", "BfbFortified", "Moab", "MoabFortified", "Zomg", "ZomgFortified" };
                        string[] isFortifiedDisabled = new string[] { "Black", "BlackCamo", "BlackRegrow", "BlackRegrowCamo", "Blue", "BlueCamo", "BlueRegrow", "BlueRegrowCamo",
                        "Green", "GreenCamo", "GreenRegrow", "GreenRegrowCamo", "Pink", "PinkCamo", "PinkRegrow", "PinkRegrowCamo", "Purple", "PurpleCamo", "PurpleRegrow",
                        "PurpleRegrowCamo", "Rainbow", "RainbowCamo", "RainbowRegrow", "RainbowRegrowCamo", "Red", "RedCamo", "RedRegrow", "RedRegrowCamo", "White",
                        "WhiteCamo", "WhiteRegrow", "WhiteRegrowCamo", "Yellow", "YellowCamo", "YellowRegrow", "YellowRegrowCamo", "Zebra", "ZebraCamo", "ZebraRegrow",
                        "ZebraRegrowCamo" };
                        string[] isRegrowDisabled = new string[] { "Bad", "BadFortified", "Bfb", "BfbFortified", "Ddt", "DdtFortified", "DdtCamo", "DdtFortifiedCamo", "Moab",
                        "MoabFortified", "Zomg", "ZomgFortified" };
                        string[] allBloonsArray = new string[] { "Bad", "BadFortified", "Bfb", "BfbFortified", "Black", "BlackCamo", "BlackRegrow", "BlackRegrowCamo", "Blue",
                        "BlueCamo", "BlueRegrow", "BlueRegrowCamo", "Ceramic", "CeramicCamo", "CeramicFortified", "CeramicFortifiedCamo", "CeramicRegrow", "CeramicRegrowCamo",
                        "CeramicRegrowFortified", "CeramicRegrowFortifiedCamo", "Ddt", "DdtFortified", "DdtCamo", "DdtFortifiedCamo", "Green", "GreenCamo", "GreenRegrow",
                        "GreenRegrowCamo", "Lead", "LeadCamo", "LeadFortified", "LeadFortifiedCamo", "LeadRegrow", "LeadRegrowCamo", "LeadRegrowFortified",
                        "LeadRegrowFortifiedCamo", "Moab", "MoabFortified", "Pink", "PinkCamo", "PinkRegrow", "PinkRegrowCamo", "Purple", "PurpleCamo", "PurpleRegrow",
                        "PurpleRegrowCamo", "Rainbow", "RainbowCamo", "RainbowRegrow", "RainbowRegrowCamo", "Red", "RedCamo", "RedRegrow", "RedRegrowCamo", "White",
                        "WhiteCamo", "WhiteRegrow", "WhiteRegrowCamo", "Yellow", "YellowCamo", "YellowRegrow", "YellowRegrowCamo", "Zebra", "ZebraCamo", "ZebraRegrow",
                        "ZebraRegrowCamo", "Zomg", "ZomgFortified" };

                        var isCamoDisabledList = isCamoDisabled.ToList();
                        var isFortifiedDisabledList = isFortifiedDisabled.ToList();
                        var isRegrowDisabledList = isRegrowDisabled.ToList();
                        var allBloonsList = allBloonsArray.ToList();

                        foreach (var roundSet in gameModel.roundSets)
                        {
                            for (int i = 0; i < roundSet.rounds.Count; i++)
                            {
                                foreach (var group in roundSet.rounds[i].groups)
                                {
                                    if (allBloonsList.Contains(group.bloon))
                                    {
                                        var originalName = group.bloon;

                                        var wasRegrow = group.bloon.Contains("Regrow");
                                        var wasFortified = group.bloon.Contains("Fortified");
                                        var wasCamo = group.bloon.Contains("Camo");

                                        group.bloon = group.bloon.Replace("Camo", "");
                                        group.bloon = group.bloon.Replace("Fortified", "");
                                        group.bloon = group.bloon.Replace("Regrow", "");


                                        if (bloonAllRegrowEnabled)
                                        {
                                            foreach (string toRegrow in allBloonsList.Except(isRegrowDisabledList).ToList())
                                            {
                                                if (originalName == toRegrow)
                                                {
                                                    if (!group.bloon.Contains("Regrow"))
                                                    {
                                                        group.bloon += "Regrow";
                                                        gameModel.bloonsByName[originalName].isGrow |= bloonAllRegrowEnabled;
                                                    }
                                                    wasRegrow = false;

                                                    if (wasFortified)
                                                    {
                                                        group.bloon += "Fortified";
                                                        gameModel.bloonsByName[originalName].isFortified |= bloonAllFortifiedEnabled;
                                                        wasFortified = false;
                                                    }

                                                    if (wasCamo)
                                                    {
                                                        group.bloon += "Camo";
                                                        gameModel.bloonsByName[originalName].isCamo |= bloonAllFortifiedEnabled;
                                                        wasCamo = false;
                                                    }
                                                    break;
                                                }
                                            }
                                        }

                                        if (bloonAllFortifiedEnabled)
                                        {
                                            foreach (string toFortify in allBloonsList.Except(isFortifiedDisabledList).ToList())
                                            {
                                                if (originalName == toFortify)
                                                {
                                                    if (wasRegrow)
                                                    {
                                                        group.bloon += "Regrow";
                                                        gameModel.bloonsByName[originalName].isGrow |= bloonAllRegrowEnabled;
                                                        wasRegrow = false;
                                                    }

                                                    if (!group.bloon.Contains("Fortified"))
                                                    {
                                                        group.bloon += "Fortified";
                                                        gameModel.bloonsByName[originalName].isFortified |= bloonAllFortifiedEnabled;
                                                    }
                                                    wasFortified = false;

                                                    if (wasCamo)
                                                    {
                                                        group.bloon += "Camo";
                                                        gameModel.bloonsByName[originalName].isCamo |= bloonAllFortifiedEnabled;
                                                        wasCamo = false;
                                                    }
                                                    break;
                                                }
                                            }
                                        }

                                        if (bloonAllCamoEnabled)
                                        {
                                            foreach (string toCamo in allBloonsList.Except(isCamoDisabledList).ToList())
                                            {
                                                if (originalName == toCamo)
                                                {
                                                    if (wasRegrow)
                                                    {
                                                        group.bloon += "Regrow";
                                                        gameModel.bloonsByName[originalName].isGrow |= bloonAllRegrowEnabled;
                                                        wasRegrow = false;
                                                    }
                                                    if (wasFortified)
                                                    {
                                                        group.bloon += "Fortified";
                                                        gameModel.bloonsByName[originalName].isFortified |= bloonAllFortifiedEnabled;
                                                        wasFortified = false;
                                                    }

                                                    if (!group.bloon.Contains("Camo"))
                                                    {
                                                        group.bloon += "Camo";
                                                        gameModel.bloonsByName[originalName].isCamo |= bloonAllFortifiedEnabled;
                                                    }
                                                    wasCamo = false;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                roundSet.rounds[i] = new RoundModel("", roundSet.rounds[i].groups);
                            }
                        }
                    }
                }
            }
        }
    }
}