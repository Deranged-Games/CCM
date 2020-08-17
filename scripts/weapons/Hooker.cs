datablock GrenadeProjectileData(HookShot)
{
   projectileShapeName = "grenade.dts";
   emitterDelay        = -1;
   directDamage        = 0.05;
   hasDamageRadius     = true;
   indirectDamage      = 0.05;
   damageRadius        = 1.0;
   radiusDamageType    = $DamageType::RPG;
   kickBackStrength    = 100;

   explosion           = "ChaingunExplosion";
   underwaterExplosion = "ChaingunExplosion";
   velInheritFactor    = 0.5;
   splash              = MissileSplash;
   depthTolerance      = 0.01;
   
   baseEmitter         = TankArtillerySmokeEmitter;
   bubbleEmitter       = GrenadeBubbleEmitter;
   
   grenadeElasticity = 0.0;
   grenadeFriction   = 0.0;
   armingDelayMS     = -1;

   gravityMod        = 0.5;
   muzzleVelocity    = 25.0;
   drag              = 0.2;
   sound	     = ChaingunProjectile;

   hasLight    = true;
   lightRadius = 4;
   lightColor  = "0.05 0.2 0.05";

   hasLightUnderwaterColor = true;
   underWaterLightColor = "0.05 0.075 0.2";
};

datablock ItemData(HookTool)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_elf.dts";
   image        = HookToolImage;
   mass         = 1;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
	pickUpName = "a Grappling tool";

   computeCRC = true;

};

datablock ShapeBaseImageData(HookToolImage)
{
   className = WeaponImage;
   shapeFile = "weapon_elf.dts";
   item = HookerTool;

   projectile = HookShot;
   projectileType = GrenadeProjectile;
   deleteLastProjectile = true;

	usesEnergy = true;
	minEnergy = 3;

   stateName[0]                     = "Activate";
   stateSequence[0]                 = "Activate";
	stateSound[0]                    = TargetingLaserSwitchSound;
   stateTimeoutValue[0]             = 0.5;
   stateTransitionOnTimeout[0]      = "ActivateReady";

   stateName[1]                     = "ActivateReady";
   stateTransitionOnAmmo[1]         = "Ready";
   stateTransitionOnNoAmmo[1]       = "NoAmmo";

   stateName[2]                     = "Ready";
   stateTransitionOnNoAmmo[2]       = "NoAmmo";
   stateTransitionOnTriggerDown[2]  = "Fire";

   stateName[3]                     = "Fire";
	stateEnergyDrain[3]              = 0;
   stateFire[3]                     = true;
   stateAllowImageChange[3]         = false;
   stateScript[3]                   = "onFire";
   stateTransitionOnTriggerUp[3]    = "Deconstruction";
   stateTransitionOnNoAmmo[3]       = "Deconstruction";
   stateSound[3]                    = TargetingLaserPaintSound;

   stateName[4]                     = "NoAmmo";
   stateTransitionOnAmmo[4]         = "Ready";

   stateName[5]                     = "Deconstruction";
   stateScript[5]                   = "deconstruct";
   stateTransitionOnTimeout[5]      = "Ready";
};

function HookToolImage::onmount(%this,%obj,%slot){
   Parent::onMount(%this, %obj, %slot);
   %obj.usingHooker = true;
   bottomPrint(%obj.client, "Using Grappling Tool.",2,1);
}

function HookToolImage::onunmount(%this,%obj,%slot){
   Parent::onUnmount(%this, %obj, %slot);
   %obj.usingHooker = false;
}

function HookShot::onExplode(%data, %proj, %pos, %mod){
   %plyr = %proj.sourceobject;
   echo(%plyr SPC vectorDist(%pos,%plyr.getPosition()));
   if(vectorDist(%pos,%plyr.getPosition()) <= 50){
      %plyr.hooked = true;
      %plyr.hookedlen = vectorDist(%pos,%plyr.getPosition());
      HTAttachedLoop(%plyr,%pos);
      bottomPrint(%plyr.client,"Grapple Point Set",2,1);
   }
   Parent::onExplode(%data, %proj, %pos, %mod);
}

function HookToolImage::onfire(%data,%obj,%slot){
   if(%obj.hooked){
      %obj.hooked = false;
      bottomPrint(%obj.client,"Grapple Released",2,1);
      return;
   }
   %p = Parent::onFire(%data, %obj, %slot);
}

function HTAttachedLoop(%obj,%swingpos){
   if(!isobject(%obj))
	return;
   if(%obj.hooked){
   %pos = %obj.getworldboxcenter();
   %vector = vectorsub(%swingpos,%pos);
   %vector2 = vectorsub(%pos,%swingpos);
   %dist = vectorlen(%vector);
   if(%dist >= %obj.hookedlen){
	%overdist = %dist - %obj.hookedlen;
	%obj.applyimpulse(%pos,vectorscale(vectornormalize(%vector),(%obj.getdatablock().mass * 2 * (%overdist + 1))));
   }
   %obj.rope = new TargetProjectile(){
      dataBlock = BasicTargeter;
      initialDirection = vectornormalize(vectorsub(%pos,%swingpos));
      initialPosition  = %swingpos;
      sourceSlot       = 0;
   }; 
   MissionCleanup.add(%obj.rope); 
   %obj.rope.schedule(49, "delete");
   if(%obj.HookerMode == 2){
      if(%dist > %obj.hookedlen){
         %obj.hookedlen = (%obj.hookedlen + 0.5);
      }
   }
   else{
      %obj.hookedlen = (%obj.hookedlen - 0.2);
      if(%dist < 3){
         %obj.hooked = false;
	 return;
      }
   }
   schedule(50, 0, "HTAttachedLoop", %obj, %swingpos);
   }
}