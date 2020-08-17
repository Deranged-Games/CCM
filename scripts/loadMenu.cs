//------------------------------------------- 
// Mod information load screen - ZOD. z0ddm0d 
// and Modified later by the T2CC 
//------------------------------------------- 

package loadmodinfo 
{ 
   function sendLoadInfoToClient( %client ) { 
	Parent::sendLoadInfoToClient(%client); 
	schedule(10000, 0, "ConInfoLoad", %client); 
	schedule(20000, 0, "CCMInfoLoad", %client); 
   } 

   function ConInfoLoad(%client){ 
	%count = ClientGroup.getCount(); 
	for(%cl = 0; %cl < %count; %cl++){ 
	   %client = ClientGroup.getObject( %cl ); 
	   if (!%client.isAIControlled()) 
		sendConInfoToClient(%client); 
	} 
   }

   function CCMInfoLoad(%client){ 
	%count = ClientGroup.getCount(); 
	for(%cl = 0; %cl < %count; %cl++){ 
	   %client = ClientGroup.getObject( %cl ); 
	   if (!%client.isAIControlled()) 
		sendCCMInfoToClient(%client); 
	} 
   } 

   function sendConInfoToClient(%client){ 
	%on = "On";
	%off = "Off";
	%yes = "Yes";
	%no = "No";
	messageClient( %client, 'MsgLoadInfo', "", $CurrentMission, $MissionDisplayName, $Host::GameName );

	// Send mod details:
	%ModLine = "<color:8A2BE2><font:arial italic:30>Construction Mod" @
	"<font:Arial:16>\n\nVersion 0.69a (Distributed)" @ "\n" @
	"\n Website: www.theconstruct.tk \n" @
	"\n <font:Arial:12>Developers: Mostlikely, Construct, and JackTL";
	messageClient( %client, 'MsgLoadQuoteLine', "", %ModLine );

	%ServerText = "<color:8A2BE2><font:arial italic:22>Server Info:<font:arial italic:16>" @
	"\n Vehicles: " @ ($Host::Vehicles ? %on : %off) @
	"\n Max Players: " @ $Host::MaxPlayers @
	"\n Freindly Fire: " @ ($Host::TeamDamageOn ? %on : %off) @
	"\n Pure Build: " @ ($Host::Purebuild ? %on : %off) @
	"\n Expert: " @ ($Host::ExpertMode ? %on : %off) @
	"\n Hazard: " @ ($Host::Hazard::Enabled ? %on : %off) @
	"\n Jail: " @ ($Host::Prison::Enabled ? %on : %off) @
	"\n Cascade: " @ ($Host::Cascade ? %on : %off);
	messageClient( %client, 'MsgLoadRulesLine', "", %ServerText ); 
//	messageClient( %client, 'MsgLoadInfoDone' ); 
   }  

   function sendCCMInfoToClient(%client){ 
	%on = "On";
	%off = "Off";
	%yes = "Yes";
	%no = "No";
	messageClient( %client, 'MsgLoadInfo', "", $CurrentMission, $MissionDisplayName, $Host::GameName ); 

	// Send mod details: 
	%ModLine = "<color:00FFBB><font:arial italic:24>Combat Construction Mod v3.4 \n" @
	"\n<color:3BFF5A><font:arial italic:16> CCM Mod Team: Dondelium, FalconBlade, Ur_A_Dumb" @ 
	"\n Website: <a:www.angelfire.com/games4/deranged>www.angelfire.com/games4/deranged</a>"; 
	messageClient( %client, 'MsgLoadQuoteLine', "", %ModLine );

 	%ServerText = "<color:3BFF5A><font:arial italic:22>Server Info:<font:arial italic:16>" @
	"\n Vehicles: " @ ($Host::Vehicles ? %on : %off) @
	"\n Max Players: " @ $Host::MaxPlayers @
	"\n Freindly Fire: " @ ($Host::TeamDamageOn ? %on : %off) @
	"\n Pure Build: " @ ($Host::Purebuild ? %on : %off) @
	"\n Expert: " @ ($Host::ExpertMode ? %on : %off) @
	"\n Hazard: " @ ($Host::Hazard::Enabled ? %on : %off) @
	"\n Jail: " @ ($Host::Prison::Enabled ? %on : %off) @
	"\n Cascade: " @ ($Host::Cascade ? %on : %off);
	messageClient( %client, 'MsgLoadRulesLine', "", %ServerText );
	messageClient( %client, 'MsgLoadInfoDone' ); 
   }  
}; 

activatepackage(loadmodinfo); 