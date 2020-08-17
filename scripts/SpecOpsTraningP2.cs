function traningPhase2(%sender){
   if(%sender.TP2started $= ""){
      if($traninginprogress2 == 1){
	   messageClient(%sender, 'MsgClient', "\c2Sorry soldier, another traine is currently running through the course, try again later with /StartSpecOpsTraning.");
	   return;
      }
	$traninginprogress2 = 1;
	%sender.TP2started = 1;
	loadbuilding("SpecialOpsTraning2.cs");
	schedule(3000, 0, "globalPowerCheck");
	if(%sender.player.SOTspawned != 1)
	   SOTPlayerSpawn(%sender, "0 0 0 0 0 0 0");
	else
	   %sender.player.setTransform("0 0 0 0 0 0 0");
   }
}
