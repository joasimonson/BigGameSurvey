import React from 'react';
import { StatusBar } from 'expo-status-bar';
import { StyleSheet, View } from 'react-native';
import { AppLoading } from 'expo';
import {
  useFonts,
  Play_400Regular,
  Play_700Bold
} from '@expo-google-fonts/play';

import AppStack from './src/routes/AppStack';

export default function App() {
  const [fontsLoaded] = useFonts({
    Play_400Regular,
    Play_700Bold
  });

  if (!fontsLoaded) {
    return <AppLoading />
  }

  return (
    <View style={styles.container}>
      <AppStack />
      <StatusBar style="auto" />
    </View>
  );
}

export const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
});
