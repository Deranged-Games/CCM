function traningphase1(%sender, %section){
   if(%sender.TP1started $= ""){
      if($traninginprogress == 1){
	   messageClient(%sender, 'MsgClient', "\c2Sorry soldier, another traine is currently running through the course, try again later with /StartSpecOpsTraning.");
	   return;
      }
	$traninginprogress = 1;
	%sender.TP1started = 1;
	loadbuilding("SpecialOpsTraning1.cs");
	schedule(3000, 0, "globalPowerCheck");
      $SOT1door1 = new (StaticShape) () {
	   datablock = "DeployedSpine";
	   position = "26.1228 103.251 2003.78";
	   rotation = "0.161441 0.697833 -0.697829 161.658";
	   scale = "0.904972 1.18335 1";
	   team = "1";
	   ownerGUID = "909636";
	   needsfit = "1";
	   powerFreq = "16";
	};
	addToDeployGroup($SOT1door1);
      schedule(1000, 0, "messageClient", %sender, 'MsgClient', "\c2Hooah soldier, welcome to Special Operation Traning phase 1.");
      schedule(7000, 0, "messageClient", %sender, 'MsgClient', "\c2Please head to the desk and recieve your information.");
	SOToneLoop(%sender, 0);
	SOTPlayerSpawn(%sender, "31.5 116.7 2002 0 0 1 205");
   }
   if(%section == 1){
	%sender.player.setMoveState(false);
	$SOT1door1.schedule(1000, delete);
	SOToneLoop(%sender, 1);
   }
   if(%section == 2){
	%sender.player.setMoveState(false);
	SOToneLoop(%sender, 2);
   }
   if(%section == 3){
	%sender.player.setMoveState(false);
	SOToneLoop(%sender, 3);
   }
}

