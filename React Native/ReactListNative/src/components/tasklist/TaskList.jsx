
import { useContext, useEffect, useState } from 'react';
import { TaskItem } from '../taskitem/TaskItem';
import { TaskListStyle } from './TaskListStyle';
import { ScrollView, Text, View } from 'react-native';
import axios from 'axios';
import { TaskContext } from '../../context/TaskContext';

export const TaskList = () => {
  const {listagemTarefas, getTasks, } = useContext(TaskContext)

//---
useEffect(() =>{
  getTasks()
},[])


    return(
     <ScrollView style={TaskListStyle.taskListContainer}>
      {listagemTarefas.map((Tarefa) => {
        return (
          <TaskItem  key={Tarefa.id} id={Tarefa.id} descricao={Tarefa.descricao}/>
        )
      })}
       
      
     </ScrollView>
    )
}