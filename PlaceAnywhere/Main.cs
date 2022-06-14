using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Mods;
using Assets.Scripts.Models.Towers.Behaviors;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

[assembly: MelonInfo(typeof(PlaceAnywhere.Main), "Place Anywhere", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace PlaceAnywhere
{
    public class Main : BloonsTD6Mod
    {
        public static ModSettingBool enabled = new ModSettingBool(true) { displayName = "Enabled" };

        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            if (enabled)
            {
                // Areas
                foreach (var area in gameModel.map.areas)
                {
                    area.isDisabled = false;
                }

                // Towers
                foreach (var towerModel in gameModel.towers)
                {
                    if (towerModel.HasBehavior<RectangleFootprintModel>()) towerModel.footprint = gameModel.GetTower(TowerType.DartMonkey, 0, 0, 0).footprint.Duplicate();
                }

                foreach (var towerModel in gameModel.towers)
                {
                    towerModel.radius = 0;
                    towerModel.radiusSquared = 0;

                    towerModel.footprint.ignoresPlacementCheck = true;
                    towerModel.footprint.ignoresTowerOverlap = true;
                    towerModel.footprint.doesntBlockTowerPlacement = true;

                    if (towerModel.HasBehavior<CircleFootprintModel>())
                    {
                        towerModel.GetBehavior<CircleFootprintModel>().radius = 0f;
                    }

                    towerModel.areaTypes = new UnhollowerBaseLib.Il2CppStructArray<Assets.Scripts.Models.Map.AreaType>(5);
                    towerModel.areaTypes[0] = Assets.Scripts.Models.Map.AreaType.ice;
                    towerModel.areaTypes[1] = Assets.Scripts.Models.Map.AreaType.land;
                    towerModel.areaTypes[2] = Assets.Scripts.Models.Map.AreaType.water;
                    towerModel.areaTypes[3] = Assets.Scripts.Models.Map.AreaType.track;
                    towerModel.areaTypes[4] = Assets.Scripts.Models.Map.AreaType.unplaceable;
                }

                // Powers
                foreach (var power in gameModel.powers)
                {
                    if (power != null && power.tower != null)
                    {
                        if (power.tower.HasBehavior<RectangleFootprintModel>()) power.tower.footprint = gameModel.GetTower(TowerType.DartMonkey, 0, 0, 0).footprint.Duplicate();
                    }
                }

                foreach (var power in gameModel.powers)
                {
                    if (power != null && power.tower != null)
                    {
                        power.tower.radius = 0;
                        power.tower.radiusSquared = 0;

                        power.tower.footprint.ignoresPlacementCheck = true;
                        power.tower.footprint.ignoresTowerOverlap = true;
                        power.tower.footprint.doesntBlockTowerPlacement = true;


                        if (power.tower.HasBehavior<CircleFootprintModel>())
                        {
                            power.tower.GetBehavior<CircleFootprintModel>().radius = 0f;
                        }

                        power.tower.areaTypes = new UnhollowerBaseLib.Il2CppStructArray<Assets.Scripts.Models.Map.AreaType>(5);
                        power.tower.areaTypes[0] = Assets.Scripts.Models.Map.AreaType.ice;
                        power.tower.areaTypes[1] = Assets.Scripts.Models.Map.AreaType.land;
                        power.tower.areaTypes[2] = Assets.Scripts.Models.Map.AreaType.water;
                        power.tower.areaTypes[3] = Assets.Scripts.Models.Map.AreaType.track;
                        power.tower.areaTypes[4] = Assets.Scripts.Models.Map.AreaType.unplaceable;
                    }
                }
            }
        }
    }
}
