using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers.Mods;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.ModOptions;
using Il2CppSystem.Collections.Generic;
using MelonLoader;

[assembly: MelonInfo(typeof(LivesUnlocker.Main), "Lives Unlocker", "1.0.0", "KashMoneyBabe")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]
namespace LivesUnlocker
{
    public class Main : BloonsTD6Mod
    {
        public static ModSettingBool enabledChimps = new ModSettingBool(false) { displayName = "Enabled in Impoppable/Chimps" };
        public override void OnNewGameModel(GameModel gameModel, List<ModModel> mods)
        {
            if (!enabledChimps)
            {
                if (mods[1].name != "Clicks" && mods[1].name != "Impoppable" && gameModel.startingHealth > 1)
                {
                    gameModel.maxHealth = float.MaxValue;
                    gameModel.softcapHealthPercentModifier = 1f;
                    gameModel.maxSoftcapHealth = float.MaxValue;
                }
            }
            else
            {
                gameModel.maxHealth = float.MaxValue;
                gameModel.softcapHealthPercentModifier = 1f;
                gameModel.maxSoftcapHealth = float.MaxValue;
            }

        }
    }
}