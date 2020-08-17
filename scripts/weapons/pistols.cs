//--------------------------------------
// Pistol
//--------------------------------------

datablock AudioProfile(PistolFireSound)
{
   filename    = "fx/vehicles/tank_chaingun.wav";
   description = AudioDefault3d;
   preload = true;
   effect = AssaultChaingunFireEffect;
};

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------------------------------------------

datablock TracerProjectileData(coltBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.15; // z0dd - ZOD, 9-27-02. Was 0.0825
   directDamageType    = $DamageType::pistol;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;

   doDynamicHits	     = 1;
   HeadMultiplier      = 1.5;
   LegsMultiplier      = 0.5;
   closeRangeMultiplier  = 1.2;
   closeRangeDistance = 75;

   kickBackStrength  = 5.0;
   sound 				= ChaingunProjectile;

   //dryVelocity       = 425.0;
   dryVelocity       = 2000.0; // z0dd - ZOD, 8-12-02. Was 425.0
   wetVelocity       = 1750.0;
   velInheritFactor  = 0.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 25.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.09;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = ChaingunDecal1;
   decalData[1] = ChaingunDecal2;
   decalData[2] = ChaingunDecal3;
   decalData[3] = ChaingunDecal4;
   decalData[4] = ChaingunDecal5;
   decalData[5] = ChaingunDecal6;
};

datablock TracerProjectileData(revolverBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.38; // z0dd - ZOD, 9-27-02. Was 0.0825
   directDamageType    = $DamageType::pistol;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;

   doDynamicHits	     = 1;
   HeadMultiplier      = 1.5;
   LegsMultiplier      = 0.5;
   closeRangeMultiplier  = 1.2;
   closeRangeDistance = 75;

   kickBackStrength  = 5.0;
   sound 				= ChaingunProjectile;

   //dryVelocity       = 425.0;
   dryVelocity       = 2000.0; // z0dd - ZOD, 8-12-02. Was 425.0
   wetVelocity       = 1750.0;
   velInheritFactor  = 0.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 25.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.09;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = ChaingunDecal1;
   decalData[1] = ChaingunDecal2;
   decalData[2] = ChaingunDecal3;
   decalData[3] = ChaingunDecal4;
   decalData[4] = ChaingunDecal5;
   decalData[5] = ChaingunDecal6;
};

datablock TracerProjectileData(deagleBullet)
{
   doDynamicClientHits = true;

   directDamage        = 0.42; // z0dd - ZOD, 9-27-02. Was 0.0825
   directDamageType    = $DamageType::pistol;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;

   doDynamicHits	     = 1;
   HeadMultiplier      = 1.5;
   LegsMultiplier      = 0.5;
   closeRangeMultiplier  = 1.2;
   closeRangeDistance = 75;

   kickBackStrength  = 5.0;
   sound 				= ChaingunProjectile;

   //dryVelocity       = 425.0;
   dryVelocity       = 2000.0; // z0dd - ZOD, 8-12-02. Was 425.0
   wetVelocity       = 1750.0;
   velInheritFactor  = 0.0;
   fizzleTimeMS      = 3000;
   lifetimeMS        = 3000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 25.0;
   tracerAlpha     = false;
   tracerMinPixels = 6;
   tracerColor     = 211.0/255.0 @ " " @ 215.0/255.0 @ " " @ 120.0/255.0 @ " 0.75";
	tracerTex[0]  	 = "special/tracer00";
	tracerTex[1]  	 = "special/tracercross";
	tracerWidth     = 0.09;
   crossSize       = 0.20;
   crossViewAng    = 0.990;
   renderCross     = true;

   decalData[0] = ChaingunDecal1;
   decalData[1] = ChaingunDecal2;
   decalData[2] = ChaingunDecal3;
   decalData[3] = ChaingunDecal4;
   decalData[4] = ChaingunDecal5;
   decalData[5] = ChaingunDecal6;
};

//--------------------------------------------------------------------------
// Ammo
//--------------------------------------

datablock ItemData(pistolAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "grenade.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "colt rounds";
};

datablock ItemData(pistolClip)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "grenade.dts";
   mass = 1.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "pistol mags";
};

datablock ItemData(revolverAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "grenade.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "revolver rounds";
};

datablock ItemData(deagleAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "grenade.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "Deagle rounds";
};

datablock ItemData(glockAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "grenade.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "Glock rounds";
};

datablock ItemData(uziAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "grenade.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "uzi rounds";
};

//---------------------------------------------------
// Weapon M9
//---------------------------------------------------
datablock ItemData(M9)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_energy_vehicle.dts";
   image = pistolImage;
   mass = 2;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a M9";
};

