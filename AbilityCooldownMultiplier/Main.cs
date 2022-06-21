using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper;
using Il2CppSystem.Collections.Generic;
using MelonLoader;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Extensions;

[assembly: MelonInfo(typeof(AbilityCooldownMultiplier.Main), "Ability Cooldown Multiplier", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace AbilityCooldownMultiplier
{
    public class Main : BloonsTD6Mod
    {
        public static ModSettingBool enabled = new ModSettingBool(true)
        {
            displayName = "Enabled"
        };

        public static ModSettingDouble multiplier = new ModSettingDouble(0.5)
        {
            displayName = "Multiplier",
            minValue = 0.1,
            maxValue = 10,
            isSlider = false
        };

        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            if (enabled)
            {
                foreach (var tower in gameModel.towers)
                {
                    foreach (var ability in tower.GetAbilites())
                    {
                        ability.Cooldown *= (float)multiplier;
                    }
                }
            }
        }
    }
}