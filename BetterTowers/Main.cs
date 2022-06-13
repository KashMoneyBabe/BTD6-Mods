using System.Linq;
using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Mods;
using Assets.Scripts.Models.Towers.Projectiles;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Extensions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

[assembly: MelonInfo(typeof(BetterTowers.Main), "Better Towers", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace BetterTowers
{
    public class Main : BloonsTD6Mod
    {
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            foreach (var towerModel in gameModel.towers)
            {
                if (towerModel.IsHero())
                {
                    foreach (var upgrade in towerModel.appliedUpgrades)
                    {
                        // +2% range per upgrade, total +48.6%
                        towerModel.range *= 1.02f;
                        foreach (var attack in towerModel.GetAttackModels())
                        {
                            attack.range *= 1.02f;
                        }

                        // +2.5% fire rate per upgrade, total +65.9%
                        foreach (var weapon in towerModel.GetWeapons())
                        {
                            weapon.rate *= 0.975f;
                        }

                        // +5% pierce per upgrade, total +165.33%
                        foreach (var proj in towerModel.GetDescendants<ProjectileModel>().ToList())
                        {
                            proj.pierce *= 1.05f;
                        }
                    }
                    if (towerModel.tier == 20)
                    {
                        // +2% range per upgrade, total +48.6%
                        towerModel.range *= 1.02f;
                        foreach (var attack in towerModel.GetAttackModels())
                        {
                            attack.range *= 1.02f;
                        }

                        // +2.5% fire rate per upgrade, total +65.9%
                        foreach (var weapon in towerModel.GetWeapons())
                        {
                            weapon.rate *= 0.975f;
                        }

                        // +5% pierce per upgrade, total +165.33%
                        foreach (var proj in towerModel.GetDescendants<ProjectileModel>().ToList())
                        {
                            proj.pierce *= 1.05f;
                        }
                    }
                }

                if (!towerModel.IsHero())
                {
                    foreach (var upgrade in towerModel.appliedUpgrades)
                    {
                        // +2.5% range per upgrade, total +21.84%
                        towerModel.range *= 1.025f;
                        foreach (var attack in towerModel.GetAttackModels())
                        {
                            attack.range *= 1.025f;
                        }

                        // +5% fire rate per upgrade, total +50.734%
                        foreach (var weapon in towerModel.GetWeapons())
                        {
                            weapon.rate *= 0.95f;
                        }

                        // +10% pierce per upgrade, total +114.36%
                        foreach (var proj in towerModel.GetDescendants<ProjectileModel>().ToList())
                        {
                            proj.pierce *= 1.1f;
                        }
                    }
                    if (towerModel.tier == 5)
                    {
                        // +2.5% range per upgrade, total +21.84%
                        towerModel.range *= 1.025f;
                        foreach (var attack in towerModel.GetAttackModels())
                        {
                            attack.range *= 1.025f;
                        }

                        // +5% fire rate per upgrade, total +50.734%
                        foreach (var weapon in towerModel.GetWeapons())
                        {
                            weapon.rate *= 0.95f;
                        }

                        // +10% pierce per upgrade, total +114.36%
                        foreach (var proj in towerModel.GetDescendants<ProjectileModel>().ToList())
                        {
                            proj.pierce *= 1.1f;
                        }
                    }
                }
            }
        }
    }
}