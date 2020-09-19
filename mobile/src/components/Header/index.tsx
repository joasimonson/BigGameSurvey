import React from "react";
import { Text, View, Image } from 'react-native';

// import logoImg from "../../assets/logo.png";

import { styles } from "./styles";

const Header = () => {
    return (
        <View style={styles.header}>
            {/* <Image source={logoImg} /> */}
            <Text style={styles.textLogo1}>Big Game</Text>
            <Text style={styles.textLogo2}>Survey</Text>
        </View>
    );
}

export default Header;