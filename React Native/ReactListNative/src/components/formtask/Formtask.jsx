
import { Alert, Text, TextInput, TouchableOpacity, View } from 'react-native';
import { FormtaskStyle } from './FormtaskStyle';
import { useContext, useState } from 'react';
import { TaskContext } from '../../context/TaskContext';

export const FormTask = () => {


  const { postTask, taskValue, setTaskValue, editMode, setEditMode, idToEdit, setIdToEdit, putTaskConfirm } = useContext(TaskContext)

  const saveTask = () => {
    console.log(taskValue)
    postTask(taskValue)
    Alert.alert("Título da Janela", `Tarefa: ${taskValue} cadastrado com sucesso`, [
      {
        text: "OK",
        onPress: () => { }
      }
    ])
  }

  return (
    <View style={FormtaskStyle.FRtaskBox}>
      <TextInput
        style={FormtaskStyle.TaskImputName}
        value={taskValue}
        onChangeText={(textoDigitado) => {
          setTaskValue(textoDigitado)
        }}
        placeholder='Adicione uma tarefa'
      />

      <TouchableOpacity style={FormtaskStyle.taskButton} onPress={() => {
        if(editMode){
          const Salvou = putTaskConfirm({id: idToEdit, descricao: taskValue})
          if(Salvou)
            Alert.alert("Editar", `${taskValue} foi editado!` , [{text:"OK"}] );
          else
            Alert.alert("Editar", "Erro ao editar", [{text:"OK"}] );
        }else{
        saveTask()}
      }}>
        <Text style={FormtaskStyle.taskButtonText}>Salvar</Text>
      </TouchableOpacity>

      {/* Cancelar */}
      {
        editMode && (
          <TouchableOpacity style={FormtaskStyle.taskButton}
            onPress={() => {
               setEditMode(false)
               setTaskValue("")
               setIdToEdit(0)
            }}>
            <Text style={FormtaskStyle.taskButtonText}>Cancelar</Text>
          </TouchableOpacity>

        )
      }

    </View>
  )
}