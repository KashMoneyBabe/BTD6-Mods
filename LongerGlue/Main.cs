using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Mods;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Simulation.Bloons.Behaviors;
using Assets.Scripts.Simulation.Towers.Filters;
using Assets.Scripts.Models.Bloons.Behaviors;
using Assets.Scripts.Models.Towers.Mods;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

using Assets.Scripts.Models;
using Assets.Scripts.Models.Effects;
using Assets.Scripts.Models.GenericBehaviors;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Emissions;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using Assets.Scripts.Models.Towers.Projectiles;
using Assets.Scripts.Models.Towers.TowerFilters;
using Assets.Scripts.Models.Towers.Weapons;
using Assets.Scripts.Models.Towers.Weapons.Behaviors;
using Assets.Scripts.Models.Towers.Behaviors.Abilities;

[assembly: MelonInfo(typeof(LongerGlue.Main), "Longer Glue", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace LongerGlue
{
    public class Main : BloonsTD6Mod
    {
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            foreach (var towerModel in gameModel.GetTowersWithBaseId(TowerType.GlueGunner))
            {
                if (towerModel.GetWeapon().projectile.HasBehavior<SlowModel>())
                {
                    var slow = towerModel.GetWeapon().projectile.GetBehavior<SlowModel>();
                    slow.lifespan += 300 * (towerModel.appliedUpgrades.Count + 1); // Glue lasts much longer
                    slow.layers = 9999999; // Glue lasts all layers
                }
                if (towerModel.GetWeapon().projectile.HasBehavior<AddBehaviorToBloonModel>())
                {
                    var dmg = towerModel.GetWeapon().projectile.GetBehavior<AddBehaviorToBloonModel>();
                    dmg.lifespan += 300 * (towerModel.appliedUpgrades.Count + 1); // Corrosive Glue lasts much longer
                    dmg.layers = 9999999; // Corrosive Glue lasts all layers
                }
                if (towerModel.tiers[0] == 1)
                {
                    towerModel.GetWeapon().projectile.pierce += 2;
                }
            }
        }
    }
}