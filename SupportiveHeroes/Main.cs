using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.TowerFilters;
using UnhollowerBaseLib;

[assembly: MelonInfo(typeof(SupportiveHeroes.Main), "Supportive Heroes", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace SupportiveHeroes
{
    public class Main : BloonsTD6Mod
    {
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            foreach (var towerModel in gameModel.towers)
            {
                if (towerModel.IsHero())
                {
                    var rateBuff = new RateSupportModel("RateSupportModel_" + towerModel.baseId, towerModel.tier == 0 ? 1f / 1.025f : 1f / (towerModel.tier * .025f + 1), true, "Village:HomelandDefense_" + towerModel.baseId, true, 1, new Il2CppReferenceArray<TowerFilterModel>(0), "CallToArmsBuff", "BuffIconHomelandDefense")
                    {
                        onlyShowBuffIfMutated = false,
                        isUnique = true,
                        maxStackSize = 999,
                        isGlobal = true
                    };
                    var rangeBuff = new RangeSupportModel("RangeSupportModel_" + towerModel.baseId, true, towerModel.tier == 0 ? 0.0125f : 0.0125f * towerModel.tier, 0f, "Range:Support_" + towerModel.baseId, new Il2CppReferenceArray<TowerFilterModel>(0), true, "BiggerRadiusBuff", "BuffIconVillage1xx")
                    {
                        onlyShowBuffIfMutated = false,
                        isUnique = true,
                        maxStackSize = 999,
                        isGlobal = true
                    };
                    towerModel.AddBehavior(rateBuff);
                    towerModel.AddBehavior(rangeBuff);
                }
            }
        }
    }
}