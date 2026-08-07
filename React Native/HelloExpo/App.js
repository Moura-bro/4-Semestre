import { StatusBar } from 'expo-status-bar';
import { StyleSheet, Text, View } from 'react-native';
import { SafeAreaProvider, SafeAreaView } from 'react-native-safe-area-context';
import Header from './components/header/header';



export default function App() {
  return (
    <>
    {/* npx expo install react-native-safe-area-context */}
    {/**/}
    <SafeAreaProvider>
      <SafeAreaView style={styles.safeArea}>
      <View style={styles.container}>
        <Header />
        <Text style={styles.texto1}>Open up App.js to start working on your Rafael!</Text>
        <Text style={styles.texto2}>Open up App.js to start working on your Rafael!</Text>
        <StatusBar style="auto" />
      </View>
      </SafeAreaView>
    </SafeAreaProvider>
    </>
  );
}

const styles = StyleSheet.create({
  safeArea:{
    flex: 1,
    backgroundColor: '#fffffff',
    
  },

  container : {
  width: "100%",
  height: "100%",
  borderColor: 'red',
  borderWidth: 3,
  borderStyle: 'dotted'
  },


  texto1 : {
    color: 'red'
  },
  texto2 : {
    color: 'blue'
  }
}) 



// const styles = StyleSheet.create({
//   container: {
//     flex: 1,
//     backgroundColor: '#f49e0b',
//     // alignItems: 'center',
//     // justifyContent: 'center',
//     borderWidth: 3,
//     borderStyle: 'solid',
//     borderColor: 'red',

//   },
// });
