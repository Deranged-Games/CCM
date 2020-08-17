$NightVisionValue = 0.2;

function NightVisionLoop(%client){
   if(!isObject(%client.player))
	return;
   %client.player.setWhiteOut($NightVisionValue);
   %client.player.nightvision = schedule(50, 0, "NightVisionLoop", %client);
}

function serverCmdDoGrab(%client){
   %obj 	   = %client.player;
   if(!isObject(%obj))
	return;
  if(%obj.grabbing != 1){
   %pos        = %obj.getMuzzlePoint($WeaponSlot);
   %vec        = %obj.getMuzzleVector($WeaponSlot);
   %targetpos  = vectoradd(%pos,vectorscale(%vec,5));
   %Tobj        = containerraycast(%pos, %targetpos, $typemasks::PlayerObjectType | $typemasks::CorpseObjectType, %obj);
   %Tobj        = getword(%Tobj,0);
   if(isObject(%Tobj)){
	if(vectorDist(%obj.getForwardVector(),%Tobj.getForwardVector()) > 1.6)
	   return;
	%armortype = %obj.getdatablock().getname();
	if(!(%armortype $= "SpecOpsMaleHumanArmor" || %armortype $= "SpecOpsFemaleHumanArmor" || %armortype $= "SpecOpsMaleBiodermArmor"))
	   return;
      if(%Tobj.grabbing == 1)
	   %Tobj.grabbing = 0;
	if(%Tobj.grabbed == 1)
	   return;
	%dataBlock  = %Tobj.getDataBlock();
	%mass  = %dataBlock.mass;
	if(%mass >= 150){
	   return;
	}
	%Tobj.grabbed = 1;
	%Tobj.setMoveState(true);
	%obj.grabbing = 1;
	schedule(100, 0, "GrabLoop", %obj, %Tobj);
   }
  }
  else
   %obj.grabbing = 0;
}

function GrabLoop(%obj, %Tobj){
   if(!(isObject(%obj) && isObject(%Tobj)))
	return;
   if(%obj.getstate() $= "dead"){
	%Tobj.setMoveState(false);
	%Tobj.grabbed = 0;
	return;
   }
   if(%obj.grabbing != 1){
	%Tobj.setMoveState(false);
	%Tobj.grabbed = 1;
	if(%Tobj.getState() !$= "Dead")
	   %Tobj.getDataBlock().damageObject(%Tobj, %obj, %Tobj.getPosition(), 10, $DamageType::blah, "0 0 1", %obj.getControllingClient(), %obj);
	return;
   }
   if(%Tobj.getMountedImage($weaponslot) !$= "")
   	%Tobj.throwWeapon();
   if(%Tobj.getMountedImage($Backpackslot) !$= "")
   	%Tobj.throwPack();
   if(%obj.getMountedImage($weaponslot) !$= "")
   	%obj.unmountImage($weaponslot);

   %pos = %obj.getPosition();
   %rot = %obj.getRotation();
   %vel = vectoradd(%obj.getvelocity(), "0 0 1");
   %vec = vectorScale(%obj.getForwardVector(),3);
   %vec = vectorAdd(%vec, "0 0 0.5");
   %Tobj.setTransform(vectorAdd(%pos, %vec)@" "@%rot);
   %Tobj.setvelocity(%vel);
   schedule(100, 0, "GrabLoop", %obj, %Tobj);
}

function callInArtillery(%obj){
   if(!isObject(%obj))
	return;
   %pos = %obj.getposition();
   InitContainerRadiusSearch(%obj.getPosition(), 1000, $TypeMasks::TurretObjectType);
   while ((%target = containerSearchNext()) != 0){
	if(%target.team == %obj.team){
	   %dbname = %target.getdatablock().getname();
	   %dist = vectorDist(%pos,%target.getPosition());
	   if(%dbname $= "TurretDeployedOutdoor"){
		if(%dist <= 450){
		   if(%firelist $= "")
			%firelist = %target;
		   else
			%firelist = %firelist SPC %target;
		}
	   }
	   else if(%dbname $= "TurretBaseLarge" || %dbname $= "TurretDeployedBase"){
		%img = %target.getMountedImage(0);
		if(%img.getname() $= "ArtilleryBarrelLarge"){
		   if(%firelist $= "")
			%firelist = %target;
		   else
			%firelist = %firelist SPC %target;
		}
	   }
	}
   }
   echo(%firelist);
   %count = 1;
   while((%turret = getWord(%firelist,(%count - 1))) !$= ""){
	echo(%turret SPC %count);
	%turret.setTargetObject(%obj);
	%turret.aquireTime = getSimTime();
	%turret.schedule(1000,SetImageTrigger,0,true);
	%turret.schedule(5000,SetImageTrigger,0,true);
	%turret.schedule(9000,SetImageTrigger,0,true);
	%turret.schedule(1200,SetImageTrigger,0,false);
	%count++;
   }
   %obj.schedule(12000, delete);
}