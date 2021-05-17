import React from 'react';
import {View} from 'react-native';
import {Header} from 'react-native-elements';
import {SafeAreaProvider} from 'react-native-safe-area-context';
import {TarefasScreen} from './src/screens/Tarefas';

function App() {
  return (
    <SafeAreaProvider>
      <View style={styles.view}>
        <Header
          leftComponent={{icon: 'menu', color: '#fff'}}
          centerComponent={{text: 'Tarefas', style: {color: '#fff'}}}
          rightComponent={{icon: 'add', color: '#fff'}}
        />
        <TarefasScreen />
      </View>
    </SafeAreaProvider>
  );
}

const styles = {
  view: {
    flex: 1,
    backgroundColor: '#ffffff',
  },
};

export default App;
