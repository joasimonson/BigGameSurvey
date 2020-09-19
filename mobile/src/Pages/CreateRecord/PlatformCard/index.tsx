import React from "react";
import { Text } from "react-native";
import { RectButton } from "react-native-gesture-handler";
import { FontAwesome5 as Icon } from "@expo/vector-icons";

import { Platform } from "../../../types/commons";

import { styles } from "./styles";

type Props = {
    platform: Platform;
    activePlatform?: Platform;
    onSelectPlatform: (platform: Platform) => void;
    icon: string;
}

const PlatformCard = ({ platform, onSelectPlatform, icon, activePlatform }: Props) => {
    const isActive = platform === activePlatform;
    const backgroundColor = isActive ? '#fad7c8' : '#FFF';
    const textColor = isActive ? "#ED7947" : "#9E9E9E";

    return (
        <RectButton
            style={[styles.platformCard, { backgroundColor }]}
            onPress={() => onSelectPlatform(platform)}
        >
            <Icon name={icon} size={60} color={textColor} />
            <Text style={[ styles.platformCardText, { color: textColor } ]}>
                {platform === Platform.PLAYSTATION ? "PS" : platform}
            </Text>
        </RectButton>
    )
};

export default PlatformCard;