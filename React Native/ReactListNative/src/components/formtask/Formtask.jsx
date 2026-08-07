
import { Alert, Text, TextInput, TouchableOpacity, View } from 'react-native';
import { FormtaskStyle} from './FormtaskStyle';
import { useState } from 'react';

export const FormTask = () => {
    const [taskValue, setTaskValue] = useState("")

    const  saveTask = () => {
      console.log(taskValue)
      Alert.alert("Título da Janela", `Tarefa: ${taskValue} cadastrado com sucesso`, [
        {
          text: "OK",
          onPress: ()=>{}
        }
      ])
    }

    return(
        <View style = {FormtaskStyle.FRtaskBox}>
            <TextInput
              style = {FormtaskStyle.TaskImputName}
              value={taskValue}
              onChangeText={(textoDigitado) => {
                setTaskValue(textoDigitado)
              }}
              placeholder='Adicione uma tarefa'
            />

            <TouchableOpacity style={FormtaskStyle.taskButton} onPress={()=>{
              saveTask()
            }}>
                 <Text style={FormtaskStyle.taskButtonText}>Adicionar</Text>
            </TouchableOpacity>
        </View>
    )
}