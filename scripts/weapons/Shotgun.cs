//--------------------------------------
// Shotgun
//--------------------------------------             

//--------------------------------------------------------------------------
// Projectile
//--------------------------------------

datablock TracerProjectileData(ShotgunPellet)
{
   doDynamicClientHits = true;

   directDamage        = 0.075;
   directDamageType    = $DamageType::Shotgun;
   explosion           = "ChaingunExplosion";
   splash              = ChaingunSplash;

   doDynamicHits	     = 1;
   HeadMultiplier      = 1.2;
   LegsMultiplier      = 0.75;
   closeRangeMultiplier  = 1.3;
   closeRangeDistance = 35;

   longRangeMultiplier  = 0.75;
   kickBackStrength  = 0.0;
   sound 				= ChaingunProjectile;

   dryVelocity       = 1500.0; 
   wetVelocity       = 1000.0;
   velInheritFactor  = 0.0;
   fizzleTimeMS      = 1000;
   lifetimeMS        = 1000;
   explodeOnDeath    = false;
   reflectOnWaterImpactAngle = 0.0;
   explodeOnWaterImpact      = false;
   deflectionOnWaterImpact   = 0.0;
   fizzleUnderwaterMS        = 3000;

   tracerLength    = 5.0;
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

datablock ItemData(ShotgunAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some Shotgun rounds";

   computeCRC = true;

};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(ShotgunImage)
{
   className = WeaponImage;
   shapeFile = "weapon_plasma.dts";
   item      = Shotgun;
   ammo 	 = ShotgunAmmo;
   projectile = ShotgunPellet;
   projectileType = TracerProjectile;
   emap = true;
   mass = 20;

   magType = Shotgunclip;
   magImage = ShotgunImage;
   magImageSlot = 0;
   magSize = 8;
   magReloadTime = 2500;

   casing              = ShellDebris;
   shellExitDir        = "0.5 0.0 1.0"; // L/R - F/B - T/B
   shellExitOffset     = "0.15 -0.51 -0.1"; // L/R - F/B - T/B
   shellExitVariance   = 10.0;
   shellVelocity       = 4.0;

   projectileSpread = 11.0 / 1000.0;

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
   stateTimeoutValue[3] = 0.0001;
   stateFire[3] = true;
   stateEjectShell[3] = true;
   stateEmitter[3] = "GunFireEffectEmitter";
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
   stateTimeoutValue[4] = 0.5;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

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

datablock ItemData(Shotgun)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_plasma.dts";
   image        = ShotgunImage;
   mass         = 1.0;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "a M23 Shotgun";

   computeCRC = true;
   emap = true;
};

datablock ItemData(ShotgunClip)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "Shotgun Magazines";

   computeCRC = true;
};

function ShotgunImage::onFire(%data,%obj,%slot) 
{ 
    %obj.applyKick(-250);
    %obj.decInventory(%data.ammo,1);

    %vector = %obj.getMuzzleVector(%slot);
    %mp = %obj.getMuzzlePoint(%slot);

	for (%i=0; %i < 12; %i++)
	{
      %x = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
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
	}
   if (%obj.inv[%data.ammo] == 0)
      %obj.Reloading = schedule(10, 0, "WeaponCheckMag", %obj, %data);
}





//--------------------------------------
// RotaryShotgun
//-------------------------------------- 

//--------------------------------------------------------------------------
// Ammo
//--------------------------------------

datablock ItemData(RShotgunAmmo)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
	pickUpName = "some Rotary Shotgun rounds";

   computeCRC = true;
};

//--------------------------------------------------------------------------
// Weapon
//--------------------------------------
datablock ShapeBaseImageData(RShotgunImage)
{
   className = WeaponImage;
   shapeFile = "weapon_grenade_launcher.dts";
   item      = RShotgun;
   ammo 	 = RShotgunAmmo;
   projectile = ShotgunPellet;
   projectileType = TracerProjectile;
   emap = true;
   mass = 20;

   magType = RShotgunclip;
   magImage = RSGImageclip;
   magImageSlot = 4;
   magSize = 25;
   magReloadTime = 3000;

   casing              = ShellDebris;
   shellExitDir        = "1.0 0.3 1.0";
   shellExitOffset     = "0.15 -0.56 -0.1";
   shellExitVariance   = 15.0;
   shellVelocity       = 3.0;

   projectileSpread = 9.0 / 1000.0;

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
   stateTimeoutValue[3] = 0.0001;
   stateFire[3] = true;
   stateEjectShell[3] = true;
   stateEmitter[3] = "GunFireEffectEmitter";
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
   stateTimeoutValue[4] = 0.25;
   stateAllowImageChange[4] = false;
   stateSequence[4] = "Reload";

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

datablock ItemData(RShotgun)
{
   className    = Weapon;
   catagory     = "Spawn Items";
   shapeFile    = "weapon_grenade_launcher.dts";
   image        = RShotgunImage;
   mass         = 1.0;
   elasticity   = 0.2;
   friction     = 0.6;
   pickupRadius = 2;
   pickUpName   = "a RM12 Rotary shotgun";

   computeCRC = true;
   emap = true;
};

datablock ItemData(RShotgunClip)
{
   className = Ammo;
   catagory = "Ammo";
   shapeFile = "ammo_chaingun.dts";
   mass = 1;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   pickUpName = "RM12 Magazines";

   computeCRC = true;
};

datablock ShapeBaseImageData(RSGImage1) 
{ 
   className = WeaponImage;
   ammo = RShotgunAmmo;
   shapeFile = "weapon_grenade_launcher.dts"; 
   rotation = "0 1 0 120";
}; 

datablock ShapeBaseImageData(RSGImage2) 
{ 
   className = WeaponImage;
   ammo = RShotgunAmmo;
   shapeFile = "weapon_grenade_launcher.dts"; 
   rotation = "0 1 0 -120";
}; 

datablock ShapeBaseImageData(RSGImageclip) 
{ 
   className = WeaponImage;
   ammo = RShotgunAmmo;
   shapeFile = "ammo_chaingun.dts"; 
   rotation = "0 1 0 180";
   offset = "0.0 0.45 -0.1"; // L/R - F/B - T/B
   item      = RShotgun;
};

function RShotgunImage::onMount(%this,%obj,%slot)
{
   Parent::onMount(%this, %obj, %slot);
   %obj.mountImage(RSGImageclip, 4);
   %obj.mountImage(RSGImage1, 5);
   %obj.mountImage(RSGImage2, 6);
   if (%obj.inv[%this.ammo] == 0)
      %obj.Reloading = schedule(10, 0, "WeaponCheckMag", %obj, %this);
}

function RShotgunImage::onUnmount(%this,%obj,%slot)
{
   Parent::onUnmount(%this, %obj, %slot);
   %obj.unmountImage(4);
   %obj.unmountImage(5);
   %obj.unmountImage(6);
   cancel(%obj.Reloading);
   %obj.clipreloading = false;
}

function RShotgunImage::onFire(%data,%obj,%slot) 
{ 
    %obj.applyKick(-250);
    %obj.decInventory(%data.ammo,1);

    %vector = %obj.getMuzzleVector(%slot);
    %mp = %obj.getMuzzlePoint(%slot);

	for (%i=0; %i < 8; %i++)
	{
      %x = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
      %y = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
      %z = (getRandom() - 0.5) * 2 * 3.1415926 * %data.projectileSpread;
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
	}
   if (%obj.inv[%data.ammo] == 0)
      %obj.Reloading = schedule(10, 0, "WeaponCheckMag", %obj, %data);
}