﻿using Assets.Scripts.Models;
using Assets.Scripts.Models.Towers;
using Assets.Scripts.Unity;
using Assets.Scripts.Utils;
using BTD_Mod_Helper.Api.Towers;
using Il2CppSystem.Collections.Generic;
using UnhollowerBaseLib;

namespace BTD6_Paragon_Sentry_In_Shop
{
    public class ParagonSentry : ModTower
    {
        public override SpriteReference PortraitReference => Game.instance.model.GetTowerWithName("SentryParagon").portrait;
        public override SpriteReference IconReference => Game.instance.model.GetTowerWithName("SentryParagon").portrait;
        public override string TowerSet => SUPPORT;
        public override string BaseTower => TowerType.SentryParagon;
        public override int Cost => 5000;
        public override int TopPathUpgrades => 0;
        public override int MiddlePathUpgrades => 0;
        public override int BottomPathUpgrades => 0;
        public override string Description => "Paragon Sentry";

        public override void ModifyBaseTowerModel(TowerModel towerModel)
        {
            towerModel.radius = 6;
            towerModel.radiusSquared = 36;
            towerModel.footprint.doesntBlockTowerPlacement = false;
            var temp = new List<Model>();
            foreach (var behavior in towerModel.behaviors)
                if (behavior.name != "TowerExpireModel_") temp.Add(behavior);
            towerModel.behaviors = (Il2CppReferenceArray<Model>)temp.ToArray();
        }
    }
}