datablock ShapeBaseImageData(PistolImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = pistol;
   ammo = pistolAmmo;
   offset = "0 0 0";
   rotation = "0 1 0 180";
   mass = 4;

   magType = Pistolclip;
   magImage = PistolImage;
   magImageSlot = 0;
   magSize = 12;
   magReloadTime = 1800;

   projectile = coltbullet;
   projectileType = tracerProjectile;
   projectileSpread = 4.0 / 1000.0;
   maxSpread = 10 / 1000.0;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = PlasmaSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.1;
   stateFire[3] = true;
   stateEmitter[3] = "GunFireEffectEmitter";
   stateEmitterNode[3] = "muzzlepoint1";
   stateEmitterTime[3] = 1; 
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = PistolFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.15;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = ChaingunDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

function PistolImage::onFire(%data,%obj,%slot) 
{ 
   %obj.decInventory(%data.ammo,1);

   if(%obj.spread $= "" || %obj.spread < %data.projectileSpread)
	%obj.spread = %data.projectileSpread;
   else
      %obj.spread = %obj.spread + (2.5 / 1000);

   if(%obj.lowSpreadLoop $= "")
	%obj.lowSpreadLoop = schedule(250, 0, "RiflelowerSpread", %data, %obj);
   if(%obj.spread > %data.maxspread)
	%obj.spread = %data.maxspread;

    %vector = %obj.getMuzzleVector(%slot);
    %mp = %obj.getMuzzlePoint(%slot);

      %x = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
      %newvector = MatrixMulVector(%mat, %vector);

      %p = new (%data.projectileType)() 
	   {
            dataBlock        = %data.projectile;
            initialDirection = %newvector;
            initialPosition  = %mp;
            sourceObject     = %obj;
		damageFactor	 = 1;
            sourceSlot       = %slot;
         };

   if (%obj.inv[%data.ammo] == 0)
      %obj.Reloading = schedule(10, 0, "WeaponCheckMag", %obj, %data);
}


//---------------------------------------------------
// Weapon Silenced M9
//---------------------------------------------------

datablock ItemData(SM9)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_energy_vehicle.dts";
   image = SPistolImage;
   mass = 2;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a silenced M9";
};

datablock ShapeBaseImageData(SPistolImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = SM9;
   ammo = pistolAmmo;
   offset = "0 0 0";
   rotation = "0 1 0 180";
   mass = 6;

   magType = Pistolclip;
   magImage = SPistolImage;
   magImageSlot = 0;
   magSize = 12;
   magReloadTime = 1500;

   projectile = coltbullet;
   projectileType = tracerProjectile;
   projectileSpread = 0;
   maxSpread = 7 / 1000.0;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = PlasmaSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.1;
   stateFire[3] = true;
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.15;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = ChaingunDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

function SPistolImage::onFire(%data,%obj,%slot) 
{ 
   %obj.decInventory(%data.ammo,1);

   if(%obj.spread $= "" || %obj.spread < %data.projectileSpread)
	%obj.spread = %data.projectileSpread;
   else
      %obj.spread = %obj.spread + (1.5 / 1000);

   if(%obj.lowSpreadLoop $= "")
	%obj.lowSpreadLoop = schedule(250, 0, "RiflelowerSpread", %data, %obj);
   if(%obj.spread > %data.maxspread)
	%obj.spread = %data.maxspread;

    %vector = %obj.getMuzzleVector(%slot);
    %mp = %obj.getMuzzlePoint(%slot);

      %x = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
      %newvector = MatrixMulVector(%mat, %vector);

      %p = new (%data.projectileType)() 
	   {
            dataBlock        = %data.projectile;
            initialDirection = %newvector;
            initialPosition  = %mp;
            sourceObject     = %obj;
		damageFactor	 = 1;
            sourceSlot       = %slot;
         };

   if (%obj.inv[%data.ammo] == 0)
      %obj.Reloading = schedule(10, 0, "WeaponCheckMag", %obj, %data);
}

//---------------------------------------------------
// Weapon 45
//---------------------------------------------------
datablock ItemData(revolver)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_energy_vehicle.dts";
   image = revolverImage;
   mass = 2;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a 45";
};

