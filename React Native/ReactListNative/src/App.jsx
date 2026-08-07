import { StatusBar } from 'expo-status-bar';
import { Text, View } from 'react-native';
import { SafeAreaProvider, SafeAreaView } from 'react-native-safe-area-context';
import { styles } from "./Styles";
import { Header } from "./components/header/Header";
import { FormTask } from './components/formtask/Formtask';
import { TaskList } from './components/tasklist/TaskList';

export default function App() {
  return (
    <SafeAreaProvider>
      <SafeAreaView style={styles.safeContainer}>
        <View style={styles.container}>
          <Header/>
          <FormTask/>
          <TaskList/>
          <StatusBar style="auto" />
        </View>
      </SafeAreaView>
    </SafeAreaProvider>
  );
}

