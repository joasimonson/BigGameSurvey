import React from "react";
import { Text, View, Image } from 'react-native';
import { TouchableWithoutFeedback } from "react-native-gesture-handler";
import { useNavigation } from "@react-navigation/native";

// import logoImg from "../../assets/logo.png";

import { styles } from "./styles";

const Header = () => {
    const { navigate } = useNavigation();

    const handleNavigateToHomePage = () => {
        navigate('Home')
    }

    return (
        <TouchableWithoutFeedback onPress={handleNavigateToHomePage}>
            <View style={styles.header}>
                {/* <Image source={logoImg} /> */}
                <Text style={styles.textLogo1}>Big Game</Text>
                <Text style={styles.textLogo2}>Survey</Text>
            </View>
        </TouchableWithoutFeedback>
    );
}

export default Header;