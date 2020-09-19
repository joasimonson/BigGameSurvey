import React from "react";
import { FontAwesome5 as Icon } from "@expo/vector-icons";
import { Text, View, Image, Alert } from 'react-native';
import { RectButton } from "react-native-gesture-handler";
// import gamerImg from "../../assets/game.png";

import { useNavigation } from "@react-navigation/native";

import Header from '../../components/Header';

import { styles } from "./styles";

const Home = () => {
    const { navigate } = useNavigation();

    const handleNavigateToCreateRecordPage = () => {
        navigate('CreateRecord')
    }
    
    return (
        <>
            <Header />
            <View style={styles.container}>
                {/* <Image source={logoImg} style={styles.gamerImage} /> */}
                <Text style={styles.title}>Vote agora!</Text>
                <Text style={styles.subTitle}>Nos diga qual é seu jogo favorito!</Text>
            </View>
            <View style={styles.footer}>
                <RectButton style={styles.button}
                    onPress={handleNavigateToCreateRecordPage}
                >
                    <Text style={styles.buttonText}>COLETAR DADOS</Text>
                    <View style={styles.buttonIcon}>
                        <Text>
                            <Icon name="chevron-right" color="#FFF" size={25} />
                        </Text>
                    </View>
                </RectButton>
            </View>
        </>
    );
}

export default Home;