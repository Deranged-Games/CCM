//-----------------------MAG Pouch-------------------------

datablock ShapeBaseImageData(MagPackImage)
{
   shapeFile = "ammo_mortar.dts";
   item = MagPack;
   mountPoint = 1;
   offset = "-0.34 0.18 -0.38";
   rotation = "0 0 1 90";
   mass = 20;
};

datablock ItemData(MagPack)
{
   className = Pack;
   catagory = "Packs";
   shapeFile = "ammo_mortar.dts";
   mass = 1.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   rotate = true;
   image = "MagPackImage";
	pickUpName = "a Mag pouch";

   computeCRC = true;
   ammoPouch = true;

	max[ChaingunAmmo] = 0;
	max[MortarAmmo] = 0;
	max[MissileLauncherAmmo] = 0;
	max[Mgclip] = 2;
	max[SniperGunAmmo] = 10;
	max[BazookaAmmo] = 0;
	max[MG42Clip] = 1;
	max[Pistolclip] = 0;
	max[FlamerAmmo] = 0;
	max[Grenade] = 0;
	max[Mine] = 0;
	max[AALauncherAmmo] = 0;
	max[RepairKit] = 0;
	max[RifleClip] = 2;
	max[ShotgunClip] = 2;
	max[RShotgunClip] = 1;
	max[LMissileLauncherAmmo] = 0;
	max[RPGAmmo] = 0;
	max[PBCAmmo] = 1;
	max[RecoillessClip] = 2;
	max[LSMGClip] = 2;
};

function MagPack::onPickup(%this,%pack,%player,%amount)
{
   for (%idx = 0; %idx < $numAmmoItems; %idx++)
   {
      %ammo = $AmmoItem[%idx];
      if (%pack.inv[%ammo] > 0)
      {
         %amount = %pack.getInventory(%ammo);
         %player.incInventory(%ammo,%amount);
         %pack.setInventory(%ammo,0);
      }
      else if(%pack.inv[%ammo] == -1){}
      else
      {
         %player.incInventory(%ammo,%this.max[%ammo]);
      }
   }
}

function magPack::onThrow(%this,%pack,%player)
{
   %player.throwmagPack = 1;
   dropExtPack(%pack, %player);
   serverPlay3D(ItemThrowSound, %player.getTransform());
   %pack.schedulePop();
}

function magPack::onInventory(%this,%player,%value){
   if(%player.getClassName() $= "Player"){
      if(!%value){
         if(%player.throwmagPack == 1){
            %player.throwmagPack = 0;
         }
         else{
            dropExtPack(-1, %player);
         }
      }
      Pouch::onInventory(%this,%player,%value);
   }
}

//-----------------------ROCKET Pouch-------------------------

datablock ShapeBaseImageData(RocketPackImage)
{
   shapeFile = "ammo_missile.dts";
   item = RocketPack;
   mountPoint = 1;
   offset = "-0.22 0.18 -0.34";
   rotation = "0 1 0 90";
   mass = 20;
};

datablock ItemData(RocketPack)
{
   className = Pack;
   catagory = "Packs";
   shapeFile = "ammo_missile.dts";
   mass = 1.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   rotate = true;
   image = "RocketPackImage";
	pickUpName = "a Rocket pouch";

   computeCRC = true;
   ammoPouch = true;

	max[ChaingunAmmo] = 0;
	max[MortarAmmo] = 0;
	max[MissileLauncherAmmo] = 0;
	max[Mgclip] = 0;
	max[SniperGunAmmo] = 0;
	max[BazookaAmmo] = 2;
	max[MG42Clip] = 0;
	max[Pistolclip] = 0;
	max[FlamerAmmo] = 0;
	max[Grenade] = 0;
	max[Mine] = 0;
	max[AALauncherAmmo] = 2;
	max[RepairKit] = 0;
	max[RifleClip] = 0;
	max[ShotgunClip] = 0;
	max[RShotgunClip] = 0;
	max[LMissileLauncherAmmo] = 2;
	max[RPGAmmo] = 0;
	max[PBCAmmo] = 0;
	max[RecoillessClip] = 0;
	max[LSMGClip] = 0;
};

function RocketPack::onPickup(%this,%pack,%player,%amount)
{
   for (%idx = 0; %idx < $numAmmoItems; %idx++)
   {
      %ammo = $AmmoItem[%idx];
      if (%pack.inv[%ammo] > 0)
      {
         %amount = %pack.getInventory(%ammo);
         %player.incInventory(%ammo,%amount);
         %pack.setInventory(%ammo,0);
      }
      else if(%pack.inv[%ammo] == -1){}
      else
      {
         %player.incInventory(%ammo,%this.max[%ammo]);
      }
   }
}

