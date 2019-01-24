using System;
using UnityEngine;

// Token: 0x020000AE RID: 174
public static class BlueStonez
{
	// Token: 0x0600048A RID: 1162 RVA: 0x0002E704 File Offset: 0x0002C904
	public static void Initialize(GUISkin skin)
	{
		BlueStonez.Skin = skin;
		BlueStonez.box = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("box"));
		BlueStonez.label = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label"));
		BlueStonez.textField = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("textField"));
		BlueStonez.textArea = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("textArea"));
		BlueStonez.button = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("button"));
		BlueStonez.toggle = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("toggle"));
		BlueStonez.window = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("window"));
		BlueStonez.horizontalSlider = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("horizontalSlider"));
		BlueStonez.horizontalSliderThumb = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("horizontalSliderThumb"));
		BlueStonez.verticalSlider = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("verticalSlider"));
		BlueStonez.verticalSliderThumb = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("verticalSliderThumb"));
		BlueStonez.horizontalScrollbar = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("horizontalScrollbar"));
		BlueStonez.horizontalScrollbarThumb = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("horizontalScrollbarThumb"));
		BlueStonez.horizontalScrollbarLeftButton = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("horizontalScrollbarLeftButton"));
		BlueStonez.horizontalScrollbarRightButton = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("horizontalScrollbarRightButton"));
		BlueStonez.verticalScrollbar = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("verticalScrollbar"));
		BlueStonez.verticalScrollbarThumb = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("verticalScrollbarThumb"));
		BlueStonez.verticalScrollbarUpButton = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("verticalScrollbarUpButton"));
		BlueStonez.verticalScrollbarDownButton = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("verticalScrollbarDownButton"));
		BlueStonez.scrollView = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("scrollView"));
		BlueStonez.tab_large = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("tab_large"));
		BlueStonez.tab_large_left = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("tab_large_left"));
		BlueStonez.tab_largeicon = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("tab_largeicon"));
		BlueStonez.tab_medium = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("tab_medium"));
		BlueStonez.dropdown = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("dropdown"));
		BlueStonez.tab_strip = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("tab_strip"));
		BlueStonez.tab_strip_small = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("tab_strip_small"));
		BlueStonez.tab_strip_large = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("tab_strip_large"));
		BlueStonez.panelstrip_leftbutton = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("panelstrip_leftbutton"));
		BlueStonez.panelstrip_middlebutton = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("panelstrip_middlebutton"));
		BlueStonez.panelstrip_rightbutton = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("panelstrip_rightbutton"));
		BlueStonez.panelquad_button = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("panelquad_button"));
		BlueStonez.panelquad_toggle = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("panelquad_toggle"));
		BlueStonez.label_interparkbold_32pt_left = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_32pt_left"));
		BlueStonez.label_interparkbold_32pt = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_32pt"));
		BlueStonez.label_interparkbold_32pt_right = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_32pt_right"));
		BlueStonez.label_interparkbold_48pt = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_48pt"));
		BlueStonez.label_interparkbold_48pt_left = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_48pt_left"));
		BlueStonez.label_interparkbold_48pt_right = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_48pt_right"));
		BlueStonez.label_groupbox = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_groupbox"));
		BlueStonez.label_group_interparkbold_11pt = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_group_interparkbold_11pt"));
		BlueStonez.label_interparkbold_11pt = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_11pt"));
		BlueStonez.label_interparkbold_11pt_left = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_11pt_left"));
		BlueStonez.label_interparkbold_11pt_left_wrap = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_11pt_left_wrap"));
		BlueStonez.label_interparkbold_11pt_left_wrap_greybg = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_11pt_left_wrap_greybg"));
		BlueStonez.label_interparkbold_11pt_right = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_11pt_right"));
		BlueStonez.label_interparkmed_10pt_right = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkmed_10pt_right"));
		BlueStonez.label_interparkmed_10pt_left = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkmed_10pt_left"));
		BlueStonez.label_itemdescription = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_itemdescription"));
		BlueStonez.label_interparkbold_16pt = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_16pt"));
		BlueStonez.label_interparkbold_16pt_left = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_16pt_left"));
		BlueStonez.label_interparkbold_16pt_right = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_16pt_right"));
		BlueStonez.label_interparkbold_18pt_left = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_18pt_left"));
		BlueStonez.label_interparkbold_18pt_right = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_18pt_right"));
		BlueStonez.label_interparkbold_18pt_right_white = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_18pt_right_white"));
		BlueStonez.label_interparkmed_18pt_right = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkmed_18pt_right"));
		BlueStonez.label_interparkmed_18pt_left = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkmed_18pt_left"));
		BlueStonez.label_interparkmed_18pt_left_wrap = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkmed_18pt_left_wrap"));
		BlueStonez.label_ingamechat = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_ingamechat"));
		BlueStonez.box_grey31 = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("box_grey31"));
		BlueStonez.box_grey38 = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("box_grey38"));
		BlueStonez.box_white_2px = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("box_white_2px"));
		BlueStonez.box_grey_outlined = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("box_grey_outlined"));
		BlueStonez.box_grey_outlined_tip = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("box_grey_outlined_tip"));
		BlueStonez.box_white_rounded = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("box_white_rounded"));
		BlueStonez.window_standard_grey38 = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("window_standard_grey38"));
		BlueStonez.group_grey81 = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("group_grey81"));
		BlueStonez.label_group_interparkbold_18pt = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_group_interparkbold_18pt"));
		BlueStonez.label_interparkbold_18pt = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_18pt"));
		BlueStonez.radiobutton = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("radiobutton"));
		BlueStonez.ingamechat = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("ingamechat"));
		BlueStonez.speechbubble_left = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("speechbubble_left"));
		BlueStonez.speechbubble_right = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("speechbubble_right"));
		BlueStonez.tooltip = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("tooltip"));
		BlueStonez.label_interparkmed_11pt = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkmed_11pt"));
		BlueStonez.label_interparkmed_11pt_middleLeft = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkmed_11pt_middleLeft"));
		BlueStonez.label_interparkmed_11pt_left = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkmed_11pt_left"));
		BlueStonez.label_interparkmed_11pt_right = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkmed_11pt_right"));
		BlueStonez.label_interparkmed_11pt_url = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkmed_11pt_url"));
		BlueStonez.label_interparkbold_11pt_url = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_11pt_url"));
		BlueStonez.label_interparkbold_13pt = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_13pt"));
		BlueStonez.label_interparkbold_13pt_black = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_13pt_black"));
		BlueStonez.label_interparkbold_13pt_left = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_interparkbold_13pt_left"));
		BlueStonez.dropdown_button = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("dropdown_button"));
		BlueStonez.button_context = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("button_context"));
		BlueStonez.label_dropdown = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("label_dropdown"));
		BlueStonez.box_grey50 = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("box_grey50"));
		BlueStonez.packslot = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("packslot"));
		BlueStonez.box_overlay = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("box_overlay"));
		BlueStonez.box_overlay_black = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("box_overlay_black"));
		BlueStonez.dropdown_list = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("dropdown_list"));
		BlueStonez.dropdown_listItem = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("dropdown_listItem"));
		BlueStonez.buttondark_medium = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("buttondark_medium"));
		BlueStonez.button_fbconnect = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("button_fbconnect"));
		BlueStonez.buttongold_medium = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("buttongold_medium"));
		BlueStonez.buttongold_large_price = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("buttongold_large_price"));
		BlueStonez.buttongold_large = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("buttongold_large"));
		BlueStonez.button_white = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("button_white"));
		BlueStonez.button_green = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("button_green"));
		BlueStonez.button_red = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("button_red"));
		BlueStonez.buttondark_small = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("buttondark_small"));
		BlueStonez.toggle_item_slot = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("toggle_item_slot"));
		BlueStonez.item_slot_64 = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("item_slot_64"));
		BlueStonez.item_slot_large = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("item_slot_large"));
		BlueStonez.item_slot_alpha = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("item_slot_alpha"));
		BlueStonez.item_slot_small = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("item_slot_small"));
		BlueStonez.horizontal_line_grey95 = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("horizontal_line_grey95"));
		BlueStonez.vertical_line_grey95 = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("vertical_line_grey95"));
		BlueStonez.progressbar_background = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("progressbar_background"));
		BlueStonez.hud_progressbar_background = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("hud_progressbar_background"));
		BlueStonez.progressbar_large_background = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("progressbar_large_background"));
		BlueStonez.progressbar_large_thumb = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("progressbar_large_thumb"));
		BlueStonez.hud_progressbar_thumb = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("hud_progressbar_thumb"));
		BlueStonez.progressbar_thumb = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("progressbar_thumb"));
		BlueStonez.whitebutton = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("whitebutton"));
		BlueStonez.loadoutdropslot = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("loadoutdropslot"));
		BlueStonez.loadoutdropslot_highlight = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("loadoutdropslot_highlight"));
		BlueStonez.arrow_small_down = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("arrow_small_down"));
		BlueStonez.box_black = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("box_black"));
		BlueStonez.box_white = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("box_white"));
		BlueStonez.friends_listitem = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("friends_listitem"));
		BlueStonez.friends_hidden_button = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("friends_hidden_button"));
		BlueStonez.friends_contextlink = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("friends_contextlink"));
		BlueStonez.button_mainmenu = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("button_mainmenu"));
		BlueStonez.button_icontext = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("button_icontext"));
		BlueStonez.button_right = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("button_right"));
		BlueStonez.button_left = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("button_left"));
		BlueStonez.gray_background = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("gray_background"));
		BlueStonez.black_background = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("black_background"));
		BlueStonez.server_list = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("server_list"));
		BlueStonez.dropdown_large = LocalizationHelper.GetLocalizedStyle(BlueStonez.Skin.GetStyle("dropdown_large"));
	}

	// Token: 0x170000E1 RID: 225
	// (get) Token: 0x0600048B RID: 1163 RVA: 0x00005446 File Offset: 0x00003646
	// (set) Token: 0x0600048C RID: 1164 RVA: 0x0000544D File Offset: 0x0000364D
	public static GUISkin Skin { get; private set; }

	// Token: 0x04000402 RID: 1026
	public static GUIStyle box = GUIStyle.none;

	// Token: 0x04000403 RID: 1027
	public static GUIStyle label = GUIStyle.none;

	// Token: 0x04000404 RID: 1028
	public static GUIStyle textField = GUIStyle.none;

	// Token: 0x04000405 RID: 1029
	public static GUIStyle textArea = GUIStyle.none;

	// Token: 0x04000406 RID: 1030
	public static GUIStyle button = GUIStyle.none;

	// Token: 0x04000407 RID: 1031
	public static GUIStyle toggle = GUIStyle.none;

	// Token: 0x04000408 RID: 1032
	public static GUIStyle window = GUIStyle.none;

	// Token: 0x04000409 RID: 1033
	public static GUIStyle horizontalSlider = GUIStyle.none;

	// Token: 0x0400040A RID: 1034
	public static GUIStyle horizontalSliderThumb = GUIStyle.none;

	// Token: 0x0400040B RID: 1035
	public static GUIStyle verticalSlider = GUIStyle.none;

	// Token: 0x0400040C RID: 1036
	public static GUIStyle verticalSliderThumb = GUIStyle.none;

	// Token: 0x0400040D RID: 1037
	public static GUIStyle horizontalScrollbar = GUIStyle.none;

	// Token: 0x0400040E RID: 1038
	public static GUIStyle horizontalScrollbarThumb = GUIStyle.none;

	// Token: 0x0400040F RID: 1039
	public static GUIStyle horizontalScrollbarLeftButton = GUIStyle.none;

	// Token: 0x04000410 RID: 1040
	public static GUIStyle horizontalScrollbarRightButton = GUIStyle.none;

	// Token: 0x04000411 RID: 1041
	public static GUIStyle verticalScrollbar = GUIStyle.none;

	// Token: 0x04000412 RID: 1042
	public static GUIStyle verticalScrollbarThumb = GUIStyle.none;

	// Token: 0x04000413 RID: 1043
	public static GUIStyle verticalScrollbarUpButton = GUIStyle.none;

	// Token: 0x04000414 RID: 1044
	public static GUIStyle verticalScrollbarDownButton = GUIStyle.none;

	// Token: 0x04000415 RID: 1045
	public static GUIStyle scrollView = GUIStyle.none;

	// Token: 0x04000416 RID: 1046
	public static GUIStyle tab_large = GUIStyle.none;

	// Token: 0x04000417 RID: 1047
	public static GUIStyle tab_large_left = GUIStyle.none;

	// Token: 0x04000418 RID: 1048
	public static GUIStyle tab_largeicon = GUIStyle.none;

	// Token: 0x04000419 RID: 1049
	public static GUIStyle tab_medium = GUIStyle.none;

	// Token: 0x0400041A RID: 1050
	public static GUIStyle dropdown = GUIStyle.none;

	// Token: 0x0400041B RID: 1051
	public static GUIStyle tab_strip = GUIStyle.none;

	// Token: 0x0400041C RID: 1052
	public static GUIStyle tab_strip_small = GUIStyle.none;

	// Token: 0x0400041D RID: 1053
	public static GUIStyle tab_strip_large = GUIStyle.none;

	// Token: 0x0400041E RID: 1054
	public static GUIStyle panelstrip_leftbutton = GUIStyle.none;

	// Token: 0x0400041F RID: 1055
	public static GUIStyle panelstrip_middlebutton = GUIStyle.none;

	// Token: 0x04000420 RID: 1056
	public static GUIStyle panelstrip_rightbutton = GUIStyle.none;

	// Token: 0x04000421 RID: 1057
	public static GUIStyle panelquad_button = GUIStyle.none;

	// Token: 0x04000422 RID: 1058
	public static GUIStyle panelquad_toggle = GUIStyle.none;

	// Token: 0x04000423 RID: 1059
	public static GUIStyle label_interparkbold_32pt_left = GUIStyle.none;

	// Token: 0x04000424 RID: 1060
	public static GUIStyle label_interparkbold_32pt = GUIStyle.none;

	// Token: 0x04000425 RID: 1061
	public static GUIStyle label_interparkbold_32pt_right = GUIStyle.none;

	// Token: 0x04000426 RID: 1062
	public static GUIStyle label_interparkbold_48pt = GUIStyle.none;

	// Token: 0x04000427 RID: 1063
	public static GUIStyle label_interparkbold_48pt_left = GUIStyle.none;

	// Token: 0x04000428 RID: 1064
	public static GUIStyle label_interparkbold_48pt_right = GUIStyle.none;

	// Token: 0x04000429 RID: 1065
	public static GUIStyle label_groupbox = GUIStyle.none;

	// Token: 0x0400042A RID: 1066
	public static GUIStyle label_group_interparkbold_11pt = GUIStyle.none;

	// Token: 0x0400042B RID: 1067
	public static GUIStyle label_interparkbold_11pt = GUIStyle.none;

	// Token: 0x0400042C RID: 1068
	public static GUIStyle label_interparkbold_11pt_left = GUIStyle.none;

	// Token: 0x0400042D RID: 1069
	public static GUIStyle label_interparkbold_11pt_left_wrap = GUIStyle.none;

	// Token: 0x0400042E RID: 1070
	public static GUIStyle label_interparkbold_11pt_left_wrap_greybg = GUIStyle.none;

	// Token: 0x0400042F RID: 1071
	public static GUIStyle label_interparkbold_11pt_right = GUIStyle.none;

	// Token: 0x04000430 RID: 1072
	public static GUIStyle label_interparkmed_10pt_right = GUIStyle.none;

	// Token: 0x04000431 RID: 1073
	public static GUIStyle label_interparkmed_10pt_left = GUIStyle.none;

	// Token: 0x04000432 RID: 1074
	public static GUIStyle label_itemdescription = GUIStyle.none;

	// Token: 0x04000433 RID: 1075
	public static GUIStyle label_interparkbold_16pt = GUIStyle.none;

	// Token: 0x04000434 RID: 1076
	public static GUIStyle label_interparkbold_16pt_left = GUIStyle.none;

	// Token: 0x04000435 RID: 1077
	public static GUIStyle label_interparkbold_16pt_right = GUIStyle.none;

	// Token: 0x04000436 RID: 1078
	public static GUIStyle label_interparkbold_18pt_left = GUIStyle.none;

	// Token: 0x04000437 RID: 1079
	public static GUIStyle label_interparkbold_18pt_right = GUIStyle.none;

	// Token: 0x04000438 RID: 1080
	public static GUIStyle label_interparkbold_18pt_right_white = GUIStyle.none;

	// Token: 0x04000439 RID: 1081
	public static GUIStyle label_interparkmed_18pt_right = GUIStyle.none;

	// Token: 0x0400043A RID: 1082
	public static GUIStyle label_interparkmed_18pt_left = GUIStyle.none;

	// Token: 0x0400043B RID: 1083
	public static GUIStyle label_interparkmed_18pt_left_wrap = GUIStyle.none;

	// Token: 0x0400043C RID: 1084
	public static GUIStyle label_ingamechat = GUIStyle.none;

	// Token: 0x0400043D RID: 1085
	public static GUIStyle box_grey31 = GUIStyle.none;

	// Token: 0x0400043E RID: 1086
	public static GUIStyle box_grey38 = GUIStyle.none;

	// Token: 0x0400043F RID: 1087
	public static GUIStyle box_white_2px = GUIStyle.none;

	// Token: 0x04000440 RID: 1088
	public static GUIStyle box_grey_outlined = GUIStyle.none;

	// Token: 0x04000441 RID: 1089
	public static GUIStyle box_grey_outlined_tip = GUIStyle.none;

	// Token: 0x04000442 RID: 1090
	public static GUIStyle box_white_rounded = GUIStyle.none;

	// Token: 0x04000443 RID: 1091
	public static GUIStyle window_standard_grey38 = GUIStyle.none;

	// Token: 0x04000444 RID: 1092
	public static GUIStyle group_grey81 = GUIStyle.none;

	// Token: 0x04000445 RID: 1093
	public static GUIStyle label_group_interparkbold_18pt = GUIStyle.none;

	// Token: 0x04000446 RID: 1094
	public static GUIStyle label_interparkbold_18pt = GUIStyle.none;

	// Token: 0x04000447 RID: 1095
	public static GUIStyle radiobutton = GUIStyle.none;

	// Token: 0x04000448 RID: 1096
	public static GUIStyle ingamechat = GUIStyle.none;

	// Token: 0x04000449 RID: 1097
	public static GUIStyle speechbubble_left = GUIStyle.none;

	// Token: 0x0400044A RID: 1098
	public static GUIStyle speechbubble_right = GUIStyle.none;

	// Token: 0x0400044B RID: 1099
	public static GUIStyle tooltip = GUIStyle.none;

	// Token: 0x0400044C RID: 1100
	public static GUIStyle label_interparkmed_11pt = GUIStyle.none;

	// Token: 0x0400044D RID: 1101
	public static GUIStyle label_interparkmed_11pt_middleLeft = GUIStyle.none;

	// Token: 0x0400044E RID: 1102
	public static GUIStyle label_interparkmed_11pt_left = GUIStyle.none;

	// Token: 0x0400044F RID: 1103
	public static GUIStyle label_interparkmed_11pt_right = GUIStyle.none;

	// Token: 0x04000450 RID: 1104
	public static GUIStyle label_interparkmed_11pt_url = GUIStyle.none;

	// Token: 0x04000451 RID: 1105
	public static GUIStyle label_interparkbold_11pt_url = GUIStyle.none;

	// Token: 0x04000452 RID: 1106
	public static GUIStyle label_interparkbold_13pt = GUIStyle.none;

	// Token: 0x04000453 RID: 1107
	public static GUIStyle label_interparkbold_13pt_black = GUIStyle.none;

	// Token: 0x04000454 RID: 1108
	public static GUIStyle label_interparkbold_13pt_left = GUIStyle.none;

	// Token: 0x04000455 RID: 1109
	public static GUIStyle dropdown_button = GUIStyle.none;

	// Token: 0x04000456 RID: 1110
	public static GUIStyle button_context = GUIStyle.none;

	// Token: 0x04000457 RID: 1111
	public static GUIStyle label_dropdown = GUIStyle.none;

	// Token: 0x04000458 RID: 1112
	public static GUIStyle box_grey50 = GUIStyle.none;

	// Token: 0x04000459 RID: 1113
	public static GUIStyle packslot = GUIStyle.none;

	// Token: 0x0400045A RID: 1114
	public static GUIStyle box_overlay = GUIStyle.none;

	// Token: 0x0400045B RID: 1115
	public static GUIStyle box_overlay_black = GUIStyle.none;

	// Token: 0x0400045C RID: 1116
	public static GUIStyle dropdown_list = GUIStyle.none;

	// Token: 0x0400045D RID: 1117
	public static GUIStyle dropdown_listItem = GUIStyle.none;

	// Token: 0x0400045E RID: 1118
	public static GUIStyle buttondark_medium = GUIStyle.none;

	// Token: 0x0400045F RID: 1119
	public static GUIStyle button_fbconnect = GUIStyle.none;

	// Token: 0x04000460 RID: 1120
	public static GUIStyle buttongold_medium = GUIStyle.none;

	// Token: 0x04000461 RID: 1121
	public static GUIStyle buttongold_large_price = GUIStyle.none;

	// Token: 0x04000462 RID: 1122
	public static GUIStyle buttongold_large = GUIStyle.none;

	// Token: 0x04000463 RID: 1123
	public static GUIStyle button_white = GUIStyle.none;

	// Token: 0x04000464 RID: 1124
	public static GUIStyle button_green = GUIStyle.none;

	// Token: 0x04000465 RID: 1125
	public static GUIStyle button_red = GUIStyle.none;

	// Token: 0x04000466 RID: 1126
	public static GUIStyle buttondark_small = GUIStyle.none;

	// Token: 0x04000467 RID: 1127
	public static GUIStyle toggle_item_slot = GUIStyle.none;

	// Token: 0x04000468 RID: 1128
	public static GUIStyle item_slot_64 = GUIStyle.none;

	// Token: 0x04000469 RID: 1129
	public static GUIStyle item_slot_large = GUIStyle.none;

	// Token: 0x0400046A RID: 1130
	public static GUIStyle item_slot_alpha = GUIStyle.none;

	// Token: 0x0400046B RID: 1131
	public static GUIStyle item_slot_small = GUIStyle.none;

	// Token: 0x0400046C RID: 1132
	public static GUIStyle horizontal_line_grey95 = GUIStyle.none;

	// Token: 0x0400046D RID: 1133
	public static GUIStyle vertical_line_grey95 = GUIStyle.none;

	// Token: 0x0400046E RID: 1134
	public static GUIStyle progressbar_background = GUIStyle.none;

	// Token: 0x0400046F RID: 1135
	public static GUIStyle hud_progressbar_background = GUIStyle.none;

	// Token: 0x04000470 RID: 1136
	public static GUIStyle progressbar_large_background = GUIStyle.none;

	// Token: 0x04000471 RID: 1137
	public static GUIStyle progressbar_large_thumb = GUIStyle.none;

	// Token: 0x04000472 RID: 1138
	public static GUIStyle hud_progressbar_thumb = GUIStyle.none;

	// Token: 0x04000473 RID: 1139
	public static GUIStyle progressbar_thumb = GUIStyle.none;

	// Token: 0x04000474 RID: 1140
	public static GUIStyle whitebutton = GUIStyle.none;

	// Token: 0x04000475 RID: 1141
	public static GUIStyle loadoutdropslot = GUIStyle.none;

	// Token: 0x04000476 RID: 1142
	public static GUIStyle loadoutdropslot_highlight = GUIStyle.none;

	// Token: 0x04000477 RID: 1143
	public static GUIStyle arrow_small_down = GUIStyle.none;

	// Token: 0x04000478 RID: 1144
	public static GUIStyle box_black = GUIStyle.none;

	// Token: 0x04000479 RID: 1145
	public static GUIStyle box_white = GUIStyle.none;

	// Token: 0x0400047A RID: 1146
	public static GUIStyle friends_listitem = GUIStyle.none;

	// Token: 0x0400047B RID: 1147
	public static GUIStyle friends_hidden_button = GUIStyle.none;

	// Token: 0x0400047C RID: 1148
	public static GUIStyle friends_contextlink = GUIStyle.none;

	// Token: 0x0400047D RID: 1149
	public static GUIStyle button_mainmenu = GUIStyle.none;

	// Token: 0x0400047E RID: 1150
	public static GUIStyle button_icontext = GUIStyle.none;

	// Token: 0x0400047F RID: 1151
	public static GUIStyle button_right = GUIStyle.none;

	// Token: 0x04000480 RID: 1152
	public static GUIStyle button_left = GUIStyle.none;

	// Token: 0x04000481 RID: 1153
	public static GUIStyle gray_background = GUIStyle.none;

	// Token: 0x04000482 RID: 1154
	public static GUIStyle black_background = GUIStyle.none;

	// Token: 0x04000483 RID: 1155
	public static GUIStyle server_list = GUIStyle.none;

	// Token: 0x04000484 RID: 1156
	public static GUIStyle dropdown_large = GUIStyle.none;
}
