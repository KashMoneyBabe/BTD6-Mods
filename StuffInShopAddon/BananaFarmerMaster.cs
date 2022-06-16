using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Towers;

namespace Banana_Farmer_In_Shop
{
    public class BananaFarmerMaster : ModTower
    {
        public override SpriteReference PortraitReference => Game.instance.model.GetPowerWithName("BananaFarmer").icon;
        public override SpriteReference IconReference => Game.instance.model.GetPowerWithName("BananaFarmer").icon;
        public override string TowerSet => SUPPORT;
        public override string BaseTower => TowerType.BananaFarmer;
        public override int Cost => 10000;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Master Banana Farmer";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        { }
    }
}