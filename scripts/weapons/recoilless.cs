datablock ParticleData(RecoillessFireEffectSmoke)
{
   dragCoeffiecient     = 0.4;
   gravityCoefficient   = -0.04;   // rises slowly
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 7000;
   lifetimeVarianceMS   = 2000;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -40.0;
   spinRandomMax =  40.0;

   colors[0]     = "0.8 0.8 0.8 0.18";
   colors[1]     = "0.65 0.65 0.65 0.14";
   colors[2]     = "0.6 0.6 0.6 0.07";
   colors[3]     = "0.5 0.5 0.5 0.0";
   sizes[0]      = 0.9;
   sizes[1]      = 1.4;
   sizes[2]      = 2.0;
   sizes[3]      = 3.5;
   times[0]      = 0.0;
   times[1]      = 0.333;
   times[2]      = 0.666;
   times[3]      = 1.0;

};

datablock ParticleEmitterData(RecoillessFireEffectEmitter)
{
   ejectionPeriodMS = 2;
   periodVarianceMS = 0;

   ejectionOffset = 0.0;

   ejectionVelocity = 5.5;
   velocityVariance = 4;

   thetaMin         = 0.0;
   thetaMax         = 10.0;

   lifetimeMS       = 20;

   particles = "RecoillessFireEffectSmoke";

};

//------------------------------------

datablock ParticleData(RecoillessFireEffectDust)
{
   dragCoeffiecient     = 2.0;
   gravityCoefficient   = 0.2;   // rises slowly
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 5000;
   lifetimeVarianceMS   = 1200;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -40.0;
   spinRandomMax =  40.0;

   colors[0]     = "0.53 0.24 0.15 0.4";
   colors[1]     = "0.53 0.24 0.15 0.25";
   colors[2]     = "0.53 0.24 0.15 0.1";
   colors[3]     = "0.53 0.24 0.15 0.0";
   sizes[0]      = 2.0;
   sizes[1]      = 3.0;
   sizes[2]      = 4.0;
   sizes[3]      = 5.0;
   times[0]      = 0.0;
   times[1]      = 0.333;
   times[2]      = 0.666;
   times[3]      = 1.0;

};

datablock ParticleEmitterData(RecoillessDustEffectEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionOffset = 0.0;

   ejectionVelocity = 4;
   velocityVariance = 3;

   thetaMin         = 70.0;
   thetaMax         = 80.0;

   lifetimeMS       = 50;

   particles = "RecoillessFireEffectDust";

};

datablock ParticleData(ACCGSmoke)
{
   dragCoeffiecient     = 0.05;
   gravityCoefficient   = 0.1;
   inheritedVelFactor   = 0.025;

   lifetimeMS           = 1250;
   lifetimeVarianceMS   = 150;

   textureName          = "particleTest";

   useInvAlpha =  true;
   spinRandomMin = -25.0;
   spinRandomMax =  25.0;

   textureName = "special/Smoke/bigSmoke";

   colors[0]     = "0.3 0.3 0.3 1.0";
   colors[1]     = "0.4 0.4 0.4 0.5";
   colors[2]     = "0.5 0.5 0.5 0.0";
   sizes[0]      = 1.0;
   sizes[1]      = 1.5;
   sizes[2]      = 2.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};