datablock ShapeBaseImageData(revolverImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = revolver;
   ammo = revolverAmmo;
   offset = "0 0 0";
   rotation = "0 1 0 180";
   mass = 4;

   magType = Pistolclip;
   magImage = revolverImage;
   magImageSlot = 0;
   magSize = 6;
   magReloadTime = 3000;

   projectile = revolverBullet;
   projectileType = tracerProjectile;
   projectileSpread = 3.0 / 1000.0;
   maxSpread = 7 / 1000.0;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = PlasmaSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.1;
   stateFire[3] = true;
   stateEmitter[3] = "GunFireEffectEmitter";
   stateEmitterNode[3] = "muzzlepoint1";
   stateEmitterTime[3] = 1; 
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = PistolFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.65;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = ChaingunDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

function revolverImage::onFire(%data,%obj,%slot) 
{ 
   %obj.decInventory(%data.ammo,1);

   if(%obj.spread $= "" || %obj.spread < %data.projectileSpread)
	%obj.spread = %data.projectileSpread;
   else
      %obj.spread = %obj.spread + (2.5 / 1000);

   if(%obj.lowSpreadLoop $= "")
	%obj.lowSpreadLoop = schedule(250, 0, "RiflelowerSpread", %data, %obj);
   if(%obj.spread > %data.maxspread)
	%obj.spread = %data.maxspread;

    %vector = %obj.getMuzzleVector(%slot);
    %mp = %obj.getMuzzlePoint(%slot);

      %x = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
      %newvector = MatrixMulVector(%mat, %vector);

      %p = new (%data.projectileType)() 
	   {
            dataBlock        = %data.projectile;
            initialDirection = %newvector;
            initialPosition  = %mp;
            sourceObject     = %obj;
		damageFactor	 = 1;
            sourceSlot       = %slot;
         };

   if (%obj.inv[%data.ammo] == 0)
      %obj.Reloading = schedule(10, 0, "WeaponCheckMag", %obj, %data);
}

//---------------------------------------------------
// Weapon M9
//---------------------------------------------------
datablock ItemData(deagle)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_energy_vehicle.dts";
   image = deagleImage;
   mass = 2;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a Deagle";
};

datablock ShapeBaseImageData(deagleImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = deagle;
   ammo = deagleAmmo;
   offset = "0 0 0";
   rotation = "0 1 0 180";
   mass = 4;

   magType = Pistolclip;
   magImage = deagleImage;
   magImageSlot = 0;
   magSize = 8;
   magReloadTime = 2100;

   projectile = deagleBullet;
   projectileType = tracerProjectile;
   projectileSpread = 2 / 1000.0;
   maxSpread = 6 / 1000.0;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = PlasmaSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.1;
   stateFire[3] = true;
   stateEmitter[3] = "GunFireEffectEmitter";
   stateEmitterNode[3] = "muzzlepoint1";
   stateEmitterTime[3] = 1; 
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = PistolFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.45;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = ChaingunDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

function deagleImage::onFire(%data,%obj,%slot) 
{ 
   %obj.decInventory(%data.ammo,1);

   if(%obj.spread $= "" || %obj.spread < %data.projectileSpread)
	%obj.spread = %data.projectileSpread;
   else
      %obj.spread = %obj.spread + (2.5 / 1000);

   if(%obj.lowSpreadLoop $= "")
	%obj.lowSpreadLoop = schedule(250, 0, "RiflelowerSpread", %data, %obj);
   if(%obj.spread > %data.maxspread)
	%obj.spread = %data.maxspread;

    %vector = %obj.getMuzzleVector(%slot);
    %mp = %obj.getMuzzlePoint(%slot);

      %x = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
      %newvector = MatrixMulVector(%mat, %vector);

      %p = new (%data.projectileType)() 
	   {
            dataBlock        = %data.projectile;
            initialDirection = %newvector;
            initialPosition  = %mp;
            sourceObject     = %obj;
		damageFactor	 = 1;
            sourceSlot       = %slot;
         };

   if (%obj.inv[%data.ammo] == 0)
      %obj.Reloading = schedule(10, 0, "WeaponCheckMag", %obj, %data);
}

//---------------------------------------------------
// Weapon Glock 18
//---------------------------------------------------
datablock ItemData(glock)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_energy_vehicle.dts";
   image = glockImage;
   mass = 2;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a Glock 18";
};