function SOToneLoop(%sender, %section, %loopnum){
   if(!isObject(%sender.player) || %sender.player.getState() $= "dead"){
	messageClient(%sender, 'MsgClient', "\c2You have died, please restart traning.");
	return;
   }
   if(%section < 1){
      if(vectorDist(%sender.player.getPosition(),"30.2 105 2002") <= 4){
	   %sender.player.setMoveState(true);
         schedule(1000, 0, "messageClient", %sender, 'MsgClient', "\c2Welcome to Special Operations Traning phase 1: weapon handling.");
         schedule(5000, 0, "messageClient", %sender, 'MsgClient', "\c2In this traning you will go from station to station and attempt to clear all the targets at each station in the time provided and with the ammo alloted to you.");
         schedule(15000, 0, "messageClient", %sender, 'MsgClient', "\c2You must destroy every single target on the field in the conditions provided before continuing on to the next phase of traning.");
         schedule(28000, 0, "messageClient", %sender, 'MsgClient', "\c2Please proceed to the first station.");
         schedule(31000, 0, "messageClient", %sender, 'MsgClient', "\c2Good luck soldier.");
	   schedule(28000, 0, "traningphase1", %sender, 1);
	   return;
      }
      schedule(500, 0, "SOToneLoop", %sender, %section);
   }
   else if(%section == 1){
	if(%loopnum $= ""){
	   if(vectorDist(%sender.player.getPosition(),"38.9 94.9 2002") <= 2){
		%sender.player.setMoveState(true);
		schedule(1000, 0, "messageClient", %sender, 'MsgClient', "\c2This is the MP-12 range.");
		schedule(4000, 0, "messageClient", %sender, 'MsgClient', "\c2There will be 10 targets to show up, destroy them all to proceed.");
		schedule(10000, 0, "messageClient", %sender, 'MsgClient', "\c2You have 3 clips in this section.");
		schedule(15000, 0, "messageClient", %sender, 'MsgClient', "\c2BEGIN.");
		schedule(15000, 0, "SOToneLoop", %sender, %section, 1);
   		%sender.player.setInventory(LSMGAmmo, 30);
   		%sender.player.setInventory(LSMGClip, 2);
   		%sender.player.setInventory(LSMG,1);
		return;
	   }
	   schedule(500, 0, "SOToneLoop", %sender, %section);
	}
	else if(%loopnum == 1 || %loopnum == 11){
	   if(%loopnum == 1)
	      %sender.numhit = 0;
	   $SOT1solar12.setDamageLevel(0.0);
	   toggleGenerator($SOT1solar12, true);
	   %loopnum++;
	   schedule(6000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 2 || %loopnum == 12){
	   toggleGenerator($SOT1solar12, false);
	   if($SOT1solar12.getDamageLevel() >= 0.55)
		%sender.numhit++;
	   %loopnum++;
	   schedule(4000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 3 || %loopnum == 13){
	   $SOT1solar13.setDamageLevel(0.0);
	   toggleGenerator($SOT1solar13, true);
	   %loopnum++;
	   schedule(6000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 4 || %loopnum == 14){
	   toggleGenerator($SOT1solar13, false);
	   if($SOT1solar13.getDamageLevel() >= 0.55)
		%sender.numhit++;
	   %loopnum++;
	   schedule(4000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 5 || %loopnum == 15){
	   $SOT1solar14.setDamageLevel(0.0);
	   toggleGenerator($SOT1solar14, true);
	   %loopnum++;
	   schedule(6000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 6 || %loopnum == 16){
	   toggleGenerator($SOT1solar14, false);
	   if($SOT1solar14.getDamageLevel() >= 0.55)
		%sender.numhit++;
	   %loopnum++;
	   schedule(4000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 7 || %loopnum == 17){
	   $SOT1solar15.setDamageLevel(0.0);
	   toggleGenerator($SOT1solar15, true);
	   %loopnum++;
	   schedule(6000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 8 || %loopnum == 18){
	   toggleGenerator($SOT1solar15, false);
	   if($SOT1solar15.getDamageLevel() >= 0.55)
		%sender.numhit++;
	   %loopnum++;
	   schedule(4000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 9 || %loopnum == 19){
	   $SOT1solar16.setDamageLevel(0.0);
	   toggleGenerator($SOT1solar16, true);
	   %loopnum++;
	   schedule(6000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 10){
	   toggleGenerator($SOT1solar16, false);
	   if($SOT1solar16.getDamageLevel() >= 0.55)
		%sender.numhit++;
	   %loopnum++;
	   schedule(4000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 20){
	   toggleGenerator($SOT1solar16, false);
	   if($SOT1solar16.getDamageLevel() >= 0.55)
		%sender.numhit++;
	   %sender.player.unmountImage($weaponslot);
   	   %sender.player.setInventory(LSMGAmmo, 0);
   	   %sender.player.setInventory(LSMGClip, 0);
   	   %sender.player.setInventory(LSMG, 0);
	   if(%sender.numhit >= 10){
		messageClient(%sender, 'MsgClient', "\c2You have completed this section, please proceed to firing area 2.");
		%sender.player.setMoveState(false);
		schedule(1000, 0, "traningPhase1", %sender, 2);
	   }
	   else{
		messageClient(%sender, 'MsgClient', "\c2You failed this section, repeating in 5 seconds.");
		schedule(5000, 0, "SOToneLoop", %sender, %section);
	   }
	}
   }
   else if(%section == 2){
	if(%loopnum $= ""){
	   if(vectorDist(%sender.player.getPosition(),"31.8 80.4 2002") <= 2){
		%sender.player.setMoveState(true);
		schedule(1000, 0, "messageClient", %sender, 'MsgClient', "\c2This is the Kreig Rifle range.");
		schedule(4000, 0, "messageClient", %sender, 'MsgClient', "\c2There will be 13 targets to show up, destroy them all to proceed.");
		schedule(10000, 0, "messageClient", %sender, 'MsgClient', "\c2You have 3 clips in this section.");
		schedule(15000, 0, "messageClient", %sender, 'MsgClient', "\c2BEGIN.");
		schedule(15000, 0, "SOToneLoop", %sender, %section, 1);
   		%sender.player.setInventory(KriegAmmo, 10);
   		%sender.player.setInventory(Rifleclip, 2);
   		%sender.player.setInventory(KriegRifle,1);
		return;
	   }
	   schedule(500, 0, "SOToneLoop", %sender, %section);
	}
	else if(%loopnum == 1 || %loopnum == 11 || %loopnum == 21){
	   if(%loopnum == 1)
	      %sender.numhit = 0;
	   $SOT1solar2.setDamageLevel(0.0);
	   toggleGenerator($SOT1solar2, true);
	   %loopnum++;
	   schedule(6000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 2 || %loopnum == 12 || %loopnum == 22){
	   toggleGenerator($SOT1solar2, false);
	   if($SOT1solar2.getDamageLevel() >= 0.55)
		%sender.numhit++;
	   %loopnum++;
	   schedule(4000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 3 || %loopnum == 13 || %loopnum == 23){
	   $SOT1solar3.setDamageLevel(0.0);
	   toggleGenerator($SOT1solar3, true);
	   %loopnum++;
	   schedule(6000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 4 || %loopnum == 14 || %loopnum == 24){
	   toggleGenerator($SOT1solar3, false);
	   if($SOT1solar3.getDamageLevel() >= 0.55)
		%sender.numhit++;
	   %loopnum++;
	   schedule(4000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 5 || %loopnum == 15 || %loopnum == 25){
	   $SOT1solar4.setDamageLevel(0.0);
	   toggleGenerator($SOT1solar4, true);
	   %loopnum++;
	   schedule(6000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 6 || %loopnum == 16){
	   toggleGenerator($SOT1solar4, false);
	   if($SOT1solar4.getDamageLevel() >= 0.55)
		%sender.numhit++;
	   %loopnum++;
	   schedule(4000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 7 || %loopnum == 17){
	   $SOT1solar5.setDamageLevel(0.0);
	   toggleGenerator($SOT1solar5, true);
	   %loopnum++;
	   schedule(6000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 8 || %loopnum == 18){
	   toggleGenerator($SOT1solar5, false);
	   if($SOT1solar5.getDamageLevel() >= 0.55)
		%sender.numhit++;
	   %loopnum++;
	   schedule(4000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 9 || %loopnum == 19){
	   $SOT1solar6.setDamageLevel(0.0);
	   toggleGenerator($SOT1solar6, true);
	   %loopnum++;
	   schedule(6000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 10 || %loopnum == 20){
	   toggleGenerator($SOT1solar6, false);
	   if($SOT1solar6.getDamageLevel() >= 0.55)
		%sender.numhit++;
	   %loopnum++;
	   schedule(4000, 0, "SOToneLoop", %sender, %section, %loopnum);
	}
	else if(%loopnum == 26){
	   toggleGenerator($SOT1solar4, false);
	   if($SOT1solar4.getDamageLevel() >= 0.55)
		%sender.numhit++;
	   %sender.player.unmountImage($weaponslot);
   		%sender.player.setInventory(KriegAmmo, 0);
   		%sender.player.setInventory(Rifleclip, 0);
   		%sender.player.setInventory(KriegRifle,0);
	   if(%sender.numhit >= 13){
		messageClient(%sender, 'MsgClient', "\c2You have completed this section, please proceed to firing area 2.");
		%sender.player.setMoveState(false);
		schedule(1000, 0, "traningPhase1", %sender, 3);
	   }
	   else{
		messageClient(%sender, 'MsgClient', "\c2You failed this section, repeating in 5 seconds.");
		schedule(5000, 0, "SOToneLoop", %sender, %section);
	   }
	}
   }
   else if(%section == 3){
	if(%loopnum $= ""){
	   if(vectorDist(%sender.player.getPosition(),"16.9 50 2002.5") <= 2){
		%sender.player.setMoveState(true);
		schedule(1000, 0, "messageClient", %sender, 'MsgClient', "\c2This is the Mix Range.");
		schedule(3000, 0, "messageClient", %sender, 'MsgClient', "\c2You will use the RX-12 Special Forces only weapon.");
		schedule(4000, 0, "messageClient", %sender, 'MsgClient', "\c2You are equipped with the version of the RX-12 which has a single shot grenade launcher attached to it.");
		schedule(10000, 0, "messageClient", %sender, 'MsgClient', "\c2You will also use the Silenced Beretta, and the AT6 Rocket Launcher.");
		schedule(15000, 0, "messageClient", %sender, 'MsgClient', "\c2There will be 5 targets.");
		schedule(17000, 0, "messageClient", %sender, 'MsgClient', "\c2Determine which targets need which weapons and utilize them correctly.");
		schedule(20000, 0, "messageClient", %sender, 'MsgClient', "\c2Good luck solider.");
		schedule(21000, 0, "messageClient", %sender, 'MsgClient', "\c2BEGIN.");
		schedule(21000, 0, "SOToneLoop", %sender, %section, 1);
   		%sender.player.setInventory(SRifleAmmo, 30);
   		%sender.player.setInventory(SRifleGLAmmo, 1);
   		%sender.player.setInventory(SRifleGL,1);
   		%sender.player.setInventory(LMissileLauncherAmmo, 1);
   		%sender.player.setInventory(LMissileLauncher,1);
   		%sender.player.setInventory(PistolAmmo, 10);
   		%sender.player.setInventory(SPistol,1);
		return;
	   }
	   schedule(500, 0, "SOToneLoop", %sender, %section);
	}
	else if(%loopnum == 1){
	   if(%loopnum == 1)
	      %sender.numhit = 0;
	   $SOT1solar7.setDamageLevel(0.0);
	   toggleGenerator($SOT1solar7, true);
	   schedule(6000, 0, "SOToneLoop", %sender, %section, 2);
	}
	else if(%loopnum == 2){
	   toggleGenerator($SOT1solar7, false);
	   if($SOT1solar7.getDamageLevel() >= 0.55)
		%sender.numhit++;
	   schedule(4000, 0, "SOToneLoop", %sender, %section, 3);
	}
	else if(%loopnum == 3){
	   $SOT1solar8.setDamageLevel(0.0);
	   toggleGenerator($SOT1solar8, true);
	   schedule(6000, 0, "SOToneLoop", %sender, %section, 4);
	}
	else if(%loopnum == 4){
	   toggleGenerator($SOT1solar8, false);
	   if($SOT1solar8.getDamageLevel() >= 0.55)
		%sender.numhit++;
	   schedule(4000, 0, "SOToneLoop", %sender, %section, 5);
	}
	else if(%loopnum == 5){
	   $SOT1solar9.setDamageLevel(0.0);
	   toggleGenerator($SOT1solar9, true);
	   schedule(6000, 0, "SOToneLoop", %sender, %section, 6);
	}
	else if(%loopnum == 6){
	   toggleGenerator($SOT1solar9, false);
	   if($SOT1solar9.getDamageLevel() >= 0.55)
		%sender.numhit++;
	   schedule(4000, 0, "SOToneLoop", %sender, %section, 7);
	}
	else if(%loopnum == 7){
	   $SOT1solar10.setDamageLevel(0.0);
	   toggleGenerator($SOT1solar10, true);
	   schedule(6000, 0, "SOToneLoop", %sender, %section, 8);
	}
	else if(%loopnum == 8){
	   toggleGenerator($SOT1solar10, false);
	   if($SOT1solar10.getDamageLevel() >= 0.55)
		%sender.numhit++;
	   schedule(4000, 0, "SOToneLoop", %sender, %section, 9);
	}
	else if(%loopnum == 9){
	   $SOT1solar11.setDamageLevel(0.0);
	   toggleGenerator($SOT1solar11, true);
	   schedule(6000, 0, "SOToneLoop", %sender, %section, 10);
	}
	else if(%loopnum == 10){
	   toggleGenerator($SOT1solar11, false);
	   if($SOT1solar11.getDamageLevel() >= 0.55)
		%sender.numhit++;
	   %sender.player.unmountImage($weaponslot);
   	   %sender.player.setInventory(SRifleAmmo, 0);
   	   %sender.player.setInventory(SRifleGLAmmo, 0);
   	   %sender.player.setInventory(SRifleGL, 0);
   	   %sender.player.setInventory(PistolAmmo, 0);
   	   %sender.player.setInventory(SPistol, 0);
   	   %sender.player.setInventory(LMissileLauncherAmmo, 0);
   	   %sender.player.setInventory(LMissileLauncher, 0);
	   if(%sender.numhit >= 5){
		messageClient(%sender, 'MsgClient', "\c2You have completed the weapons range portion of traning, good work solider.");
		%sender.player.setMoveState(false);
//		schedule(5000, 0, "traningPhase2", %sender);
		changetonextTraning(%sender);
		SOTremovepieces("44.6 60 2002",150);
		$traninginprogress = 0;
		%sender.TP1started = "";
		%sender.numhit = "";
		$Rank::testcompleted[%sender.ranknum] = "";
		$Rank::SOT1completed[%sender.ranknum] = 1;
	   }
	   else{
		messageClient(%sender, 'MsgClient', "\c2You failed this section, repeating in 5 seconds.");
		schedule(5000, 0, "SOToneLoop", %sender, %section);
	   }
	}
   }
}
