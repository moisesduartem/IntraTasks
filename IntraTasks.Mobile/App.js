import React from 'react';
import 'react-native-gesture-handler';

import {NavigationContainer} from '@react-navigation/native';
import {SafeAreaProvider} from 'react-native-safe-area-context';
import {createDrawerNavigator} from '@react-navigation/drawer';

import {Header} from 'react-native-elements';
import {TarefasScreen} from './src/screens/Tarefas';
import {MembrosScreen} from './src/screens/Membros';

const Drawer = createDrawerNavigator();

function App() {
  return (
    <NavigationContainer>
      <SafeAreaProvider>
        <Header
          leftComponent={{icon: 'menu', color: '#fff'}}
          centerComponent={{text: 'IntraTasks', style: {color: '#fff'}}}
        />
        <Drawer.Navigator
          sceneContainerStyle={styles.contentContainer}
          initialRouteName="Tarefas">
          <Drawer.Screen name="Tarefas" component={TarefasScreen} />
          <Drawer.Screen name="Membros" component={MembrosScreen} />
        </Drawer.Navigator>
      </SafeAreaProvider>
    </NavigationContainer>
  );
}

const styles = {
  contentContainer: {
    padding: 18,
  },
};

export default App;
