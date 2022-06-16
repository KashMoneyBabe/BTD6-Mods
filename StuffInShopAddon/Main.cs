using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.TowerFilters;
using UnhollowerBaseLib;

[assembly: MelonInfo(typeof(StuffInShopAddon.Main), "Stuff In Shop Addon", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace StuffInShopAddon
{
    public class Main : BloonsTD6Mod
    {
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            foreach (var towerModel in gameModel.towers)
            {
                if (towerModel.baseId == "StuffInShop-EnergisingTotem")
                {
                    towerModel.RemoveBehavior<RateSupportModel>();
                    var rateBuff = new RateSupportModel("RateSupportModel_EnergisingTotem", 0.875f, false, "Village:HomelandDefense_EnergisingTotem", false, 1, new Il2CppReferenceArray<TowerFilterModel>(0), "CallToArmsBuff", "BuffIconHomelandDefense")
                    {
                        onlyShowBuffIfMutated = false,
                        isUnique = false,
                        maxStackSize = 999,
                    };
                    towerModel.AddBehavior(rateBuff);
                    towerModel.range *= 2;
                    foreach (var attack in towerModel.GetAttackModels())
                    {
                        attack.range *= 2;
                    }

                    towerModel.GetBehavior<EnergisingTotemBehaviorModel>().rounds *= 1000;
                    towerModel.GetBehavior<EnergisingTotemBehaviorModel>().monkeyMoneyCost = 0;
                    for (int i = 1; i <= 5; i++)
                    {
                        towerModel.GetBehavior<EnergisingTotemBehaviorModel>().animationStates[i] = 2;
                    }

                    var camoBuff = new VisibilitySupportModel("VisibilitySupportModel_" + towerModel.baseId, true, "Village:Visibility_" + towerModel.baseId, new Il2CppReferenceArray<TowerFilterModel>(0), "RadarScannerBuff", "BuffIconVillagex2x")
                    {
                        onlyShowBuffIfMutated = false,
                        isUnique = true
                    };
                    towerModel.AddBehavior(camoBuff);
                }

                if (towerModel.baseId == "StuffInShop-BananaFarmer")
                {
                    var cashGeneration = new PerRoundCashBonusTowerModel("PerRoundCashBonusTowerModel_" + towerModel.baseId, 10.0f, 0.0f, 1.0f, "80178409df24b3b479342ed73cffb63d", false);
                    towerModel.AddBehavior(cashGeneration);
                }
                if (towerModel.baseId == "StuffInShopAddon-BananaFarmerExpert")
                {
                    var cashGeneration = new PerRoundCashBonusTowerModel("PerRoundCashBonusTowerModel_" + towerModel.baseId, 100.0f, 0.0f, 1.0f, "80178409df24b3b479342ed73cffb63d", false);
                    towerModel.AddBehavior(cashGeneration);
                }
                if (towerModel.baseId == "StuffInShopAddon-BananaFarmerMaster")
                {
                    var cashGeneration = new PerRoundCashBonusTowerModel("PerRoundCashBonusTowerModel_" + towerModel.baseId, 1000.0f, 0.0f, 1.0f, "80178409df24b3b479342ed73cffb63d", false);
                    towerModel.AddBehavior(cashGeneration);
                }
                if (towerModel.baseId == "StuffInShopAddon-BananaFarmerLegendary")
                {
                    var cashGeneration = new PerRoundCashBonusTowerModel("PerRoundCashBonusTowerModel_" + towerModel.baseId, 10000.0f, 0.0f, 1.0f, "80178409df24b3b479342ed73cffb63d", false);
                    towerModel.AddBehavior(cashGeneration);
                }


                if (towerModel.baseId == "StuffInShopAddon-LivesFarmerExpert")
                {
                    var bonusLives = new BonusLivesPerRoundModel("BonusLivesPerRoundModel_" + towerModel.baseId, 10, 1.25f, "eb70b6823aec0644c81f873e94cb26cc");
                    towerModel.AddBehavior(bonusLives);
                }
                if (towerModel.baseId == "StuffInShopAddon-LivesFarmerMaster")
                {
                    var bonusLives = new BonusLivesPerRoundModel("BonusLivesPerRoundModel_" + towerModel.baseId, 100, 1.25f, "eb70b6823aec0644c81f873e94cb26cc");
                    towerModel.AddBehavior(bonusLives);
                }
                if (towerModel.baseId == "StuffInShopAddon-LivesFarmerLegendary")
                {
                    var bonusLives = new BonusLivesPerRoundModel("BonusLivesPerRoundModel_" + towerModel.baseId, 1000, 1.25f, "eb70b6823aec0644c81f873e94cb26cc");
                    towerModel.AddBehavior(bonusLives);
                }
            }
        }
    }
}