datablock ShapeBaseImageData(glockImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = glock;
   ammo = glockAmmo;
   offset = "0 0 0";
   rotation = "0 1 0 180";
   mass = 4;

   magType = Pistolclip;
   magImage = glockImage;
   magImageSlot = 0;
   magSize = 18;
   magReloadTime = 2100;

   projectile = coltbullet;
   projectileType = tracerProjectile;
   projectileSpread = 8.0 / 1000.0;
   maxSpread = 16 / 1000.0;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = PlasmaSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.1;
   stateFire[3] = true;
   stateEmitter[3] = "GunFireEffectEmitter";
   stateEmitterNode[3] = "muzzlepoint1";
   stateEmitterTime[3] = 1; 
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = PistolFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.05;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = ChaingunDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

function glockImage::onFire(%data,%obj,%slot) 
{ 
   %obj.decInventory(%data.ammo,1);

   if(%obj.spread $= "" || %obj.spread < %data.projectileSpread)
	%obj.spread = %data.projectileSpread;
   else
      %obj.spread = %obj.spread + (2.5 / 1000);

   if(%obj.lowSpreadLoop $= "")
	%obj.lowSpreadLoop = schedule(250, 0, "RiflelowerSpread", %data, %obj);
   if(%obj.spread > %data.maxspread)
	%obj.spread = %data.maxspread;

    %vector = %obj.getMuzzleVector(%slot);
    %mp = %obj.getMuzzlePoint(%slot);

      %x = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
      %newvector = MatrixMulVector(%mat, %vector);

      %p = new (%data.projectileType)() 
	   {
            dataBlock        = %data.projectile;
            initialDirection = %newvector;
            initialPosition  = %mp;
            sourceObject     = %obj;
		damageFactor	 = 1;
            sourceSlot       = %slot;
         };

   if (%obj.inv[%data.ammo] == 0)
      %obj.Reloading = schedule(10, 0, "WeaponCheckMag", %obj, %data);
}

//---------------------------------------------------
// Weapon Mini Uzi
//---------------------------------------------------
datablock ItemData(Uzi)
{
   className = Weapon;
   catagory = "Spawn Items";
   shapeFile = "weapon_energy_vehicle.dts";
   image = uziImage;
   mass = 2;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "a Mini Uzi";
};

datablock ShapeBaseImageData(uziImage)
{
   className = WeaponImage;
   shapeFile = "weapon_energy_vehicle.dts";
   item = uzi;
   ammo = uziAmmo;
   offset = "0 0 0";
   rotation = "0 1 0 180";
   mass = 4;

   magType = Pistolclip;
   magImage = uziImage;
   magImageSlot = 0;
   magSize = 25;
   magReloadTime = 2500;

   projectile = coltbullet;
   projectileType = tracerProjectile;
   projectileSpread = 14.0 / 1000.0;
   maxSpread = 21 / 1000.0;

   stateName[0] = "Activate";
   stateTransitionOnTimeout[0] = "ActivateReady";
   stateTimeoutValue[0] = 0.5;
   stateSequence[0] = "Activate";
   stateSound[0] = PlasmaSwitchSound;

   stateName[1] = "ActivateReady";
   stateTransitionOnLoaded[1] = "Ready";
   stateTransitionOnNoAmmo[1] = "NoAmmo";

   stateName[2] = "Ready";
   stateTransitionOnNoAmmo[2] = "NoAmmo";
   stateTransitionOnTriggerDown[2] = "Fire";

   stateName[3] = "Fire";
   stateTransitionOnTimeout[3] = "Reload";
   stateTimeoutValue[3] = 0.05;
   stateFire[3] = true;
   stateEmitter[3] = "GunFireEffectEmitter";
   stateEmitterNode[3] = "muzzlepoint1";
   stateEmitterTime[3] = 1; 
   stateRecoil[3] = LightRecoil;
   stateAllowImageChange[3] = false;
   stateScript[3] = "onFire";
   stateEmitterTime[3] = 0.2;
   stateSound[3] = PistolFireSound;

   stateName[4] = "Reload";
   stateTransitionOnNoAmmo[4] = "NoAmmo";
   stateTransitionOnTimeout[4] = "Ready";
   stateTimeoutValue[4] = 0.05;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

   stateName[5] = "NoAmmo";
   stateTransitionOnAmmo[5] = "Reload";
   stateSequence[5] = "NoAmmo";
   stateTransitionOnTriggerDown[5] = "DryFire";

   stateName[6]       = "DryFire";
   stateSound[6]      = ChaingunDryFireSound;
   stateTimeoutValue[6]        = 1.5;
   stateTransitionOnTimeout[6] = "NoAmmo";
};

function uziImage::onFire(%data,%obj,%slot) 
{ 
   %obj.decInventory(%data.ammo,1);

   if(%obj.spread $= "" || %obj.spread < %data.projectileSpread)
	%obj.spread = %data.projectileSpread;
   else
      %obj.spread = %obj.spread + (2.5 / 1000);

   if(%obj.lowSpreadLoop $= "")
	%obj.lowSpreadLoop = schedule(250, 0, "RiflelowerSpread", %data, %obj);
   if(%obj.spread > %data.maxspread)
	%obj.spread = %data.maxspread;

    %vector = %obj.getMuzzleVector(%slot);
    %mp = %obj.getMuzzlePoint(%slot);

      %x = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * %obj.spread;
      %mat = MatrixCreateFromEuler(%x @ " " @ %y @ " " @ %z);
      %newvector = MatrixMulVector(%mat, %vector);

      %p = new (%data.projectileType)() 
	   {
            dataBlock        = %data.projectile;
            initialDirection = %newvector;
            initialPosition  = %mp;
            sourceObject     = %obj;
		damageFactor	 = 1;
            sourceSlot       = %slot;
         };

   if (%obj.inv[%data.ammo] == 0)
      %obj.Reloading = schedule(10, 0, "WeaponCheckMag", %obj, %data);
}