function RocketPack::onThrow(%this,%pack,%player)
{
   %player.throwRocketPack = 1;
   dropExtPack(%pack, %player);
   serverPlay3D(ItemThrowSound, %player.getTransform());
   %pack.schedulePop();
}

function RocketPack::onInventory(%this,%player,%value){
   if(%player.getClassName() $= "Player"){
      if(!%value){
         if(%player.throwRocketPack == 1){
            %player.throwRocketPack = 0;
         }
         else{
            dropExtPack(-1, %player);
         }
      }
      Pouch::onInventory(%this,%player,%value);
   }
}

//-----------------------MED Pouch-------------------------

datablock ShapeBaseImageData(MEDPouchImage)
{
   shapeFile = "repair_patch.dts";
   item = MEDPouch;
   mountPoint = 1;
   offset = "-0.23 0.19 -0.53";
   mass = 20;
};

datablock ItemData(MEDPouch)
{
   className = Pack;
   catagory = "Packs";
   shapeFile = "repair_patch.dts";
   mass = 1.0;
   elasticity = 0.2;
   friction = 0.6;
   pickupRadius = 2;
   rotate = true;
   image = "MEDPouchImage";
	pickUpName = "a Medical pouch";

   computeCRC = true;
   ammoPouch = true;

	max[ChaingunAmmo] = 0;
	max[MortarAmmo] = 0;
	max[MissileLauncherAmmo] = 0;
	max[Mgclip] = 0;
	max[SniperGunAmmo] = 0;
	max[BazookaAmmo] = 0;
	max[MG42Clip] = 0;
	max[Pistolclip] = 0;
	max[FlamerAmmo] = 0;
	max[Grenade] = 0;
	max[Mine] = 0;
	max[AALauncherAmmo] = 0;
	max[RepairKit] = 2;
	max[RifleClip] = 0;
	max[ShotgunClip] = 0;
	max[RShotgunClip] = 0;
	max[LMissileLauncherAmmo] = 0;
	max[RPGAmmo] = 0;
	max[PBCAmmo] = 0;
	max[RecoillessClip] = 0;
	max[LSMGClip] = 0;
};

function MEDPouch::onPickup(%this,%pack,%player,%amount)
{
   for (%idx = 0; %idx < $numAmmoItems; %idx++)
   {
      %ammo = $AmmoItem[%idx];
      if (%pack.inv[%ammo] > 0)
      {
         %amount = %pack.getInventory(%ammo);
         %player.incInventory(%ammo,%amount);
         %pack.setInventory(%ammo,0);
      }
      else if(%pack.inv[%ammo] == -1){}
      else
      {
         %player.incInventory(%ammo,%this.max[%ammo]);
      }
   }
}

function MEDPouch::onThrow(%this,%pack,%player)
{
   %player.throwMEDPack = 1;
   dropExtPack(%pack, %player);
   serverPlay3D(ItemThrowSound, %player.getTransform());
   %pack.schedulePop();
}

function MEDPouch::onInventory(%this,%player,%value){
   if(%player.getClassName() $= "Player"){
      if(!%value){
         if(%player.throwMEDPack == 1){
            %player.throwMEDPack = 0;
         }
         else{
            dropExtPack(-1, %player);
         }
      }
      Pouch::onInventory(%this,%player,%value);
   }
}

//------------------------------------Pouch Functions-----------------------------------------
$PouchSlot = 3;

function dropExtPack(%packObj, %player){
   for(%i = 0; %i < $numAmmoItems; %i++){
      %ammo = $AmmoItem[%i];
      %pAmmo = %player.getInventory(%ammo);
      %pMax = %player.getDatablock().max[%ammo];
      if(%pAmmo > %pMax){
         if(%packObj > 0){
            %packObj.setInventory(%ammo, %pAmmo - %pMax);
         }
         %player.setInventory(%ammo, %pMax);
      }
      else{
         if(%packObj > 0){
            %packObj.inv[%ammo] = -1;
         }
      }
   }
}

function Pouch::onInventory(%data,%obj,%amount){
      if((%oldPack = %obj.getMountedImage($PouchSlot)) != 0)
         %obj.setInventory(%oldPack.item, 0);
      if (%amount && %obj.getDatablock().className $= Armor)
         %obj.mountImage(%data.image,$PouchSlot);
      if(%amount == 0 ){}   
         ItemData::onInventory(%data,%obj,%amount);
}