datablock ParticleEmitterData(ACCGSmokeEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;

   ejectionOffset = 0.1;

   ejectionVelocity = 4.0;
   velocityVariance = 3.5;

   thetaMin         = 85.0;
   thetaMax         = 90.0;

   lifetimeMS       = 100;

   particles = "ACCGSmoke";

};
datablock ParticleEmitterData(ACCGSmokeEmitter2)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;

   ejectionOffset = 0.1;

   ejectionVelocity = 5.5;
   velocityVariance = 5.5;

   thetaMin         = 0.0;
   thetaMax         = 15.0;

   lifetimeMS       = 150;

   particles = "ACCGSmoke";

};
datablock ExplosionData(ACCGSubExplosion)
{
   explosionShape = "effect_plasma_explosion.dts";
   faceViewer = true;
   delayMS = 0;
   offset = 0.0;
   playSpeed = 2.0;
   sizes[0] = "0.1 0.1 0.1";
   sizes[1] = "0.1 0.1 0.1";
   times[0] = 0.0;
   times[1] = 1.0;

};
datablock ExplosionData(ACCGExplosion)
{
   soundProfile   = plasmaExpSound;
   subExplosion[0] = ACCGSubExplosion;
   emitter[0] = ACCGSmokeEmitter;
   emitter[1] = ACCGSmokeEmitter2;
   shakeCamera = false;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock TracerProjectileData(recoillessbullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.7;
   directDamageType    = $DamageType::recoilless;
   explosion           = ACCGExplosion;
   splash              = ChaingunSplash;
   sniperrifleHeadMultiplier = 2.0;
   closeRangeMultiplier  = 0.8;
   closeRangeDistance = 100;

   hasDamageRadius     = true;
   indirectDamage      = 0.6;
   damageRadius        = 2.0;
   radiusDamageType    = $DamageType::recoilless;

   kickBackStrength  = 5;
   sound             = ChaingunProjectile;

   dryVelocity       = 1200.0;
   wetVelocity       = 100.0;
   velInheritFactor  = 1.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 6000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 40.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.25;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = MG42Decal1;
   decalData[1] = MG42Decal2;
   decalData[2] = MG42Decal3;
   decalData[3] = MG42Decal4;
   decalData[4] = MG42Decal5;
   decalData[5] = MG42Decal6;

   hasLight    = true;
   lightRadius = 5.0;
   lightColor  = "0.5 0.5 0.175";
};

//--------------------------------------------------------------------------
// Ammo
//--------------------------------------

datablock ItemData(recoillessAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_missile.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some XM208 ammo";

   computeCRC = true;

};

datablock ItemData(recoillessClip)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_missile.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "25mm Rifle magazine";
};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(RecoillessrifleImage)
{
   className = WeaponImage;
   shapeFile = "weapon_missile.dts";
   item      = recoilless;
   ammo 	 = recoillessAmmo;
   offset = "-0.05 0.7 -0.22";
   projectile = recoillessbullet;
   projectileType = TracerProjectile;
   emap = true;
	armThread = lookms;
   mass = 10;

   magType = recoillessClip;
   magImage = recoillessClipImage;
   magImageSlot = 4;
   magSize = 3;
   magReloadTime = 3100;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   maxSpread = 25.0 / 1000.0;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = ChaingunSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "CheckWet";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.5;
   stateFire[3] = true;
   stateEmitter[3] = "RecoillessFireEffectEmitter";
   stateEmitterNode[3] = "muzzlepoint1";
   stateEmitterTime[3] = 1; 
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = SniperFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.8;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";
   stateSound[4] = MissileReloadSound;

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = ChaingunDryFireSound;
   stateTimeoutValue[6]        = 1.0;
   stateTransitionOnTimeout[6] = "NoAmmo";
   
   stateName[7]       = "WetFire";
   stateSound[7]      = ChaingunDryFireSound;
   stateTimeoutValue[7]        = 1.0;
   stateTransitionOnTimeout[7] = "Ready";
   
   stateName[8]               = "CheckWet";
   stateTransitionOnWet[8]    = "WetFire";
   stateTransitionOnNotWet[8] = "Fire"; 
};

datablock ItemData(recoilless)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_chaingun.dts";
   image        = RecoillessrifleImage;
   mass         = 1.0;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "a XM208 Anti-Material Rifle";

   computeCRC = true;
   emap = true;
};


datablock ShapeBaseImageData(recoillessImage)
{
   className = WeaponImage;
   ammo = recoillessAmmo;
	armThread = lookms;
   shapeFile = "weapon_grenade_launcher.dts";
   offset = "-0.13 -0.8 -0.05";
   emap = true;
};

datablock ShapeBaseImageData(recoillessImage2)
{
   shapeFile = "ammo_mortar.dts";
   ammo = recoillessAmmo;
	armThread = lookms;
   offset = "-0.29 0.1 0.28";
   rotation = "0 0 1 90";
   emap = true;
};

datablock ShapeBaseImageData(recoillessclipImage)
{
   shapeFile = "ammo_missile.dts";
   ammo = recoillessAmmo;
	armThread = lookms;
   offset = "-0.33 0.45 0.06";
   emap = true;
};

datablock ShapeBaseImageData(recoillessclipImage2)
{
   shapeFile = "ammo_missile.dts";
   ammo = recoillessAmmo;
	armThread = lookms;
   offset = "-0.25 0.45 0.06";
   emap = true;
};

