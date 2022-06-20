using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Mods;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using Assets.Scripts.Models.Bloons.Behaviors;

[assembly: MelonInfo(typeof(BetterGlue.Main), "Better Glue", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BetterGlue
{
    public class Main : BloonsTD6Mod
    {
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            foreach (var towerModel in gameModel.GetTowersWithBaseId(TowerType.GlueGunner))
            {
                if (towerModel.tiers[0] == 1)
                {
                    if (!towerModel.GetWeapon().projectile.HasBehavior<AddBehaviorToBloonModel>())
                    {
                        var dmgovertime = new DamageOverTimeModel("DamageOverTimeModel_" + towerModel.baseId + towerModel.tiers[0] + towerModel.tiers[1] + towerModel.tiers[2], 1f, 5f, 0, null, -1.0f, false, 0, false, 0, false, false, null);
                        var addcorrosive = new AddBehaviorToBloonModel("AddBehaviorToBloonModel_" + towerModel.baseId + towerModel.tiers[0] + towerModel.tiers[1] + towerModel.tiers[2], "CorrosiveDot", 11f, 9999999, null, null, null, "GlueBasic", true, false, false, false, 2, false, 0);
                        addcorrosive.AddBehavior(dmgovertime);
                        towerModel.GetWeapon().projectile.AddBehavior(addcorrosive);

                        var collisionArray = new UnhollowerBaseLib.Il2CppStructArray<int>(3) { };
                        collisionArray[0] = -1;
                        collisionArray[1] = 0;
                        collisionArray[2] = 1;
                        towerModel.GetWeapon().projectile.collisionPasses = collisionArray;
                    }
                }
                if (towerModel.tiers[2] >= 1)
                {
                    towerModel.GetWeapon().projectile.GetBehavior<SlowModel>().Multiplier *= 0.8f;
                    towerModel.GetWeapon().projectile.GetBehavior<SlowModel>().Mutator.multiplier *= 0.8f;
                }
                if (towerModel.tiers[1] >= 2)
                {
                    towerModel.GetWeapon().projectile.pierce *= 1.5f;
                    towerModel.GetWeapon().projectile.radius *= 1.25f;
                    towerModel.GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.pierce *= 1.5f;
                    towerModel.GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.radius *= 1.25f;
                }

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

            }
        }
    }
}