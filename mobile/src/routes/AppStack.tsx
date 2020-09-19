import React from "react";

import { NavigationContainer } from "@react-navigation/native";
import { createStackNavigator } from "@react-navigation/stack";

import Home from "../pages/Home";
import CreateRecord from "../pages/CreateRecord";

const { Navigator, Screen } = createStackNavigator();

const AppStack = () => {
    return (
        <NavigationContainer>
            <Navigator
                headerMode="none"
                screenOptions={{
                    cardStyle: {
                        backgroundColor: "#0B1F34",
                    }
                }}
            >
                <Screen name="Home" component={Home} />
                <Screen name="CreateRecord" component={CreateRecord} />
            </Navigator>
        </NavigationContainer>
    )
};

export default AppStack;