import { Image, Text, TouchableOpacity, View } from 'react-native';
import { TaskItemStyle } from './TaskItemStyle';
import Lapiz from '../../../assets/lapiz.png';
import lixo from '../../../assets/lixo.png';
import { useContext } from 'react';
import { TaskContext } from '../../context/TaskContext';

export const TaskItem = ({ id, descricao }) => {

    const { deleteTask, setTaskValue, editMode, setEditMode, idToEdit, setIdToEdit } = useContext(TaskContext)

    return (
        <>
            <View style={TaskItemStyle.cardBox}>
                <Text style={TaskItemStyle.cardBoxText} >{descricao}</Text>

                <TouchableOpacity
                    style={[TaskItemStyle.cardboxButton, TaskItemStyle.cardboxButtonEdit]}
                    onPress={() => {
                        // preenche o state global, daí já aparece no formulário

                        setTaskValue(descricao)// na verdade tem que chamar o putEditPreview
                        setEditMode(true)//fazer isso dentro do putEditPreview
                        setIdToEdit(id)
                    }}
                >
                    <Image source={require("../../../assets/lapiz.png")} />
                </TouchableOpacity>



                <TouchableOpacity style={[TaskItemStyle.cardboxButton, TaskItemStyle.cardboxButtonTrash]} onPress={() => {
                    // chamar  a funcao  deletetask
                    deleteTask(id)
                }}>
                    <Image source={require("../../../assets/lixo.png")} />
                </TouchableOpacity>
            </View>


        </>
    )
}