function RecoillessrifleImage::onMount(%this,%obj,%slot)
{
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(recoillessImage, 5);
   %obj.mountImage(recoillessImage2, 6);
   if(%obj.inv[recoillessAmmo] > 2)
      %obj.mountImage(recoillessclipImage, 4);
   else if(%obj.inv[recoillessAmmo] == 2)
      %obj.mountImage(recoillessclipImage2, 4);

   if (%obj.inv[%this.ammo] == 0)
      %obj.Reloading = schedule(10, 0, "WeaponCheckMag", %obj, %this);
}

function RecoillessrifleImage::onUnmount(%this,%obj,%slot)
{
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   if(%obj.getMountedImage(4).getName() !$= "")
      %obj.unmountImage(4);

   cancel(%obj.Reloading);
   %obj.clipreloading = false;
}

function RecoillessrifleImage::onFire(%data, %obj, %slot){
   %data.lightStart = getSimTime();

   %spd = vectorLen(%obj.getVelocity());
   %spread = %data.maxSpread * (%spd / %obj.getDatablock().maxForwardSpeed);
   if(%spread > %data.maxspread)
	%spread = %data.maxspread;
   %vec = %obj.getMuzzleVector(%slot);
   %x = (getRandom() - 0.5) * 2 * 3.1415926 * %spread;
   %y = (getRandom() - 0.5) * 2 * 3.1415926 * %spread;
   %z = (getRandom() - 0.5) * 2 * 3.1415926 * %spread;
   %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
   %vector = MatrixMulVector(%mat, %vec);
   %initialPos = %obj.getMuzzlePoint(%slot);

   %p = new (%data.projectileType)() {
      dataBlock        = %data.projectile;
      initialDirection = %vector;
      initialPosition  = %initialPos;
      sourceObject     = %obj;
      sourceSlot       = %slot;
   };

   %obj.lastProjectile = %p;
   %obj.deleteLastProjectile = %data.deleteLastProjectile;
   MissionCleanup.add(%p);

   if(%obj.client)
      %obj.client.projectile = %p;
   %obj.decInventory(%data.ammo,1);

   %mp = %obj.getMuzzlePoint(%slot);
   %searchresult = containerRayCast(%mp, vectoradd("0 0 -5",%mp), $TypeMasks::TerrainObjectType);
   if(%searchresult){
	%pos = posFromRaycast(%searchresult);
      %emitter = CreateEmitter("0 0 0",RecoillessDustEffectEmitter); 
      %emitter.addTofxGroup();               
      %emitter.setTransform(%pos SPC "0 0 1 0");
	%emitter.schedule(200, delete);
   }

   if(%obj.inv[recoillessAmmo] == 2)
      %obj.mountImage(recoillessclipImage2, 4);
   else if(%obj.inv[recoillessAmmo] < 2)
      if(%obj.getMountedImage(4).getName() !$= "")
         %obj.unmountImage(4);

   if (%obj.inv[%data.ammo] == 0)
      %obj.Reloading = schedule(10, 0, "WeaponCheckMag", %obj, %data);
}


function recoillessbullet::onCollision(%data, %projectile, %targetObject, %modifier, %position, %normal)
{
	// extra damage for head shot or less for close range shots
	if(!(%targetObject.getType() & ($TypeMasks::InteriorObjectType | $TypeMasks::TerrainObjectType)) &&
        (%targetObject.getDataBlock().getClassName() $= "PlayerData"))
	{
	   %damLoc = firstWord(%targetObject.getDamageLocation(%position));
	   %dist = vectorDist(%position, %projectile.sourceObject.getPosition());
	   if (%dist <= %data.closeRangeDistance)
 	   {
		%modifier *= %data.closeRangeMultiplier;
	   }
	   if(%damLoc $= "head")
	   {
		%targetObject.getOwnerClient().headShot = 1;
		%modifier *= %data.sniperrifleHeadMultiplier;
	   }
	   else if(%damLoc $= "legs")
	   {
		%modifier *= 0.5;
	   }
	   else
	   {
		%modifier = 1;
		%targetObject.getOwnerClient().headShot = 0;
	   }
	}

    %targetObject.damage(%projectile.sourceObject, %position, %modifier * %data.directDamage, %data.directDamageType);
}