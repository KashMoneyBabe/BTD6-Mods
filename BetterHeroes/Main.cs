using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Models.Bloons.Behaviors;
using Assets.Scripts.Models.Towers.Projectiles.Behaviors;

[assembly: MelonInfo(typeof(BetterHeroes.Main), "Better Heroes", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BetterHeroes
{
    public class Main : BloonsTD6Mod
    {
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            foreach (var towerModel in gameModel.towers)
            {
                if (towerModel.IsHero() && !towerModel.baseId.Contains("Etienne") && !towerModel.baseId.Contains("Psi"))
                {
                    towerModel.range *= 1.25f;
                    foreach (var attackModel in towerModel.GetAttackModels())
                    {
                        attackModel.range *= 1.25f;
                        foreach (var weapon in attackModel.weapons)
                        {
                            weapon.rate *= 0.667f;
                        }
                    }
                }

                if (towerModel.IsHero() && towerModel.baseId.Contains("Etienne"))
                {
                    towerModel.range *= 1.25f;

                    foreach (var attackModel in towerModel.GetAttackModels())
                    {
                        attackModel.range *= 1.25f;
                    }

                    foreach (var droneAttackModel in towerModel.GetBehavior<DroneSupportModel>().droneModel.GetAttackModels())
                    {
                        foreach (var weapon in droneAttackModel.weapons)
                        {
                            weapon.rate *= 0.667f;
                        }
                    }
                }

                if (towerModel.IsHero() && towerModel.baseId.Contains("Benjamin"))
                {
                    towerModel.cost = towerModel.cost * 50 / 100 - (towerModel.cost * 50 / 100) % 5;
                }

                if (towerModel.IsHero() && towerModel.baseId.Contains("Psi"))
                {
                    foreach (var attackModel in towerModel.GetAttackModels())
                    {
                        foreach (var weapon in attackModel.weapons)
                        {
                            weapon.rate *= 0.5f;
                            //if (weapon.projectile.HasBehavior<PsiEffectModel>())
                            //{
                            //    weapon.projectile.GetBehavior<PsiEffectModel>().damagePerTick *= 2;
                            //}
                            //if (weapon.projectile.HasBehavior<PsiBloonBehaviorModel>())
                            //{
                            //    weapon.projectile.GetBehavior<PsiBloonBehaviorModel>().damagePerTick *= 2;
                            //}
                            //if (weapon.projectile.HasBehavior<CreateProjectileOnContactModel>())
                            //{
                            //    if (weapon.projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.HasBehavior<PsiEffectModel>())
                            //    {
                            //        weapon.projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetBehavior<PsiEffectModel>().damagePerTick *= 2;
                            //    }
                            //    if (weapon.projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.HasBehavior<PsiBloonBehaviorModel>())
                            //    {
                            //        weapon.projectile.GetBehavior<CreateProjectileOnContactModel>().projectile.GetBehavior<PsiBloonBehaviorModel>().damagePerTick *= 2;
                            //    }
                            //}
                        }
                    }
                }

                if (towerModel.IsHero() && towerModel.baseId.Contains("Geraldo"))
                {
                    towerModel.cost = towerModel.cost * 75 / 100 - (towerModel.cost * 75 / 100) % 5;
                    foreach (var attackModel in towerModel.GetAttackModels())
                    {
                        foreach (var weapon in attackModel.weapons)
                        {
                            weapon.rate *= 0.667f;
                        }
                    }
                }

                if (towerModel.IsHero() && towerModel.baseId.Contains("Adora"))
                {
                    towerModel.AddBehavior(new OverrideCamoDetectionModel("OverrideCamoDetectionModel_", true));
                    foreach (var attackModel in towerModel.GetAttackModels())
                    {
                        foreach (var weapon in attackModel.weapons)
                        {
                            if (weapon.projectile.HasBehavior<DamageModel>())
                            {
                                var damageModel = weapon.projectile.GetDamageModel();
                                damageModel.immuneBloonProperties = BloonProperties.None;
                                weapon.projectile.SetHitCamo(true);
                            }
                        }
                    }

                }

                if (towerModel.IsHero() && towerModel.baseId.Contains("CaptainChurchill"))
                {
                    towerModel.cost = towerModel.cost * 75 / 100 - (towerModel.cost * 75 / 100) % 5;
                    towerModel.ignoreBlockers = true;
                    foreach (var attackModel in towerModel.GetAttackModels())
                    {
                        attackModel.attackThroughWalls = true;
                        foreach (var weapon in attackModel.weapons)
                        {
                            weapon.projectile.ignoreBlockers = true;
                            foreach (var damageModel in weapon.projectile.GetBehaviors<DamageModel>())
                            {
                                damageModel.immuneBloonProperties = BloonProperties.None;
                            }
                        }
                    }
                }

                if (towerModel.IsHero() && towerModel.baseId.Contains("Quincy"))
                {
                    foreach (var attackModel in towerModel.GetAttackModels())
                    {
                        foreach (var weapon in attackModel.weapons)
                        {
                            weapon.rate *= 0.667f;
                        }
                    }
                }

            }
        }
    }
}