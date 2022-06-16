using Assets.Scripts.Models.Towers;
using Assets.Scripts.Models.Towers.Behaviors;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;

namespace Banana_Farmer_In_Shop
{
    public class LivesFarmerMaster : ModTower
    {
        public override SpriteReference PortraitReference => Game.instance.model.GetPowerWithName("TechBot").icon;
        public override SpriteReference IconReference => Game.instance.model.GetPowerWithName("TechBot").icon;
        public override string TowerSet => SUPPORT;
        public override string BaseTower => TowerType.BananaFarmer;
        public override int Cost => 10000;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Master Lives Farmer";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            var bonusLives = new BonusLivesPerRoundModel("BonusLivesPerRoundModel_" + towerModel.baseId, 100, 1.25f, "eb70b6823aec0644c81f873e94cb26cc");
            towerModel.AddBehavior(bonusLives);
        }
    }
}