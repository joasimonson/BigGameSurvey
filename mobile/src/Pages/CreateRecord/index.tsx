import React, { useEffect, useState } from "react";
import { View, TextInput, Text, Alert } from "react-native";
import Header from "../../components/Header";
import PlatformCard from "./PlatformCard";
import RNPickerSelect from "react-native-picker-select";
import { RectButton } from "react-native-gesture-handler";
import { FontAwesome5 as Icon } from "@expo/vector-icons";

import api from "../../services/api";

import { Platform } from "../../types/commons";

import { styles, pickerSelectStyles } from "./styles";
import { Game } from "../../types/model";

type gameItemSelect = {
    label: string;
    value: number;
}

const fillSelect = (arrayGames: Game[], platform: Platform) : gameItemSelect[] => {
    let contentSelect = arrayGames
        .filter(item => item.platform === platform)
        .map((item: Game) => ({
            label: item.title,
            value: item.id
        } as gameItemSelect));

    return contentSelect;
}


const CreateRecord = () => {
    const [name, setName] = useState('');
    const [age, setAge] = useState('');
    const [platform, setPlatform] = useState<Platform>();
    const [selectedGame, setSelectedGame] = useState('');
    const [games, setGames] = useState<Game[]>([]);
    const [filteredGames, setFilteredGames] = useState<gameItemSelect[]>([]);

    const handleChangePlatform = (selectedPlatform: Platform) => {
        setPlatform(selectedPlatform);
        const gamesByPlatform = fillSelect(games, selectedPlatform);
        setFilteredGames(gamesByPlatform);
    }

    const handleChangeGame = (name: string) => {
        setSelectedGame(name);
    }

    const handleSaveSurvey = () => {
        const data = {
            name,
            age: Number.parseInt(age),
            gameId: Number.parseInt(selectedGame)
        };

        api.post('records', data)
            .then(() => {
                setName('');
                setAge('');
                setSelectedGame('');
                setPlatform(undefined);
                Alert.alert('Pesquisa salva com sucesso.');
            })
            .catch((erro) => {
                debugger;
                console.log(erro);
                Alert.alert('Falha ao salvar pesquisa.');
            });
    }

    useEffect(() => {
        const getGamesData = async () => {
            const gamesResponse = await api.get('games');
            setGames(gamesResponse.data);
        }

        getGamesData();
    }, []);

    const renderIconPickerSelect = () => {
        return <Icon name="chevron-down" color="#9E9E9E" size={25} />
    }

    return (
        <>
            <Header />
            <View style={styles.container}>
                <TextInput
                    style={styles.inputText}
                    placeholder="Nome"
                    placeholderTextColor="#9E9E9E"
                    value={name}
                    onChangeText={setName}
                />
                <TextInput
                    keyboardType="numeric"
                    style={styles.inputText}
                    placeholder="Idade"
                    placeholderTextColor="#9E9E9E"
                    value={age}
                    onChangeText={setAge}
                    maxLength={3}
                />
                <View style={styles.platformContainer}>
                    <PlatformCard
                        platform={Platform.PC}
                        onSelectPlatform={handleChangePlatform}
                        icon="laptop"
                        activePlatform={platform}
                    />
                    <PlatformCard
                        platform={Platform.XBOX}
                        onSelectPlatform={handleChangePlatform}
                        icon="xbox"
                        activePlatform={platform}
                    />
                    <PlatformCard
                        platform={Platform.PLAYSTATION}
                        onSelectPlatform={handleChangePlatform}
                        icon="playstation"
                        activePlatform={platform}
                    />
                </View>
                <RNPickerSelect
                    placeholder={{
                        label: 'Selecione o game',
                        value: null
                    }}
                    onValueChange={handleChangeGame}
                    value={selectedGame}
                    items={filteredGames}
                    style={pickerSelectStyles}
                    Icon={renderIconPickerSelect}
                />
                <View style={styles.footer}>
                    <RectButton style={styles.button} onPress={handleSaveSurvey}>
                        <Text style={styles.buttonText}>SALVAR</Text>
                    </RectButton>
                </View>
            </View>
        </>
    )
};

export default CreateRecord;